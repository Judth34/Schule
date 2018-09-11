
// 005LichtschrankenDlg.cpp : implementation file
//

#include "stdafx.h"
#include "005Lichtschranken.h"
#include "005LichtschrankenDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CAboutDlg dialog used for App About

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

// Dialog Data
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_ABOUTBOX };
#endif

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialogEx(IDD_ABOUTBOX)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)
END_MESSAGE_MAP()


// CMy005LichtschrankenDlg dialog



CMy005LichtschrankenDlg::CMy005LichtschrankenDlg(CWnd* pParent /*=NULL*/)
	:CDialogEx(IDD_MY005LICHTSCHRANKEN_DIALOG, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CMy005LichtschrankenDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CMy005LichtschrankenDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON1, &CMy005LichtschrankenDlg::OnBnClickedButton1)
	ON_WM_TIMER()
	ON_WM_MOUSEMOVE()
END_MESSAGE_MAP()


// CMy005LichtschrankenDlg message handlers

BOOL CMy005LichtschrankenDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		BOOL bNameValid;
		CString strAboutMenu;
		bNameValid = strAboutMenu.LoadString(IDS_ABOUTBOX);
		ASSERT(bNameValid);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here
	//Koordinaten der gezeichneten Elemente festlegen
	LS.bottom = 300;
	LS.left = 300; 
	LS.top = LS.bottom + 100;
	LS.right = LS.left + 100;

	IS.bottom = LS.bottom;
	IS.left = LS.left + 120;
	IS.top = LS.top;
	IS.right = IS.left + 400;

	S.bottom = LS.top - 120; 
	S.left = LS.left;
	S.top = S.bottom - 100;
	S.right = S.left + 100;

	S_oeffnen = false;

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CMy005LichtschrankenDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialogEx::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CMy005LichtschrankenDlg::OnPaint()
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
		dc.Rectangle(S.left, S.top, S.right, S.bottom);
		dc.Rectangle(LS.left, LS.top, LS.right, LS.bottom);
		dc.Rectangle(IS.left, IS.top, IS.right, IS.bottom);
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CMy005LichtschrankenDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}



void CMy005LichtschrankenDlg::OnBnClickedButton1()
{
	if (!S_oeffnen) {
		SetTimer(10, 20, NULL);
		S_oeffnen = true;
	}
}


void CMy005LichtschrankenDlg::OnTimer(UINT_PTR nIDEvent)
{
	// TODO: Add your message handler code here and/or call default
	if (nIDEvent == 10) {
		S.top--;
		S.bottom--;
		if (S.top < 10) {
			S_oeffnen = true;
			KillTimer(10);
		}
		Invalidate();
	}

	CDialogEx::OnTimer(nIDEvent);
}


void CMy005LichtschrankenDlg::OnMouseMove(UINT nFlags, CPoint point)
{
	// TODO: Add your message handler code here and/or call default
	inS = false; 
	LS_edgeDown = false;
	if (point.x > LS.left && point.x <= LS.right && point.y >= LS.bottom && point.y <= LS.top) inLS = true;

	if (!inIS && !inLS_old) LS_edgeDown = true;
	inIS_old = inLS;
	if (LS_edgeDown && S_offen) {
		if (!S_zumachen) {
			SetTimer(20, 20, NULL);
			S_zumachen = true;
		}
	}
	CDialogEx::OnMouseMove(nFlags, point);
}
