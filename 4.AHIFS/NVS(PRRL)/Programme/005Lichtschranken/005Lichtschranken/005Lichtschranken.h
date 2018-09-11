
// 005Lichtschranken.h : main header file for the PROJECT_NAME application
//

#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"		// main symbols


// CMy005LichtschrankenApp:
// See 005Lichtschranken.cpp for the implementation of this class
//

class CMy005LichtschrankenApp : public CWinApp
{
public:
	CMy005LichtschrankenApp();

// Overrides
public:
	virtual BOOL InitInstance();

// Implementation

	DECLARE_MESSAGE_MAP()
};

extern CMy005LichtschrankenApp theApp;