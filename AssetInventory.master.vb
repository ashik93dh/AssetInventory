
Partial Class AssetInventory
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("username") = "") Then
            navbarSupportedContent.Visible = False
        Else
            navbarSupportedContent.Visible = True
            lblCurrentUser.Text = "Current user: " + Session("username")
        End If
    End Sub
    Protected Sub lnkLogOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbLogOut.Click
        Session.Abandon()
        Response.Redirect("frmLogIn.aspx")
    End Sub
End Class

