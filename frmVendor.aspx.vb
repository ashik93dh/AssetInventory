Imports System.Data.SqlClient
Imports System.Data
Partial Class frmVendor
    Inherits System.Web.UI.Page
    Dim Vendor As New clsVendor()
    Dim result As New clsResult()
    Dim da As SqlDataAdapter = New SqlDataAdapter()
    Dim ds As DataSet = New DataSet()
    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try
            If (formCheck() = True) Then
                Vendor.VendorName = txtVendorName.Text
                Vendor.VendorAddress = txtVendorAddress.Text
                Vendor.ContactPerson = txtContactPerson.Text
                Vendor.ContactNo = txtContactNo.Text
                Vendor.EntryBy = Session("username")
                result = Vendor.fnInsertVendor(Vendor)
                If result.Success = True Then
                    MsgBox(result.Message)
                    txtVendorName.Text = ""
                    txtVendorAddress.Text = ""
                    txtContactPerson.Text = ""
                    txtContactNo.Text = ""
                    LoadGrid()
                Else
                    MsgBox(result.Message)
                End If
            Else
                MsgBox("Please type in all details")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("username") = "") Then
            Response.Redirect("frmLogIn.aspx")
        End If
        If Not IsPostBack Then
            LoadGrid()
        End If
        pnlVendor.ScrollBars = ScrollBars.Vertical
        pnlVendor.Width = grdVendor.Width
        btnUpdate.Visible = False
    End Sub
    Private Sub MsgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
    Protected Sub LoadGrid()
        Try
            grdVendor.DataSource = Vendor.fnGetVendor()
            grdVendor.DataBind()
            grdVendor.Columns(0).Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub grdVendor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdVendor.SelectedIndexChanged
        Dim lblVendorID, lblVendorName, lblVendorAddress, lblContactPerson, lblContactNo As Label
        lblVendorID = grdVendor.SelectedRow.FindControl("lblVendorID")
        lblVendorName = grdVendor.SelectedRow.FindControl("lblVendorName")
        lblVendorAddress = grdVendor.SelectedRow.FindControl("lblVendorAddress")
        lblContactPerson = grdVendor.SelectedRow.FindControl("lblContactPerson")
        lblContactNo = grdVendor.SelectedRow.FindControl("lblContactNo")
        txtVendorName.Text = lblVendorName.Text
        txtVendorAddress.Text = lblVendorAddress.Text
        txtContactPerson.Text = lblContactPerson.Text
        txtContactNo.Text = lblContactNo.Text
        btnUpdate.Visible = True
    End Sub
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim lblVendorID As Label = grdVendor.SelectedRow.FindControl("lblVendorID")
        If (lblVendorID.Text = "") Then
            MsgBox("Nothing is selected")
        Else
            Vendor.VendorID = lblVendorID.Text
            Vendor.VendorName = txtVendorName.Text
            Vendor.VendorAddress = txtVendorAddress.Text
            Vendor.ContactPerson = txtContactPerson.Text
            Vendor.ContactNo = txtContactNo.Text
            Vendor.EntryBy = Session("username")
            result = Vendor.fnUpdateVendor(Vendor)
            If result.Success = True Then
                MsgBox(result.Message)
                txtVendorName.Text = ""
                txtVendorAddress.Text = ""
                txtContactPerson.Text = ""
                txtContactNo.Text = ""
                LoadGrid()
            Else
                MsgBox(result.Message)
            End If
        End If
    End Sub
    Public Function formCheck() As Boolean
        If (txtVendorName.Text = "" Or txtVendorAddress.Text = "" Or txtContactPerson.Text = "" Or txtContactNo.Text = "") Then
            Return False
        Else
            Return True
        End If
    End Function
End Class