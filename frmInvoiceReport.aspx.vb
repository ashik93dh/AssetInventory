Imports System.Data.SqlClient
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class frmInvoiceReport
    Inherits System.Web.UI.Page
    Dim Invoice As New clsInvoice
    Dim result As New clsResult
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("username") = "") Then
            Response.Redirect("frmLogIn.aspx")
        End If
        If Not IsPostBack Then
            btnGenerateReport.Visible = False
            btnCancel.Visible = False
            ddlformat.Visible = False
            lblSelectFormat.Visible = False
            pnlInvoiceReport.Visible = False
        End If
        pnlInvoiceReport.ScrollBars = ScrollBars.Vertical
    End Sub
    Protected Sub LoadGrid(ByVal InvoiceNumber As String)
        Try
            Invoice.InvoiceNumber = InvoiceNumber
            grdInvoiceReport.DataSource = Invoice.fnGetAssetByInvoiceNumber(Invoice)
            grdInvoiceReport.DataBind()
            grdInvoiceReport.Columns(0).Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub LoadDropDown()
        Try
            ddlformat.Items.Clear()
            ddlformat.Items.Insert(0, New ListItem("Select", ""))
            ddlformat.Items.Insert(1, New ListItem("Word", "word"))
            ddlformat.Items.Insert(2, New ListItem("PDF", "pdf"))
            ddlformat.Items.Insert(3, New ListItem("Excel", "excel"))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try
            Dim InvoiceNumber As String = txtInvoiceNumber.Text
            LoadGrid(InvoiceNumber)
            If (grdInvoiceReport.Rows.Count <> 0) Then
                lblInvoiceReport.Text = "Invoice Details :" + txtInvoiceNumber.Text
                btnGenerateReport.Visible = True
                btnCancel.Visible = True
                txtInvoiceNumber.Enabled = False
                ddlformat.Visible = True
                pnlInvoiceReport.Visible = True
                lblSelectFormat.Visible = True
                LoadDropDown()
            Else
                lblInvoiceReport.Text = "Invoice Not Found"
                btnGenerateReport.Visible = False
                btnCancel.Visible = False
                ddlformat.Visible = False
                lblSelectFormat.Visible = False
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
    Protected Sub grdInvoiceReport_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdInvoiceReport.SelectedIndexChanged

    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            grdInvoiceReport.DataSource = Nothing
            grdInvoiceReport.DataBind()
            btnGenerateReport.Visible = False
            btnCancel.Visible = False
            txtInvoiceNumber.Enabled = True
            txtInvoiceNumber.Text = ""
            lblInvoiceReport.Text = ""
            ddlformat.Visible = False
            lblSelectFormat.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnGenerateReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerateReport.Click
        Dim myReport As New ReportDocument()
        Dim folder As String
        Dim f As String
        Dim repName As String
        Dim serverName As [String], uid As [String], pwd As [String], dbName As [String]
        Try
            f = "~/reports/"
            folder = Server.MapPath(f)
            repName = folder & "rptInvoiceReport.rpt"
            myReport.Load(repName)
            serverName = "DESKTOP-4HKKRP0\SQLEXPRESS"
            uid = "sa"
            pwd = "Farc1lgh#"
            dbName = "AIDB"
            myReport.SetDatabaseLogon(uid, pwd, serverName, dbName)
            Dim parameters As CrystalDecisions.Web.Parameter = New CrystalDecisions.Web.Parameter()
            myReport.SetParameterValue("@InvoiceNumber", txtInvoiceNumber.Text)
            If (ddlformat.SelectedValue = "pdf") Then
                myReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True, "Invoice Report" & txtInvoiceNumber.Text & Now.Ticks)
            ElseIf (ddlformat.SelectedValue = "word") Then
                myReport.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, True, "Invoice Report" & txtInvoiceNumber.Text & Now.Ticks)
            ElseIf (ddlformat.SelectedValue = "excel") Then
                myReport.ExportToHttpResponse(ExportFormatType.Excel, Response, True, "Invoice Report_" & txtInvoiceNumber.Text & "_" & Now.Ticks)
            ElseIf (ddlformat.SelectedValue = "") Then
                MsgBox("Please select report format")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
