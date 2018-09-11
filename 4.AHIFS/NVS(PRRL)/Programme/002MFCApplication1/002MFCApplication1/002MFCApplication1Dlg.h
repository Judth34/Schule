
// 002MFCApplication1Dlg.h : header file
//

#pragma once
#include "afxwin.h"


// CMy002MFCApplication1Dlg dialog
class CMy002MFCApplication1Dlg : public CDialogEx
{
// Construction
public:
	CMy002MFCApplication1Dlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_MY002MFCAPPLICATION1_DIALOG };
#endif

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	int x1_v;
	CEdit x2_C;
	CString erg;
	afx_msg void OnBnClickedButton1();
	int xpos;
	afx_msg void OnTimer(UINT_PTR nIDEvent);
};
