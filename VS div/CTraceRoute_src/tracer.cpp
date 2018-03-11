/*
Module : TRACER.CPP
Purpose: Implementation for an MFC wrapper class to encapsulate TRACE ROUTE functionality
Created: PJN / 17-11-1998
History: None


Copyright (c) 1998 by PJ Naughter.  
All rights reserved.

*/


/////////////////////////////////  Includes  //////////////////////////////////
#include "stdafx.h"
#include "tracer.h"
#include <limits.h>


/////////////////////////////////  Macros & Statics ///////////////////////////

#define MIN_ICMP_PACKET_SIZE 8    //minimum 8 byte icmp packet (just header)
#define MAX_ICMP_PACKET_SIZE 1024 //Maximum icmp packet size

BOOL CTraceRoute::sm_bAttemptedIcmpInitialise = FALSE;
lpIcmpCreateFile CTraceRoute::sm_pIcmpCreateFile = NULL;
lpIcmpSendEcho CTraceRoute::sm_pIcmpSendEcho = NULL;
lpIcmpCloseHandle CTraceRoute::sm_pIcmpCloseHandle = NULL;

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif



///////////////////////////////// Implementation //////////////////////////////

//Internal class which is used to ensure that the ICMP
//handle and winsock stack is closed upon exit 
class _CTRACEROUTE
{
public:
  _CTRACEROUTE();
	~_CTRACEROUTE();
protected:
  HINSTANCE sm_hIcmp;

	friend class CTraceRoute;
};

_CTRACEROUTE::_CTRACEROUTE()
{
  sm_hIcmp = NULL;
}

_CTRACEROUTE::~_CTRACEROUTE()
{
	if (sm_hIcmp)
	{
		FreeLibrary(sm_hIcmp);
		sm_hIcmp = NULL;
  }

	WSACleanup();
}

static _CTRACEROUTE _cTraceRouteData;





BOOL CTraceRoute::Initialise() const
{
	if (!sm_bAttemptedIcmpInitialise)
	{
		sm_bAttemptedIcmpInitialise = TRUE;

		//Initialise the winsock stack
		WSADATA wsa;
		if (WSAStartup(MAKEWORD(1, 1), &wsa) != 0)
		{
			TRACE(_T("Could not negotiate a correct version of WinSock\n"));
			return FALSE;
		}

		//Load up the ICMP library
		_cTraceRouteData.sm_hIcmp = LoadLibrary(_T("ICMP.DLL"));
		if (_cTraceRouteData.sm_hIcmp == NULL)
		{
			TRACE(_T("Could not load up the ICMP DLL\n"));
			return FALSE;
		}

		//Retrieve pointers to the functions in the ICMP dll
		sm_pIcmpCreateFile = (lpIcmpCreateFile) GetProcAddress(_cTraceRouteData.sm_hIcmp,"IcmpCreateFile");
		sm_pIcmpSendEcho = (lpIcmpSendEcho) GetProcAddress(_cTraceRouteData.sm_hIcmp,"IcmpSendEcho" );
		sm_pIcmpCloseHandle = (lpIcmpCloseHandle) GetProcAddress(_cTraceRouteData.sm_hIcmp,"IcmpCloseHandle");

		if (sm_pIcmpCreateFile == NULL || sm_pIcmpSendEcho == NULL ||	sm_pIcmpCloseHandle == NULL)
		  TRACE(_T("Could not find ICMP functions in the ICMP DLL\n"));
	}

	return (sm_pIcmpCreateFile != NULL && sm_pIcmpSendEcho != NULL &&	sm_pIcmpCloseHandle != NULL);
}

BOOL CTraceRoute::Trace(LPCTSTR pszHostName, CTraceRouteReply& trr, UCHAR nHopCount, DWORD dwTimeout, DWORD dwPingsPerHost)
{
	//For correct operation of the T2A macro, see TN059
	USES_CONVERSION;

  //Validate our parameters
  ASSERT(pszHostName);
  ASSERT(trr.GetSize() == 0); //Should be empty initially
  ASSERT(nHopCount > 0);

	//Make sure everything is initialised
	if (!Initialise())
	  return FALSE;

	LPSTR lpszAscii = T2A((LPTSTR) pszHostName);
	//Convert from dotted notation if required
	unsigned long	addr = inet_addr(lpszAscii);
	if (addr == INADDR_NONE)
	{
		//Not a dotted address, then do a lookup of the name
		hostent* hp = gethostbyname(lpszAscii);
		if (hp)
			memcpy(&addr, hp->h_addr, hp->h_length);
		else
		{
			TRACE(_T("Could not resolve the host name %s\n"), pszHostName);
			return FALSE;
		}
	}

  ASSERT(_cTraceRouteData.sm_hIcmp); //ICMP dll must be open

  //Iterate through all the hop count values
  BOOL bReachedHost = FALSE;
  for (UCHAR i=1; i<=nHopCount && !bReachedHost; i++)
  {
    CHostTraceMultiReply htrr;
    htrr.dwError = 0;
    htrr.minRTT = ULONG_MAX;
    htrr.avgRTT = 0;
    htrr.maxRTT = 0;

    //Iterate through all the pings for each host
    DWORD totalRTT = 0;
    CHostTraceSingleReply htsr;
    htsr.Address.S_un.S_addr = 0;
    htsr.dwError = 0;
    BOOL bPingError = FALSE;
    for (DWORD j=0; j<dwPingsPerHost && !bPingError; j++)
    {
	    if (Ping(addr, htsr, i, dwTimeout))
      {
        if (htsr.dwError == 0)
        {
          //Acumulate the total RTT
          totalRTT += htsr.RTT;

          //Store away the RTT's
          if (htsr.RTT < htrr.minRTT)
            htrr.minRTT = htsr.RTT;
          if (htsr.RTT > htrr.maxRTT)
            htrr.maxRTT = htsr.RTT;

          //Call the virtual function
          if (!OnPingResult(j+1, htsr))
          {
            SetLastError(ERROR_CANCELLED);
            return FALSE;
          }
        }
        else
        {
          htrr.dwError = htsr.dwError;
          bPingError = TRUE;
        }
      }
      else
        return FALSE;
    }
    htrr.Address = htsr.Address;
    if (htrr.dwError == 0)
      htrr.avgRTT = totalRTT / dwPingsPerHost;
    else
    {
      htrr.minRTT = 0;
      htrr.avgRTT = 0;
      htrr.maxRTT = 0;
    }

    //Call the virtual function
    if (!OnSingleHostResult(i, htrr))
    {
      SetLastError(ERROR_CANCELLED);
      return FALSE;
    }

    //Add to the list of hosts
    trr.Add(htrr);

    //Have we reached the final host ?
    if (addr == htrr.Address.S_un.S_addr)
      bReachedHost = TRUE;
  }

  return TRUE;
}

BOOL CTraceRoute::Ping(unsigned long addr, CHostTraceSingleReply& htsr, UCHAR nTTL, DWORD dwTimeout, UCHAR nPacketSize) const
{
  //Create the ICMP handle
	HANDLE hIP = sm_pIcmpCreateFile();
	if (hIP == INVALID_HANDLE_VALUE)
	{
		TRACE(_T("Could not get a valid ICMP handle\n"));
		return FALSE;
	}

  //Set up the option info structure
	IP_OPTION_INFORMATION OptionInfo;
	ZeroMemory(&OptionInfo, sizeof(IP_OPTION_INFORMATION));
	OptionInfo.Ttl = nTTL;

  //Set up the data which will be sent
  unsigned char* pBuf = new unsigned char[nPacketSize];
  memset(pBuf, 'E', nPacketSize);

	//Do the actual Ping
  int nReplySize = sizeof(ICMP_ECHO_REPLY) + max(MIN_ICMP_PACKET_SIZE, nPacketSize);
  unsigned char* pReply = new unsigned char[nReplySize];
	ICMP_ECHO_REPLY* pEchoReply = (ICMP_ECHO_REPLY*) pReply;
  DWORD nRecvPackets = sm_pIcmpSendEcho(hIP, addr, pBuf, nPacketSize, &OptionInfo, pReply, nReplySize, dwTimeout);

  BOOL bSuccess = TRUE;
  //Check we got the packet back
  if (nRecvPackets != 1)
    htsr.dwError = GetLastError();
  else
  {
    //Ping was successful, copy over the pertinent info
    //into the return structure
		htsr.Address.S_un.S_addr = pEchoReply->Address;
	  htsr.RTT = pEchoReply->RoundTripTime;
  }

  //Close the ICMP handle
	sm_pIcmpCloseHandle(hIP);

  //Free up the memory we allocated
  delete [] pBuf;
  delete [] pReply;

  //return the status
	return bSuccess; 
}




BOOL CTraceRoute::OnPingResult(int nPingNum, const CHostTraceSingleReply& htsr)
{
  //Default behaviour is just to trace the result and return
  //TRUE to allow the trace route to continue

  TRACE(_T("OnPingResult: %d, IP: %d.%d.%d.%d, RTT: %d, Error: %d\n"), nPingNum, 
        htsr.Address.S_un.S_un_b.s_b1, htsr.Address.S_un.S_un_b.s_b2, htsr.Address.S_un.S_un_b.s_b3, 
        htsr.Address.S_un.S_un_b.s_b4, htsr.RTT, htsr.dwError);

  return TRUE;
}

BOOL CTraceRoute::OnSingleHostResult(int nHostNum, const CHostTraceMultiReply& htmr)
{
  //Default behaviour is just to trace the result and return
  //TRUE to allow the trace route to continue
  TRACE(_T("OnSingleHostResult: %d, IP: %d.%d.%d.%d, Min RTT: %d, Avg RTT: %d, Max RTT: %d, Error: %d\n"), nHostNum, 
        htmr.Address.S_un.S_un_b.s_b1, htmr.Address.S_un.S_un_b.s_b2, htmr.Address.S_un.S_un_b.s_b3, 
        htmr.Address.S_un.S_un_b.s_b4, htmr.minRTT, htmr.avgRTT, htmr.maxRTT, htmr.dwError);

  return TRUE;
}
