
// 004AmpelDlg.cpp : implementation file
//

#include "stdafx.h"
#include "004Ampel.h"
#include "004AmpelDlg.h"
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


// CMy004AmpelDlg dialog



CMy004AmpelDlg::CMy004AmpelDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(IDD_MY004AMPEL_DIALOG, pParent)
	, dauer_gruen(0)
	, dauer_rot(0)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CMy004AmpelDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_EDIT2, dauer_gruen);
	DDX_Text(pDX, IDC_EDIT1, dauer_rot);
}

BEGIN_MESSAGE_MAP(CMy004AmpelDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_WM_TIMER()
END_MESSAGE_MAP()


// CMy004AmpelDlg message handlers

BOOL CMy004AmpelDlg::OnInitDialog()
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
	SetTimer(3, 500, NULL);
	cnt = 0;
	rot_on = false;
	gelb_on = false;
	gruen_on = false;

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CMy004AmpelDlg::OnSysCommand(UINT nID, LPARAM lParam)
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

void CMy004AmpelDlg::OnPaint()
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
		CPaintDC dc(this); // Zeichneblatt erzeugen
		CBrush rot = (RGB(255, 0, 0));
		CBrush gelb = (RGB(255, 255, 0));
		CBrush gruen = (RGB(0, 255, 0));
		CBrush white = (RGB(255, 255, 255));

		if (rot_on) {
			dc.SelectObject(rot);
		}
		else
			dc.SelectObject(white);

		dc.Ellipse(10, 10, 110, 110);			//Kreis zeichnen

		if (gelb_on) {
			dc.SelectObject(gelb);
		}
		else
			dc.SelectObject(white);
		dc.Ellipse(10, 120, 110, 220);

		if (gruen_on) {
			dc.SelectObject(gruen);
		}
		else
			dc.SelectObject(white);
		dc.Ellipse(10, 230, 110, 330);
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CMy004AmpelDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}



void CMy004AmpelDlg::OnTimer(UINT_PTR nIDEvent)
{
	// TODO: Add your message handler code here and/or call defaulta
	if (nIDEvent == 3) {
		cnt++;
		UpdateData(true);
		if (cnt > dauer_rot + 8 + dauer_gruen + 6) cnt = 0;
		rot_on = false;
		gelb_on = false;
		gruen_on = false;
		if (cnt >= 0 && cnt <= dauer_rot + 8) rot_on = true;
		if (cnt > dauer_rot && cnt <= dauer_rot + 8) gelb_on = true;
		if (cnt > dauer_rot + 8 && cnt < dauer_rot + 8 + dauer_gruen) gruen_on = true;
		Invalidate(true);		//Onpaint aufrufen, damit Fenster neu gezeichnet wird
		UpdateData(false);
	}
	CDialogEx::OnTimer(nIDEvent);
}
