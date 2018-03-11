/*
Module : TRACER.H
Purpose: Interface for an MFC wrapper class to encapsulate TRACE ROUTE functionality
Created: PJN / 17-11-1998
History: None

Copyright (c) 1998 by PJ Naughter.  
All rights reserved.

*/


/////////////////////////// Macros ///////////////////////////

#ifndef __TRACER_H__
#define __TRACER_H__


#ifndef __AFXTEMPL_H__
#pragma message("Trace route class needs afxtempl.h in your PCH")
#endif


/////////////////////////// Classes /////////////////////////////////

//These defines & structure definitions are taken from the "ipexport.h" and
//"icmpapi.h" header files as provided with the Platform SDK and
//are used internally by the CTraceRoute class. Including them here allows
//you to compile the CTraceRoute code without the need to have the full 
//Platform SDK installed.

typedef unsigned long IPAddr;     // An IP address.

typedef struct tagIP_OPTION_INFORMATION 
{
  unsigned char      Ttl;              // Time To Live
  unsigned char      Tos;              // Type Of Service
  unsigned char      Flags;            // IP header flags
  unsigned char      OptionsSize;      // Size in bytes of options data
  unsigned char FAR *OptionsData;      // Pointer to options data
} IP_OPTION_INFORMATION;

typedef struct tagICMP_ECHO_REPLY 
{
  IPAddr                Address;       // Replying address
  unsigned long         Status;        // Reply IP_STATUS
  unsigned long         RoundTripTime; // RTT in milliseconds
  unsigned short        DataSize;      // Reply data size in bytes
  unsigned short        Reserved;      // Reserved for system use
  void FAR              *Data;         // Pointer to the reply data
  IP_OPTION_INFORMATION Options;       // Reply options
} ICMP_ECHO_REPLY;

typedef IP_OPTION_INFORMATION FAR* LPIP_OPTION_INFORMATION;
typedef ICMP_ECHO_REPLY FAR* LPICMP_ECHO_REPLY;
typedef HANDLE (WINAPI IcmpCreateFile)(VOID);
typedef IcmpCreateFile* lpIcmpCreateFile;
typedef BOOL (WINAPI IcmpCloseHandle)(HANDLE IcmpHandle);
typedef IcmpCloseHandle* lpIcmpCloseHandle;
typedef DWORD (WINAPI IcmpSendEcho)(HANDLE IcmpHandle, IPAddr DestinationAddress,
                                    LPVOID RequestData, WORD RequestSize,
                                    LPIP_OPTION_INFORMATION RequestOptions,
                                    LPVOID ReplyBuffer, DWORD ReplySize, DWORD Timeout);
typedef IcmpSendEcho* lpIcmpSendEcho;


struct CHostTraceSingleReply
{
  DWORD    dwError;  //GetLastError for this replier
	in_addr	 Address;  //The IP address of the replier
	unsigned long RTT; //Round Trip time in milliseconds for this replier
};

struct CHostTraceMultiReply
{
  DWORD    dwError; //GetLastError for this host
	in_addr	 Address; //The IP address of the replier
	DWORD    minRTT;  //Minimum round trip time in milliseconds
  DWORD    avgRTT;  //Average round trip time in milliseconds
  DWORD    maxRTT;  //Maximum round trip time in milliseconds
};

typedef CArray<CHostTraceMultiReply, CHostTraceMultiReply&> CTraceRouteReply;



//The actual class which does the Trace Route

class CTraceRoute 
{
public:
//Methods
  BOOL Trace(LPCTSTR pszHostName, CTraceRouteReply& trr, UCHAR nHopCount = 30, DWORD dwTimeout = 30000, DWORD dwPingsPerHost = 3); 

//Overidables
  virtual BOOL OnPingResult(int nPingNum, const CHostTraceSingleReply& htsr);
  virtual BOOL OnSingleHostResult(int nHostNum, const CHostTraceMultiReply& htmr);

protected:
  BOOL Initialise() const;
  BOOL Ping(unsigned long addr, CHostTraceSingleReply& htsr, UCHAR nTTL, DWORD dwTimeout, UCHAR nPacketSize = 32) const;
	static BOOL sm_bAttemptedIcmpInitialise;
  static lpIcmpCreateFile sm_pIcmpCreateFile;
  static lpIcmpSendEcho sm_pIcmpSendEcho;
  static lpIcmpCloseHandle sm_pIcmpCloseHandle;
};

#endif //__TRACER_H__

