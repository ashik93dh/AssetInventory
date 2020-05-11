Imports System.Data.SqlClient
Imports System.Data
Partial Class frmAsset
    Inherits System.Web.UI.Page
    Dim result As New clsResult
    Dim Asset As New clsAsset
    Dim Invoice As New clsInvoice
    Dim AssetBrand As New clsBrand
    Dim AssetType As New clsAssetType
    Dim AssetModel As New clsModel
    Dim table As New DataTable
    Dim sum As Object
    Protected Sub grdAsset_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAsset.SelectedIndexChanged

    End Sub
    Protected Sub OnRowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs)
        Try
            Dim dt As DataTable = Session("dttable")
            Dim row As Integer = e.RowIndex
            Dim rowAmount As Double = Convert.ToDouble(dt.Rows(row).Item("TotalPrice").ToString())
            dt.Rows.RemoveAt(row)
            dt.AcceptChanges()
            Session("dttable") = dt
            grdAsset.DataSource = Session("dttable")
            grdAsset.DataBind()
            lblTotalAmount.Text = Convert.ToDouble(lblTotalAmount.Text) - rowAmount
            lblAllocationRemaining.Text = Convert.ToDouble(lblAllocationRemaining.Text) + rowAmount
            If (grdAsset.Rows.Count = 0) Then
                btnSubmit.Visible = False
                btnCancel.Visible = False
                pnlAsset.Visible = False
                lblTotalAmount.Visible = False
                lblTotalAmountText.Visible = False
            Else
                btnSubmit.Visible = True
                btnCancel.Visible = True
                pnlAsset.Visible = True
            End If
            If (Convert.ToDouble(lblTotalCost.Text) = Convert.ToDouble(lblTotalAmount.Text)) Then
                btnSubmit.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function generateDatatable() As DataTable
        Try
            table.Columns.Add("AssetType", GetType(String))
            table.Columns.Add("AssetTypeID", GetType(String))
            table.Columns.Add("Brand", GetType(String))
            table.Columns.Add("BrandID", GetType(String))
            table.Columns.Add("Model", GetType(String))
            table.Columns.Add("ModelID", GetType(String))
            table.Columns.Add("Quantity", GetType(Integer))
            table.Columns.Add("InvoiceID", GetType(String))
            table.Columns.Add("UnitPrice", GetType(Double))
            table.Columns.Add("TotalPrice", GetType(Double))
            Return table
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function generateTableRow(ByVal Invoice As clsInvoice, ByVal table As DataTable) As DataTable
        Try
            Dim lblInvoiceID As Label = grdWaitingInvoice.SelectedRow.FindControl("lblInvoiceID")
            Dim lblInvoiceNumber As Label = grdWaitingInvoice.SelectedRow.FindControl("lblInvoiceNumber")
            Dim drNewRow As DataRow
            drNewRow = table.NewRow
            drNewRow.Item("AssetType") = ddlAssetType.SelectedItem.Text
            drNewRow.Item("AssetTypeID") = ddlAssetType.SelectedValue
            drNewRow.Item("BrandID") = ddlBrand.SelectedValue
            drNewRow.Item("Brand") = ddlBrand.SelectedItem.Text
            drNewRow.Item("ModelID") = ddlModel.SelectedValue
            drNewRow.Item("Model") = ddlModel.SelectedItem.Text
            drNewRow.Item("Quantity") = Convert.ToInt32(txtAssetQuantity.Text)
            drNewRow.Item("InvoiceID") = lblInvoiceID.Text
            drNewRow.Item("UnitPrice") = Convert.ToDouble(txtUnitAmount.Text)
            drNewRow.Item("TotalPrice") = Convert.ToDouble(txtUnitAmount.Text) * Convert.ToDouble(txtAssetQuantity.Text)
            table.Rows.Add(drNewRow)
            Return table
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("username") = "") Then
            Response.Redirect("frmLogIn.aspx")
        End If
        If Not IsPostBack Then
            Session("dttable") = generateDatatable()
            LoadGrid_WaitingInvoice()
            If (grdWaitingInvoice.Rows.Count = 0) Then
                lblWaitingInvoice.Visible = True
                lblWaitingInvoice.Text = "Please create an invoice to add asset"
                btnInvoice.Visible = True
            Else
                lblWaitingInvoice.Visible = False
                btnInvoice.Visible = False
            End If
            LoadDropDown_AssetType()
            LoadDropDown_Brand()
            LoadDropDown_Model()
            btnSubmit.Visible = False
            btnSubmit.Enabled = False
            btnCancel.Visible = False
            pnlAsset.Visible = False
            btnAdd.Enabled = False
            lblTotalAmountText.Visible = False
            Session("sum") = 0
            pnlWaitingInvoice.Width = grdWaitingInvoice.Width
            pnlWaitingInvoice.ScrollBars = ScrollBars.Vertical
            pnlAsset.ScrollBars = ScrollBars.Vertical
            lblAllocationRemaining.ForeColor = Drawing.Color.Green

        End If
    End Sub
    Protected Sub LoadGrid_WaitingInvoice()
        Try
            grdWaitingInvoice.DataSource = Invoice.fnGetWaitingInvoice()
            grdWaitingInvoice.DataBind()
            grdWaitingInvoice.Columns(0).Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub LoadDropDown_Brand()
        Try
            ddlBrand.Items.Add(New ListItem("--none--", ""))
            ddlBrand.AppendDataBoundItems = True
            ddlBrand.DataTextField = "BrandName"
            ddlBrand.DataValueField = "BrandID"
            ddlBrand.DataSource = AssetBrand.fnGetBrand()
            ddlBrand.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub LoadDropDown_Model()
        Try
            ddlModel.Items.Add(New ListItem("--none--", ""))
            ddlModel.AppendDataBoundItems = True
            ddlModel.DataTextField = "ModelName"
            ddlModel.DataValueField = "ModelID"
            ddlModel.DataSource = AssetModel.fnGetModel()
            ddlModel.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub LoadDropDown_AssetType()
        Try
            ddlAssetType.Items.Add(New ListItem("--none--", ""))
            ddlAssetType.AppendDataBoundItems = True
            ddlAssetType.DataTextField = "AssetType"
            ddlAssetType.DataValueField = "AssetTypeID"
            ddlAssetType.DataSource = AssetType.fnGetAssetType()
            ddlAssetType.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Dim lblInvoiceAmount As Label = grdWaitingInvoice.SelectedRow.FindControl("lblInvoiceAmount")
            If (btnSubmit.Visible = False) Then
                btnSubmit.Visible = True
            End If
            If (btnCancel.Visible = False) Then
                btnCancel.Visible = True
            End If
            If (lblTotalAmountText.Visible = False) Then
                lblTotalAmountText.Visible = True
            End If
            If (lblTotalAmount.Visible = False) Then
                lblTotalAmount.Visible = True
            End If
            Dim unitprice As Double = Convert.ToDouble(txtUnitAmount.Text) * Convert.ToDouble(txtAssetQuantity.Text)
            If (unitprice <= Convert.ToDouble(lblAllocationRemaining.Text)) Then
                table = generateTableRow(Invoice, Session("dttable"))
                Session("dttable") = table
                grdAsset.DataSource = Session("dttable")
                grdAsset.DataBind()
                sum = table.Compute("SUM(TotalPrice)", "")
                Session("sum") = sum
                lblTotalAmount.Text = sum.ToString()
                lblAllocationRemaining.Text = Convert.ToDouble(lblInvoiceAmount.Text) - Convert.ToDouble(lblTotalAmount.Text)
                txtAssetQuantity.Text = ""
                ddlAssetType.SelectedIndex = -1
                ddlBrand.SelectedIndex = -1
                ddlModel.SelectedIndex = -1
                txtUnitAmount.Text = ""
                btnSubmit.Enabled = False
                If (grdAsset.Rows.Count = 0) Then
                    btnSubmit.Visible = False
                    btnCancel.Visible = False
                    pnlAsset.Visible = False
                Else
                    btnSubmit.Visible = True
                    btnCancel.Visible = True
                    pnlAsset.Visible = True
                End If
            Else
                MsgBox("Allocated Amount Reached")
                txtAssetQuantity.Text = ""
                ddlAssetType.SelectedIndex = -1
                ddlBrand.SelectedIndex = -1
                ddlModel.SelectedIndex = -1
                txtUnitAmount.Text = ""
            End If
            If (Convert.ToDouble(lblTotalCost.Text) = Convert.ToDouble(lblTotalAmount.Text)) Then
                btnSubmit.Enabled = True
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
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try
            Dim rowCount As Integer = 0
            For Each row As GridViewRow In grdAsset.Rows
                If (Convert.ToDouble(lblAllocationRemaining.Text) = 0) Then
                    Dim Quantity As Integer = Convert.ToInt32(TryCast(row.FindControl("lblQuantity"), Label).Text)
                    Dim i As Integer
                    For i = 1 To Quantity
                        Asset.AssetTypeID = TryCast(row.FindControl("lblAssetTypeID"), Label).Text
                        Asset.BrandID = TryCast(row.FindControl("lblBrandID"), Label).Text
                        Asset.ModelID = TryCast(row.FindControl("lblModelID"), Label).Text
                        Asset.UnitAmount = TryCast(row.FindControl("lblUnitPrice"), Label).Text
                        Asset.InvoiceID = TryCast(row.FindControl("lblInvoiceID"), Label).Text
                        Asset.EntryBy = Session("username")
                        result = Asset.fnInsertAsset(Asset)
                        If result.Success = True Then

                        Else
                            MsgBox(result.Message)
                        End If
                    Next
                    rowCount += 1
                Else
                    MsgBox("Allocation Not Completed")
                End If
            Next
            If (rowCount = grdAsset.Rows.Count) Then
                MsgBox(result.Message)
                LoadGrid_WaitingInvoice()
                Session("dttable") = generateDatatable()
                grdAsset.DataSource = Nothing
                grdAsset.DataBind()
                lblTotalAmount.Text = 0
                lblTotalAmount.Visible = False
                lblTotalAmountText.Visible = False
                btnSubmit.Visible = False
                btnCancel.Visible = False
                lblVendor.Text = ""
                lblWaitingInvoiceNumber.Text = ""
                lblPurchaseDate.Text = ""
                lblTotalCost.Text = ""
                lblAllocationRemaining.Text = ""
                pnlAsset.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Dim lblInvoiceAmount As Label = grdWaitingInvoice.SelectedRow.FindControl("lblInvoiceAmount")
            Session("dttable") = generateDatatable()
            grdAsset.DataSource = Nothing
            grdAsset.DataBind()
            lblAllocationRemaining.Text = lblInvoiceAmount.Text
            lblTotalAmount.Text = 0
            lblTotalAmount.Visible = False
            lblTotalAmountText.Visible = False
            btnSubmit.Visible = False
            btnCancel.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub grdWaitingInvoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdWaitingInvoice.SelectedIndexChanged
        Dim lblVendorName, lblInvoiceID, lblInvoiceNumber, lblInvoiceAmount, lblInvoiceDate As Label
        lblInvoiceID = grdWaitingInvoice.SelectedRow.FindControl("lblInvoiceID")
        lblInvoiceNumber = grdWaitingInvoice.SelectedRow.FindControl("lblInvoiceNumber")
        lblVendorName = grdWaitingInvoice.SelectedRow.FindControl("lblVendorName")
        lblInvoiceAmount = grdWaitingInvoice.SelectedRow.FindControl("lblInvoiceAmount")
        lblInvoiceDate = grdWaitingInvoice.SelectedRow.FindControl("lblInvoiceDate")
        lblVendor.ForeColor = Drawing.Color.Green
        lblVendor.Text = lblVendorName.Text
        lblWaitingInvoiceNumber.ForeColor = Drawing.Color.Green
        lblWaitingInvoiceNumber.Text = lblInvoiceNumber.Text
        lblPurchaseDate.ForeColor = Drawing.Color.Green
        lblPurchaseDate.Text = lblInvoiceDate.Text
        lblTotalCost.ForeColor = Drawing.Color.Green
        lblTotalCost.Text = lblInvoiceAmount.Text
        lblAllocationRemaining.Text = lblInvoiceAmount.Text
        btnAdd.Enabled = True
    End Sub
    Protected Sub btnInvoice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInvoice.Click
        Response.Redirect("frmInvoice.aspx")
    End Sub
End Class
