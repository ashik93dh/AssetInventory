Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Data.SqlClient
Imports System.Data
Partial Class frmLogIn
    Inherits System.Web.UI.Page
    Dim result As New clsResult()
    Dim login As New clsLogin()
    Dim da As SqlDataAdapter = New SqlDataAdapter()
    Dim ds As DataSet = New DataSet()
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("username") <> "") Then
            Session("username") = ""
        End If
    End Sub
    Private Sub MsgBox(ByVal sMessage As String)
        Dim msg As String
        msg = "<script language='javascript'>"
        msg += "alert('" & sMessage & "');"
        msg += "<" & "/script>"
        Response.Write(msg)
    End Sub
    Protected Sub btnLogIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogIn.Click
        login.UserName = txtUserName.Text
        login.Password = txtPassword.Text
        result = login.fnValidateUsers(login)
        If (result.Success = True) Then
            Session("username") = login.UserName
            Response.Redirect("frmIndex.aspx")
        Else
            System.Web.HttpContext.Current.Session("username") = ""
            MsgBox(result.Message)
            Response.Redirect("frmLogIn.aspx")
        End If
    End Sub
End Class
