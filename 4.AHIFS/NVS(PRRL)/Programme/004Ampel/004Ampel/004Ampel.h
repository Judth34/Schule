
// 004Ampel.h : main header file for the PROJECT_NAME application
//

#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"		// main symbols


// CMy004AmpelApp:
// See 004Ampel.cpp for the implementation of this class
//

class CMy004AmpelApp : public CWinApp
{
public:
	CMy004AmpelApp();

// Overrides
public:
	virtual BOOL InitInstance();

// Implementation

	DECLARE_MESSAGE_MAP()
};

extern CMy004AmpelApp theApp;