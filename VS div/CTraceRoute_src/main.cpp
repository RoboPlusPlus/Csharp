#include "stdafx.h"
#include "tracer.h"

//Global variable used to determine whether addresses should be resolved
BOOL g_bResolveAddresses;


//Class derived to implement Trace Route
class CMyTraceRoute : public CTraceRoute
{
  virtual BOOL OnSingleHostResult(int nHostNum, const CHostTraceMultiReply& htmr);
};

BOOL CMyTraceRoute::OnSingleHostResult(int nHostNum, const CHostTraceMultiReply& htmr)
{
  if (htmr.dwError == 0)
  {
    hostent* phostent = NULL;
    if (g_bResolveAddresses)
      phostent = gethostbyaddr((char *)&htmr.Address.S_un.S_addr, 4, PF_INET);

    if (phostent)
	    _tprintf(_T("  %d\t%d ms\t%d ms\t%d ms\t%s [%d.%d.%d.%d]\n"), nHostNum, htmr.minRTT, htmr.avgRTT, 
               htmr.maxRTT, phostent->h_name, htmr.Address.S_un.S_un_b.s_b1, htmr.Address.S_un.S_un_b.s_b2, 
               htmr.Address.S_un.S_un_b.s_b3, htmr.Address.S_un.S_un_b.s_b4);
    else
	    _tprintf(_T("  %d\t%d ms\t%d ms\t%d ms\t%d.%d.%d.%d\n"), nHostNum, htmr.minRTT, htmr.avgRTT, htmr.maxRTT,
               htmr.Address.S_un.S_un_b.s_b1, htmr.Address.S_un.S_un_b.s_b2, htmr.Address.S_un.S_un_b.s_b3, 
		  		     htmr.Address.S_un.S_un_b.s_b4);
  }
  else
    _tprintf(_T("  %d\t*\t*\t*\tError:%d\n"), nHostNum, htmr.dwError);

  return TRUE;
}



//Good old void main
#ifdef _UNICODE
void wmain(int argc, wchar_t *argv[])
#else
void main(int argc, char *argv[])
#endif
{
  //Set the default values 
  g_bResolveAddresses = TRUE;
  UCHAR nHops = 30;
  DWORD dwTimeout = 30000;
  int nPings = 3;

  //Validate the command line parameters
	if (argc < 2)
	{
		_tprintf(_T("TRACER target_name [-d] [-h:Hopcount] [-w:timeout] [-p:pingcount]\n\n"));
    _tprintf(_T("Options:\n"));
    _tprintf(_T("  -d               Do not resolve addresses to hostnames.\n"));
    _tprintf(_T("  -h:maximum_hops  Maximum number of hops to search for target.\n"));
    _tprintf(_T("  -w:timeout       Wait timeout milliseconds for each reply.\n"));
    _tprintf(_T("  -p:pingcount     The number of pings per host.\n"));
		return;
	}

  //parse out the other command line options if any
  for (int i=1; i<argc; i++)
  {
    if ((_tcsicmp(argv[i], _T("-d")) == 0) || (_tcsicmp(argv[i], _T("/d")) == 0))
      g_bResolveAddresses = FALSE;
    else if ((_tcsncmp(argv[i], _T("-h"), 2) == 0) || (_tcsncmp(argv[i], _T("/h"), 2) == 0))
    {
      if (_tcslen(argv[i]) > 3)
        nHops = (UCHAR) _ttoi(argv[i] + sizeof(TCHAR)*3);
    }
    else if ((_tcsncmp(argv[i], _T("-w"), 2) == 0) || (_tcsncmp(argv[i], _T("/w"), 2) == 0))
    {
      if (_tcslen(argv[i]) > 3)
        dwTimeout = (DWORD) _ttoi(argv[i] + sizeof(TCHAR)*3);
    }
    else if ((_tcsncmp(argv[i], _T("-p"), 2) == 0) || (_tcsncmp(argv[i], _T("/p"), 2) == 0))
    {
      if (_tcslen(argv[i]) > 3)
        nPings = _ttoi(argv[i] + sizeof(TCHAR)*3);
    }
  }

  //Print the intro comment
  _tprintf(_T("\nTracing route to %s\nover a maximum of %d hops:\n\n"), argv[1], nHops);

  //Do the actual trace route
  CTraceRouteReply trr;
  CMyTraceRoute tr;
  if (tr.Trace(argv[1], trr, nHops, dwTimeout, nPings))
    _tprintf(_T("\nTrace complete.\n"));
	else
	  _tprintf(_T("Failed in call to tracer, GetLastError returns: %d"), GetLastError());
}
