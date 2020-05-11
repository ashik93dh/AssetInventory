Imports System.Data.SqlClient
Imports System.Data
Partial Class frmInvoice
    Inherits System.Web.UI.Page
    Dim Invoice As New clsInvoice()
    Dim Vendor As New clsVendor()
    Dim result As New clsResult()
    Dim da As SqlDataAdapter = New SqlDataAdapter()
    Dim ds As DataSet = New DataSet()
    Dim table As New DataTable

    Private Function generateDatatable() As DataTable
        Try
            table.Columns.Add("InvoiceNumber", GetType(String))
            table.Columns.Add("InvoiceDate", GetType(String))
            table.Columns.Add("InvoiceFile", GetType(String))
            table.Columns.Add("InvoiceAmount", GetType(Double))
            table.Columns.Add("Vendor", GetType(String))
            table.Columns.Add("VendorID", GetType(String))
            table.Columns.Add("EntryBy", GetType(String))
            Return table
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function generateTableRow(ByVal Invoice As clsInvoice, ByVal table As DataTable) As DataTable
        Try
            Dim drNewRow As DataRow
            drNewRow = table.NewRow
            drNewRow.Item("InvoiceNumber") = Invoice.InvoiceNumber
            drNewRow.Item("InvoiceDate") = Invoice.InvoiceDate
            drNewRow.Item("InvoiceFile") = Invoice.InvoiceFile
            drNewRow.Item("InvoiceAmount") = Invoice.InvoiceAmount
            drNewRow.Item("Vendor") = ddlVendor.SelectedItem.Text
            drNewRow.Item("VendorID") = ddlVendor.SelectedItem.Value
            drNewRow.Item("EntryBy") = Invoice.EntryBy
            table.Rows.Add(drNewRow)
            Return table
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Protected Sub grdCreateInvoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCreateInvoice.SelectedIndexChanged
        Dim lblInvoiceNumber, lblInvoiceDate, lblInvoiceFile, lblVendorID, lblEntryBy As Label
        lblInvoiceNumber = grdCreateInvoice.SelectedRow.FindControl("lblInvoiceNumber")
        lblInvoiceDate = grdCreateInvoice.SelectedRow.FindControl("lblInvoiceDate")
        lblInvoiceFile = grdCreateInvoice.SelectedRow.FindControl("lblInvoiceFile")
        Dim InvoiceAmount As Double = Convert.ToDouble(grdCreateInvoice.SelectedRow.FindControl("lblInvoiceAmount"))
        lblVendorID = grdCreateInvoice.SelectedRow.FindControl("lblVendorID")
        lblEntryBy = grdCreateInvoice.SelectedRow.FindControl("lblEntryBy")
    End Sub
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtInvoiceDate.Focus()
        If (Session("username") = "") Then
            Response.Redirect("frmLogIn.aspx")
        End If
        If Not IsPostBack Then
            Session("dttable") = generateDatatable()
            LoadGrid()
            LoadDropDown()
        End If

        pnlCreateInvoice.ScrollBars = ScrollBars.Vertical
    End Sub
    Protected Sub LoadGrid()
        Try
            grdCreateInvoice.DataSource = Invoice.fnGetWaitingInvoice()
            grdCreateInvoice.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub LoadDropDown()
        Try
            ddlVendor.Items.Add(New ListItem("--none--", ""))
            ddlVendor.AppendDataBoundItems = True
            ddlVendor.DataTextField = "VendorName"
            ddlVendor.DataValueField = "VendorID"
            ddlVendor.DataSource = Vendor.fnGetVendor()
            ddlVendor.DataBind()
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
    'Protected Sub clInvoiceDate_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txtInvoiceDate.Text = clInvoiceDate.SelectedDate.ToShortDateString()
    'End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If (formCheck() = True) Then
                Invoice.InvoiceNumber = txtInvoiceNumber.Text
                Invoice.InvoiceAmount = Convert.ToDouble(txtInvoiceAmount.Text)
                Invoice.InvoiceDate = txtInvoiceDate.Text
                Invoice.VendorID = ddlVendor.SelectedValue
                If (FileUploadControl.HasFile) Then
                    Dim folderPath As String = Server.MapPath("~/attachments/")
                    Dim filename As String = System.IO.Path.GetFileName(FileUploadControl.FileName)
                    FileUploadControl.SaveAs(folderPath & filename)
                    Invoice.InvoiceFile = filename
                Else
                    Invoice.InvoiceFile = ""
                End If
                Invoice.EntryBy = Session("username")
                result = Invoice.fnInsertInvoice(Invoice)
                If result.Success = True Then
                    MsgBox(result.Message)
                    LoadGrid()
                Else
                    MsgBox(result.Message)
                End If
                txtInvoiceNumber.Text = ""
                txtInvoiceAmount.Text = ""
                txtInvoiceDate.Text = ""
                FileUploadControl.Attributes.Clear()
                ddlVendor.SelectedIndex = -1
                btnAdd.Enabled = False
            Else
                MsgBox("Please type in all details")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function formCheck() As Boolean
        If (txtInvoiceNumber.Text = "" Or txtInvoiceAmount.Text = "" Or txtInvoiceDate.Text = "" Or FileUploadControl.HasFile = False Or ddlVendor.SelectedIndex = -1) Then
            Return False
        Else
            Return True
        End If
    End Function

    Protected Sub btnAssetPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAssetPage.Click
        Response.Redirect("frmAsset.aspx")
    End Sub
End Class