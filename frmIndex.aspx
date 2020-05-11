<%@ Page Language="VB" MasterPageFile="~/AssetInventory.master" AutoEventWireup="false" CodeFile="frmIndex.aspx.vb" Inherits="frmIndex" title="IT Asset Inventory-Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
<div class="container">
    <h2 class="titleIndex">Quick Access</h2>
    <div class="row">
        <div class="col-sm-3 indexElement">
            <asp:hyperlink id="link" runat="server">
               <a href="frmInvoice.aspx"><img src="resources/img/invoice.jpg" alt="Create Invoice" class="indexImg"></img></a>
               <h3 class="text-center"><asp:Label>Create Invoice</asp:Label></h3>
            </asp:hyperlink>
        </div>
        <div class="col-sm-3 indexElement">
            <asp:hyperlink id="Hyperlink1" runat="server">
               <a href="frmAddNew.aspx"><img src="resources/img/addnew.png" alt="Add New" class="indexImg" ></img></a>
               <h3 class="text-center"><asp:Label>Add New</asp:Label></h3>
            </asp:hyperlink>
        </div>
        <div class="col-sm-3 indexElement">
            <asp:hyperlink id="Hyperlink2" runat="server">
               <a href="frmInvoiceReport.aspx"><img src="resources/img/report.png" alt="Reports" class="indexImg" ></img></a>
               <h3 class="text-center"><asp:Label>Reports</asp:Label></h3>
            </asp:hyperlink>
        </div>
    </div>
</div>
</asp:Content>

