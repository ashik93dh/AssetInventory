Imports System.Data.SqlClient
Imports System.Data
Partial Class frmApproveInvoice
    Inherits System.Web.UI.Page
    Dim result As New clsResult
    Dim Asset As New clsAsset
    Dim Invoice As New clsInvoice
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("username") = "") Then
            Response.Redirect("frmLogIn.aspx")
        End If
        If Not IsPostBack Then
            LoadGrid_ApprovedInvoice()
            LoadGrid_UnapprovedInvoice()
            If (grdUnapprovedInvoice.Rows.Count = 0) Then
                lblPendingInvoice.Visible = True
                lblPendingInvoice.Text = "No pending invoices"

            Else
                lblPendingInvoice.Visible = False
            End If
            LoadGrid_RejectedInvoice()
            btnApprove.Enabled = False
            btnReject.Enabled = False
        End If
        pnlUnapprovedInvoice.ScrollBars = ScrollBars.Vertical
        pnlApprovedInvoice.ScrollBars = ScrollBars.Vertical
        pnlRejectedInvoice.ScrollBars = ScrollBars.Vertical
        pnlAsset.ScrollBars = ScrollBars.Vertical
    End Sub
    Protected Sub LoadGrid_UnapprovedInvoice()
        Try
            grdUnapprovedInvoice.DataSource = Invoice.fnGetUnapprovedInvoice()
            grdUnapprovedInvoice.DataBind()
            grdUnapprovedInvoice.Columns(0).Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub LoadGrid_AssociatedAsset()
        Try
            grdAsset.DataSource = Invoice.fnGetRejectedInvoice()
            grdAsset.DataBind()
            grdAsset.Columns(0).Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub LoadGrid_ApprovedInvoice()
        Try
            grdApprovedInvoice.DataSource = Invoice.fnGetApprovedInvoice()
            grdApprovedInvoice.DataBind()
            grdApprovedInvoice.Columns(0).Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub LoadGrid_RejectedInvoice()
        Try
            grdRejectedInvoice.DataSource = Invoice.fnGetRejectedInvoice()
            grdRejectedInvoice.DataBind()
            grdRejectedInvoice.Columns(0).Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub grdUnapprovedInvoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdUnapprovedInvoice.SelectedIndexChanged
        Try
            Dim lblVendorName, lblInvoiceID, lblInvoiceNumber, lblInvoiceAmount, lblInvoiceDate As Label
            lblInvoiceID = grdUnapprovedInvoice.SelectedRow.FindControl("lblInvoiceID")
            lblInvoiceNumber = grdUnapprovedInvoice.SelectedRow.FindControl("lblInvoiceNumber")
            lblVendorName = grdUnapprovedInvoice.SelectedRow.FindControl("lblVendorName")
            lblInvoiceAmount = grdUnapprovedInvoice.SelectedRow.FindControl("lblInvoiceAmount")
            lblInvoiceDate = grdUnapprovedInvoice.SelectedRow.FindControl("lblInvoiceDate")
            lblVendor.ForeColor = Drawing.Color.Green
            lblVendor.Text = lblVendorName.Text
            lblAssetInvoiceNumber.ForeColor = Drawing.Color.Green
            lblAssetInvoiceNumber.Text = lblInvoiceNumber.Text
            lblPurchaseDate.ForeColor = Drawing.Color.Green
            lblPurchaseDate.Text = lblInvoiceDate.Text
            lblTotalCost.ForeColor = Drawing.Color.Green
            lblTotalCost.Text = lblInvoiceAmount.Text
            Invoice.InvoiceID = lblInvoiceID.Text
            btnApprove.Enabled = True
            btnReject.Enabled = True
            txtRemarks.Enabled = True
            grdAsset.DataSource = Invoice.fnGetAssetByInvoice(Invoice)
            grdAsset.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub grdApprovedInvoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdApprovedInvoice.SelectedIndexChanged
        Try
            Dim lblVendorName, lblInvoiceID, lblInvoiceNumber, lblInvoiceAmount, lblInvoiceDate As Label
            lblInvoiceID = grdApprovedInvoice.SelectedRow.FindControl("lblInvoiceID")
            lblInvoiceNumber = grdApprovedInvoice.SelectedRow.FindControl("lblInvoiceNumber")
            lblVendorName = grdApprovedInvoice.SelectedRow.FindControl("lblVendorName")
            lblInvoiceAmount = grdApprovedInvoice.SelectedRow.FindControl("lblInvoiceAmount")
            lblInvoiceDate = grdApprovedInvoice.SelectedRow.FindControl("lblInvoiceDate")
            lblVendor.ForeColor = Drawing.Color.Green
            lblVendor.Text = lblVendorName.Text
            lblAssetInvoiceNumber.ForeColor = Drawing.Color.Green
            lblAssetInvoiceNumber.Text = lblInvoiceNumber.Text
            lblPurchaseDate.ForeColor = Drawing.Color.Green
            lblPurchaseDate.Text = lblInvoiceDate.Text
            lblTotalCost.ForeColor = Drawing.Color.Green
            lblTotalCost.Text = lblInvoiceAmount.Text
            Invoice.InvoiceID = lblInvoiceID.Text
            btnApprove.Enabled = False
            btnReject.Enabled = False
            txtRemarks.Enabled = False
            grdAsset.DataSource = Invoice.fnGetAssetByInvoice(Invoice)
            grdAsset.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub grdRejectedInvoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRejectedInvoice.SelectedIndexChanged
        Try
            Dim lblVendorName, lblInvoiceID, lblInvoiceNumber, lblInvoiceAmount, lblInvoiceDate As Label
            lblInvoiceID = grdRejectedInvoice.SelectedRow.FindControl("lblInvoiceID")
            lblInvoiceNumber = grdRejectedInvoice.SelectedRow.FindControl("lblInvoiceNumber")
            lblVendorName = grdRejectedInvoice.SelectedRow.FindControl("lblVendorName")
            lblInvoiceAmount = grdRejectedInvoice.SelectedRow.FindControl("lblInvoiceAmount")
            lblInvoiceDate = grdRejectedInvoice.SelectedRow.FindControl("lblInvoiceDate")
            lblVendor.ForeColor = Drawing.Color.Green
            lblVendor.Text = lblVendorName.Text
            lblAssetInvoiceNumber.ForeColor = Drawing.Color.Green
            lblAssetInvoiceNumber.Text = lblInvoiceNumber.Text
            lblPurchaseDate.ForeColor = Drawing.Color.Green
            lblPurchaseDate.Text = lblInvoiceDate.Text
            lblTotalCost.ForeColor = Drawing.Color.Green
            lblTotalCost.Text = lblInvoiceAmount.Text
            Invoice.InvoiceID = lblInvoiceID.Text
            btnApprove.Enabled = False
            btnReject.Enabled = False
            txtRemarks.Enabled = False
            grdAsset.DataSource = Invoice.fnGetAssetByInvoice(Invoice)
            grdAsset.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        Try
            Dim lblInvoiceID As Label = grdUnapprovedInvoice.SelectedRow.FindControl("lblInvoiceID")
            Invoice.InvoiceID = lblInvoiceID.Text
            Invoice.Remarks = txtRemarks.Text
            Invoice.Action = "A"
            Invoice.EntryBy = Session("username")
            result = Invoice.fnProcessInvoice(Invoice)
            If result.Success = True Then
                MsgBox(result.Message)
                LoadGrid_ApprovedInvoice()
                LoadGrid_UnapprovedInvoice()
                LoadGrid_RejectedInvoice()
            Else
                MsgBox(result.Message)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnReject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReject.Click
        Try
            Dim lblInvoiceID As Label = grdUnapprovedInvoice.SelectedRow.FindControl("lblInvoiceID")
            Invoice.InvoiceID = lblInvoiceID.Text
            Invoice.Remarks = txtRemarks.Text
            Invoice.Action = "R"
            Invoice.EntryBy = Session("username")
            result = Invoice.fnProcessInvoice(Invoice)
            If result.Success = True Then
                MsgBox(result.Message)
                LoadGrid_ApprovedInvoice()
                LoadGrid_UnapprovedInvoice()
                LoadGrid_RejectedInvoice()
            Else
                MsgBox(result.Message)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub MsgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
    Protected Sub grdAsset_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAsset.SelectedIndexChanged

    End Sub
End Class
