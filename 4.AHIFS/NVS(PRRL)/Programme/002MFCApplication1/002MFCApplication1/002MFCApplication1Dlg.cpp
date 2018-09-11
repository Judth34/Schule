
// 002MFCApplication1Dlg.cpp : implementation file
//

#include "stdafx.h"
#include "002MFCApplication1.h"
#include "002MFCApplication1Dlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CMy002MFCApplication1Dlg dialog



CMy002MFCApplication1Dlg::CMy002MFCApplication1Dlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(IDD_MY002MFCAPPLICATION1_DIALOG, pParent)
	, x1_v(0)
	, erg(_T(""))
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CMy002MFCApplication1Dlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_EDIT1, x1_v);
	DDX_Control(pDX, IDC_EDIT3, x2_C);
	DDX_Text(pDX, IDC_EDIT2, erg);
}

BEGIN_MESSAGE_MAP(CMy002MFCApplication1Dlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON1, &CMy002MFCApplication1Dlg::OnBnClickedButton1)
	ON_WM_TIMER()
END_MESSAGE_MAP()


// CMy002MFCApplication1Dlg message handlers

BOOL CMy002MFCApplication1Dlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here
	xpos = 0;
	SetTimer(100, 200, NULL);
	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CMy002MFCApplication1Dlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CPaintDC dc(this);
		dc.Rectangle(1, 10, 20, 20);
		dc.Rectangle(100, 10, 120, 20);
		dc.Rectangle(xpos , 0, xpos + 10, 10);
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CMy002MFCApplication1Dlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}



void CMy002MFCApplication1Dlg::OnBnClickedButton1()
{
	// TODO: Add your control notification handler code here
	CString x2;
	int ergebnis;
	char x[100];
	UpdateData(true);	//Achtung Grafik einfrieren --> Daten werden jetzt verändert
	x2_C.GetWindowTextW(x2);
	ergebnis = x1_v + atoi((char *)(LPCTSTR) x2);
	sprintf_s(x, "%d", x1_v + atoi((char *)(LPCTSTR)x2));
	erg = (CString)x;
	UpdateData(false);
}

void CMy002MFCApplication1Dlg::OnTimer(UINT_PTR nIDEvent)
{
	// TODO: Add your message handler code here and/or call default
	if (nIDEvent == 100)
	{
		xpos++;
		if (xpos > 100) xpos = 0;
		Invalidate(true);
	}
	CDialogEx::OnTimer(nIDEvent);
}