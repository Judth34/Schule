
// 004AmpelDlg.h : header file
//

#pragma once


// CMy004AmpelDlg dialog
class CMy004AmpelDlg : public CDialogEx
{
// Construction
public:
	CMy004AmpelDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_MY004AMPEL_DIALOG };
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
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	int cnt;
	bool rot_on, gelb_on, gruen_on;
	int dauer_gruen;
	int dauer_rot;
};
