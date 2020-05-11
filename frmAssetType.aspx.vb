Imports System.Data.SqlClient
Imports System.Data
Partial Class frmAssetType
    Inherits System.Web.UI.Page
    Dim AssetType As New clsAssetType
    Dim result As New clsResult
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("username") = "") Then
            Response.Redirect("frmLogIn.aspx")
        End If
        If Not IsPostBack Then
            LoadGrid()
        End If
        pnlAssetType.ScrollBars = ScrollBars.Vertical
        btnUpdate.Visible = False
    End Sub
    Protected Sub grdAssetType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAssetType.SelectedIndexChanged
        Dim lblAssetTypeID, lblAssetType As Label
        lblAssetTypeID = grdAssetType.SelectedRow.FindControl("lblAssetTypeID")
        lblAssetType = grdAssetType.SelectedRow.FindControl("lblAssetType")
        txtAssetType.Text = lblAssetType.Text
        btnUpdate.Visible = True
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If (txtAssetType.Text <> "") Then
                AssetType.AssetType = txtAssetType.Text
                AssetType.EntryBy = Session("username")
                result = AssetType.fnInsertAssetType(AssetType)
                If result.Success = True Then
                    MsgBox(result.Message)
                    txtAssetType.Text = ""
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
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            Dim lblAssetTypeID As Label = grdAssetType.SelectedRow.FindControl("lblAssetTypeID")
            If (lblAssetTypeID.Text = "") Then
                MsgBox("Nothing is Selected")
            Else
                AssetType.AssetTypeID = lblAssetTypeID.Text
            End If
            If (txtAssetType.Text <> "") Then
                AssetType.AssetType = txtAssetType.Text
                AssetType.EntryBy = Session("username")
                result = AssetType.fnUpdateAssetType(AssetType)
                If result.Success = True Then
                    MsgBox(result.Message)
                    txtAssetType.Text = ""
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
            grdAssetType.DataSource = AssetType.fnGetAssetType()
            grdAssetType.DataBind()
            grdAssetType.Columns(0).Visible = True
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
End Class
