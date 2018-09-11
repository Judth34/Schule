
// 002MFCApplication1.h : main header file for the PROJECT_NAME application
//

#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"		// main symbols


// CMy002MFCApplication1App:
// See 002MFCApplication1.cpp for the implementation of this class
//

class CMy002MFCApplication1App : public CWinApp
{
public:
	CMy002MFCApplication1App();

// Overrides
public:
	virtual BOOL InitInstance();

// Implementation

	DECLARE_MESSAGE_MAP()
};

extern CMy002MFCApplication1App theApp;