Imports System.Data.SqlClient
Imports System.Data
Partial Class frmModel
    Inherits System.Web.UI.Page
    Dim result As New clsResult
    Dim Model As New clsModel
    Dim Brand As New clsBrand
    Protected Sub grdModel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdModel.SelectedIndexChanged
        Dim lblBrandID, lblModelName, lblModelID As Label
        lblModelID = grdModel.SelectedRow.FindControl("lblModelID")
        lblBrandID = grdModel.SelectedRow.FindControl("lblBrandID")
        lblModelName = grdModel.SelectedRow.FindControl("lblModelName")
        txtModelName.Text = lblModelName.Text
        ddlModelBrand.SelectedValue = lblBrandID.Text
        btnUpdate.Visible = True
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("username") = "") Then
            Response.Redirect("frmLogIn.aspx")
        End If
        If Not IsPostBack Then
            LoadGrid()
            LoadDropDown()
        End If
        pnlModel.ScrollBars = ScrollBars.Vertical
        btnUpdate.Visible = False
    End Sub
    Protected Sub LoadGrid()
        Try
            grdModel.DataSource = Model.fnGetBrandModel()
            grdModel.DataBind()
            grdModel.Columns(0).Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub LoadDropDown()
        Try
            ddlModelBrand.Items.Add(New ListItem("--none--", ""))
            ddlModelBrand.AppendDataBoundItems = True
            ddlModelBrand.DataTextField = "BrandName"
            ddlModelBrand.DataValueField = "BrandID"
            ddlModelBrand.DataSource = Brand.fnGetBrand()
            ddlModelBrand.DataBind()
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
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If (txtModelName.Text = "" Or ddlModelBrand.SelectedIndex = -1) Then
                MsgBox("Please provide all details")
            Else
                Model.ModelName = txtModelName.Text
                Model.BrandID = ddlModelBrand.SelectedValue
                Model.EntryBy = Session("username")
                result = Model.fnInsertModel(Model)
                If result.Success = True Then
                    MsgBox(result.Message)
                    txtModelName.Text = ""
                    ddlModelBrand.SelectedIndex = -1
                    LoadGrid()
                Else
                    MsgBox(result.Message)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            Dim lblModelID As Label = grdModel.SelectedRow.FindControl("lblModelID")
            If (lblModelID.Text = "") Then
                MsgBox("Nothing is Selected")
            Else
                Model.ModelID = lblModelID.Text
            End If
            If (txtModelName.Text = "" Or ddlModelBrand.SelectedIndex = -1) Then
                MsgBox("Please provide all details")
            Else
                Model.BrandID = ddlModelBrand.SelectedValue
                Model.ModelName = txtModelName.Text
                Model.EntryBy = Session("username")
                result = Model.fnUpdateModel(Model)
                If result.Success = True Then
                    MsgBox(result.Message)
                    txtModelName.Text = ""
                    ddlModelBrand.SelectedIndex = -1
                    LoadGrid()
                Else
                    MsgBox(result.Message)
                End If
            End If
            
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
