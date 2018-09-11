
// 001 First Application.h : main header file for the 001 First Application application
//
#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"       // main symbols


// CMy001FirstApplicationApp:
// See 001 First Application.cpp for the implementation of this class
//

class CMy001FirstApplicationApp : public CWinAppEx
{
public:
	CMy001FirstApplicationApp();


// Overrides
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Implementation
	UINT  m_nAppLook;
	BOOL  m_bHiColorIcons;

	virtual void PreLoadState();
	virtual void LoadCustomState();
	virtual void SaveCustomState();

	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CMy001FirstApplicationApp theApp;
