<%@ Page Language="VB" MasterPageFile="~/AssetInventory.master" AutoEventWireup="false" CodeFile="frmAddNew.aspx.vb" Inherits="frmAddNew" title="Add New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
<div class="container">
    <h2 class="titleIndex">Add New</h2>
    <div class="row">
        <div class="col-sm-3 indexElement">
            <asp:hyperlink id="Hyperlink1" runat="server">
               <a href="frmAssetType.aspx"><img src="resources/img/asset.png" alt="Add Asset Type" class="indexImg" ></img></a>
               <h3 class="text-center"><asp:Label>Asset Type</asp:Label></h3>
            </asp:hyperlink>
        </div>
        <div class="col-sm-3 indexElement">
            <asp:hyperlink id="Hyperlink2" runat="server">
               <a href="frmBrand.aspx"><img src="resources/img/brand.png" alt="Add Brand" class="indexImg"></img></a>
               <h3 class="text-center"><asp:Label>Brand</asp:Label></h3>
            </asp:hyperlink>
        </div>
        <div class="col-sm-3 indexElement">
            <asp:hyperlink id="Hyperlink3" runat="server">
               <a href="frmModel.aspx"><img src="resources/img/model.png" alt="Add Model" class="indexImg" ></img></a>
               <h3 class="text-center"><asp:Label>Model</asp:Label></h3>
            </asp:hyperlink>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3 indexElement">
            <asp:hyperlink id="link" runat="server">
               <a href="frmVendor.aspx"><img src="resources/img/vendor.png" alt="Add Vendor" class="indexImg"></img></a>
               <h3 class="text-center"><asp:Label>Add Vendor</asp:Label></h3>
            </asp:hyperlink>
        </div>
    </div>
</div>
</asp:Content>

