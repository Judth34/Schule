
// 001 First ApplicationView.cpp : implementation of the CMy001FirstApplicationView class
//

#include "stdafx.h"
// SHARED_HANDLERS can be defined in an ATL project implementing preview, thumbnail
// and search filter handlers and allows sharing of document code with that project.
#ifndef SHARED_HANDLERS
#include "001 First Application.h"
#endif

#include "001 First ApplicationDoc.h"
#include "001 First ApplicationView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CMy001FirstApplicationView

IMPLEMENT_DYNCREATE(CMy001FirstApplicationView, CView)

BEGIN_MESSAGE_MAP(CMy001FirstApplicationView, CView)
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CMy001FirstApplicationView::OnFilePrintPreview)
	ON_WM_CONTEXTMENU()
	ON_WM_RBUTTONUP()
END_MESSAGE_MAP()

// CMy001FirstApplicationView construction/destruction

CMy001FirstApplicationView::CMy001FirstApplicationView()
{
	// TODO: add construction code here

}

CMy001FirstApplicationView::~CMy001FirstApplicationView()
{
}

BOOL CMy001FirstApplicationView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

// CMy001FirstApplicationView drawing

void CMy001FirstApplicationView::OnDraw(CDC* /*pDC*/)
{
	CMy001FirstApplicationDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: add draw code for native data here
}


// CMy001FirstApplicationView printing


void CMy001FirstApplicationView::OnFilePrintPreview()
{
#ifndef SHARED_HANDLERS
	AFXPrintPreview(this);
#endif
}

BOOL CMy001FirstApplicationView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CMy001FirstApplicationView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CMy001FirstApplicationView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

void CMy001FirstApplicationView::OnRButtonUp(UINT /* nFlags */, CPoint point)
{
	ClientToScreen(&point);
	OnContextMenu(this, point);
}

void CMy001FirstApplicationView::OnContextMenu(CWnd* /* pWnd */, CPoint point)
{
#ifndef SHARED_HANDLERS
	theApp.GetContextMenuManager()->ShowPopupMenu(IDR_POPUP_EDIT, point.x, point.y, this, TRUE);
#endif
}


// CMy001FirstApplicationView diagnostics

#ifdef _DEBUG
void CMy001FirstApplicationView::AssertValid() const
{
	CView::AssertValid();
}

void CMy001FirstApplicationView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CMy001FirstApplicationDoc* CMy001FirstApplicationView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CMy001FirstApplicationDoc)));
	return (CMy001FirstApplicationDoc*)m_pDocument;
}
#endif //_DEBUG


// CMy001FirstApplicationView message handlers
