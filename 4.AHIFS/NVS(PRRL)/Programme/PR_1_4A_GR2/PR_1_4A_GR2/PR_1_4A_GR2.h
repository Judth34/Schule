
// PR_1_4A_GR2.h : main header file for the PROJECT_NAME application
//

#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"		// main symbols


// CPR_1_4A_GR2App:
// See PR_1_4A_GR2.cpp for the implementation of this class
//

class CPR_1_4A_GR2App : public CWinApp
{
public:
	CPR_1_4A_GR2App();

// Overrides
public:
	virtual BOOL InitInstance();

// Implementation

	DECLARE_MESSAGE_MAP()
};

extern CPR_1_4A_GR2App theApp;