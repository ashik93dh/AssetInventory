Imports System.Data.SqlClient
Imports System.Data
Partial Class frmBrand
    Inherits System.Web.UI.Page
    Dim Brand As New clsBrand
    Dim result As New clsResult
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("username") = "") Then
            Response.Redirect("frmLogIn.aspx")
        End If
        If Not IsPostBack Then
            LoadGrid()
        End If
        pnlBrand.ScrollBars = ScrollBars.Vertical
        btnUpdate.Visible = False
    End Sub
    Private Sub MsgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If (txtBrandName.Text <> "") Then
                Brand.BrandName = txtBrandName.Text
                Brand.EntryBy = Session("username")
                result = Brand.fnInsertBrand(Brand)
                If result.Success = True Then
                    MsgBox(result.Message)
                    txtBrandName.Text = ""
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
    Protected Sub LoadGrid()
        Try
            grdBrand.DataSource = Brand.fnGetBrand()
            grdBrand.DataBind()
            grdBrand.Columns(0).Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub grdBrand_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBrand.SelectedIndexChanged
        Dim lblBrandID, lblBrandName As Label
        lblBrandID = grdBrand.SelectedRow.FindControl("lblBrandID")
        lblBrandName = grdBrand.SelectedRow.FindControl("lblBrandName")
        txtBrandName.Text = lblBrandName.Text
        btnUpdate.Visible = True
    End Sub
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            Dim lblBrandID As Label = grdBrand.SelectedRow.FindControl("lblBrandID")
            If (lblBrandID.Text = "") Then
                MsgBox("Nothing is Selected")
            Else
                Brand.BrandID = lblBrandID.Text
            End If
            If (txtBrandName.Text <> "") Then
                Brand.BrandName = txtBrandName.Text
                Brand.EntryBy = Session("username")
                result = Brand.fnUpdateBrand(Brand)
                If result.Success = True Then
                    MsgBox(result.Message)
                    txtBrandName.Text = ""
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
End Class
