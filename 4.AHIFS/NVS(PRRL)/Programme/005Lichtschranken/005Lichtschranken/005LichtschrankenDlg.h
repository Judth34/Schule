
// 005LichtschrankenDlg.h : header file
//

#pragma once


// CMy005LichtschrankenDlg dialog
class CMy005LichtschrankenDlg : public CDialogEx
{
// Construction
public:
	CMy005LichtschrankenDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_MY005LICHTSCHRANKEN_DIALOG };
#endif

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedButton1();
	RECT S, IS, LS;
	BOOL S_offen, S_zu;
	BOOL S_oeffnen, S_zumachen;
	BOOL IS_edgeUp, LS_edgeDown;
	CPoint oldpos;
	BOOL inS = false;
	BOOL inIS = false;
	BOOL inLS_old = false;
	BOOL inIS_old = false;
	BOOL inLS = false;

	afx_msg void OnTimer(UINT_PTR nIDEvent);
	afx_msg void OnMouseMove(UINT nFlags, CPoint point);
};
