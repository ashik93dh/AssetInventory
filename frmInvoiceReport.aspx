<%@ Page Language="VB" MasterPageFile="~/AssetInventory.master" AutoEventWireup="false" CodeFile="frmInvoiceReport.aspx.vb" Inherits="frmInvoiceReport" title="Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div class="container">
        <div class="row assetForm">
           <div class="container ">
                <div class="row">
                    <h3>Reports</h3>
                </div>
               <div class="row">
                    <div class="col-sm-6">
                        <asp:Label id="lblInvoiceNumberText"  runat="server">Invoice Number</asp:Label>
                        <asp:TextBox type="text" class="form-control" ID="txtInvoiceNumber" placeholder="Enter Invoice Number"  runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="rfvInvoiceNumber" controltovalidate="txtInvoiceNumber"  ValidationGroup="addInvoiceNumber" errormessage="Please enter invoice number." />
                        <asp:RegularExpressionValidator ID="revBrand" runat="server" ControlToValidate="txtInvoiceNumber"  ValidationGroup="addInvoiceNumber" ValidationExpression="^[a-zA-Z0-9-\/ ]{1,20}$">
                            Please enter a valid invoice number
                        </asp:RegularExpressionValidator>
                    </div>     
               </div>
              <div class="row btnApproveInvoice ">
                   <div class="col-sm-1 ">
                    <asp:Button type="submit frmElement" class="btn btn-primary" ID="btnSubmit" ValidationGroup="addInvoiceNumber" runat="server" Text="Submit"/>
                   </div>
              </div>
            </div>
        </div>
        <div class="row assetForm">
        <div class="container">
            <div class="row">
                   <h4 class="assetFormTitle"><asp:Label id="lblInvoiceReport" for="InvoiceReport" runat="server"></asp:Label></h4>
                   <div class="col-sm-12">
                        <asp:Panel ID="pnlInvoiceReport" runat="server" Height="150px">
                        <asp:GridView runat="server" class="form-control" CssClass="Grid" 
                                AllowPaging="False" HeaderStyle-CssClass="header"  RowStyle-CssClass="rows" 
                                AutoGenerateColumns="False" OnSelectedIndexChanged="grdInvoiceReport_SelectedIndexChanged"
                                Width=100% ID="grdInvoiceReport">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="False" />
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
                                    <asp:TemplateField HeaderText="Brand">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBrand" runat="server" Text='<%# Bind("BrandName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BrandID" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBrandID" runat="server" Text='<%# Bind("BrandID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Model">
                                        <ItemTemplate>
                                            <asp:Label ID="lblModel" runat="server" Text='<%# Bind("ModelName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ModelID" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblModelID" runat="server" Text='<%# Bind("ModelID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit Price">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitPrice" runat="server" Text='<%# Bind("UnitAmount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>            
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                   </div>
                    <div class="col-sm-6">
                    <label id="lblSelectFormat"  runat="server">Select Format</label>
                    <asp:DropDownList ID="ddlformat" class="form-control" runat="server"></asp:DropDownList>
                   </div>
               </div>
           <div class="row btnApproveInvoice">
                <div class="col-sm-3 ">
                <asp:Button type="submit frmElement" class="btn btn-primary" ID="btnGenerateReport" runat="server" Text="Generate Report"/>
               </div>
               <div class="col-sm-3 ">
                <asp:Button type="submit frmElement" class="btn btn-danger" ID="btnCancel" runat="server" Text="Cancel"/>
               </div>
           </div>
        </div>   
    </div>
</div>
</asp:Content>

