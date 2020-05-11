<%@ Page Language="VB" MasterPageFile="~/AssetInventory.master" AutoEventWireup="false" CodeFile="frmBrand.aspx.vb" Inherits="frmBrand" title="Add Brand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add Brand</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
       
       <div class="row assetForm">
            <div class="container ">
                <div class="row">
                    <h3>Add Brand</h3>
                </div>
               <div class="row">
                    <div class="col-sm-6">
                        <label for="InvoiceName" class="col-sm-2 col-form-label">Name</label>
                        <asp:TextBox type="text" class="form-control" ID="txtBrandName" placeholder="Enter Brand Name" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="txtBrandName"  ValidationGroup="addBrand" errormessage="Please enter brand name." />
                        <asp:RegularExpressionValidator ID="revBrand" runat="server" ControlToValidate="txtBrandName"  ValidationGroup="addBrand" ValidationExpression="^[a-zA-Z ]{1,20}$">
                            Please enter a valid brand name
                        </asp:RegularExpressionValidator>
                    </div>     
               </div>
              <div class="row btnApproveInvoice ">
                   <div class="col-sm-1 ">
                        <asp:Button type="submit frmElement" class="btn btn-primary" ID="btnAdd"  ValidationGroup="addBrand" runat="server" Text="Add"/>
                   </div>
                   <div class="col-sm-1 ">
                        <asp:Button type="submit frmElement" class="btn btn-primary" ID="btnUpdate" runat="server" Text="Update"/>
                   </div>
              </div>
            </div> 
       </div>
       <div class="row assetForm">
           <div class="col-sm-7">
               <asp:Panel ID="pnlBrand" runat="server" Height="200px">
                    <asp:GridView runat="server" class="form-control" CssClass="Grid" AllowPaging="True" HeaderStyle-CssClass="header"  RowStyle-CssClass="rows" AutoGenerateColumns="False" OnSelectedIndexChanged="grdBrand_SelectedIndexChanged"
                            ID="grdBrand" Width="100%">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:CommandField ShowSelectButton="False" />
                                <asp:TemplateField HeaderText="BrandID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBrandID" runat="server" Text='<%# Bind("BrandID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="BrandName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBrandName" runat="server" Text='<%# Bind("BrandName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                    </asp:GridView>
                </asp:Panel>
             </div>
        </div>
    </div>
</asp:Content>

