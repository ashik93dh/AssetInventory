<%@ Page Language="VB" MasterPageFile="~/AssetInventory.master" AutoEventWireup="false" CodeFile="frmAssetType.aspx.vb" Inherits="frmAssetType" title="Add Asset Type" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add AssetType</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container ">
       
       <div class="row assetForm">
            <div class="container ">
                <div class="row">
                    <h3 class="assetFormTitle">Add Asset Type</h3>
               </div>
               <div class="row">
                    <div class="col-sm-6">
                        <label for="InvoiceName" class="col-sm-2 col-form-label">Type</label>
                        <asp:TextBox type="text" class="form-control" ID="txtAssetType" placeholder="Enter Asset Type" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="txtAssetType"  ValidationGroup="addAssetType" errormessage="Please enter asset type." />
                        <asp:RegularExpressionValidator ID="revAssetType" runat="server" ControlToValidate="txtAssetType"  ValidationGroup="addAssetType" ValidationExpression="^[a-zA-Z ]{1,20}$">
                            Please enter a valid asset type
                        </asp:RegularExpressionValidator>
                    </div>     
               </div>
              <div class="row btnApproveInvoice ">
                   <div class="col-sm-1 ">
                        <asp:Button type="submit frmElement" class="btn btn-primary" ID="btnAdd"  ValidationGroup="addAssetType" runat="server" Text="Add"/>
                   </div>
                   <div class="col-sm-1 ">
                        <asp:Button type="submit frmElement" class="btn btn-primary" ID="btnUpdate" runat="server" Text="Update"/>
                   </div>
              </div>
            </div> 
       </div>
        <div class="row assetForm">
            <div class="col-sm-7">
                <asp:Panel ID="pnlAssetType" runat="server" Height="200px" >
                    <asp:GridView runat="server" class="form-control" CssClass="Grid" AllowPaging="True" HeaderStyle-CssClass="header"  RowStyle-CssClass="rows" AutoGenerateColumns="False" OnSelectedIndexChanged="grdAssetType_SelectedIndexChanged"
                    ID="grdAssetType" Width="100%">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:TemplateField HeaderText="AssetTypeID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblAssetTypeID" runat="server" Text='<%# Bind("AssetTypeID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AssetType">
                                <ItemTemplate>
                                    <asp:Label ID="lblAssetType" runat="server" Text='<%# Bind("AssetType") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

