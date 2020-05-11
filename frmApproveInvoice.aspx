<%@ Page Language="VB" MasterPageFile="~/AssetInventory.master" AutoEventWireup="false" CodeFile="frmApproveInvoice.aspx.vb" Inherits="frmApproveInvoice" title="Approve invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
<div class="container">
    <div class="row">
        <h3>Approval Details</h3>
    </div>
    <div class="row assetForm">
            <h4 class="assetFormTitle">Pending Invoices</h4>
            <h6 class="assetFormTitle"><asp:Label id="lblPendingInvoice" runat="server"></asp:Label></h6>
            <div class="col-sm-12">
            <asp:Panel ID="pnlUnapprovedInvoice" runat="server" Height="100px">
                <asp:GridView runat="server" class="form-control" AllowPaging="False" HeaderStyle-CssClass="header"  RowStyle-CssClass="rows" 
                    AutoGenerateColumns="False" OnSelectedIndexChanged="grdUnapprovedInvoice_SelectedIndexChanged"
                     CssClass="Grid" ID="grdUnapprovedInvoice" Width="100%">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:TemplateField HeaderText="Invoice ID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblInvoiceID" runat="server" Text='<%# Bind("InvoiceID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Invoice Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblInvoiceNumber" runat="server" Text='<%# Bind("InvoiceNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Invoice Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblInvoiceDate" runat="server" Text='<%# Bind("InvoiceDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Invoice File">
                                <ItemTemplate>
                                    <asp:Label ID="lblInvoiceFile" runat="server" Text='<%# Bind("InvoiceFile") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Invoice Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lblInvoiceAmount" runat="server" Text='<%# Bind("InvoiceAmount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VendorID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblVendorID" runat="server" Text='<%# Bind("VendorID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vendor Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblVendorName" runat="server" Text='<%# Bind("VendorName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Approval Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblActiveStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EntryBy">
                                <ItemTemplate>
                                    <asp:Label ID="lblEntryBy" runat="server" Text='<%# Bind("EntryBy") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                 </asp:GridView>
                </asp:Panel>
            </div>
       </div>
       <div class="row assetForm">
           <div class="container ">
               <div class="row">
                    <div class="col-sm-6">
                        <asp:Label id="lblVendorText" for="lblAllocation" runat="server">Vendor : </asp:Label>
                        <asp:Label id="lblVendor" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-6">
                        <asp:Label id="lblInvoiceNumberText"  runat="server">Invoice Number : </asp:Label>
                        <asp:Label id="lblAssetInvoiceNumber" runat="server"></asp:Label>
                    </div>     
               </div>
               <div class="row">
                     <div class="col-sm-6">
                        <asp:Label id="lblPurchaseDateText"  runat="server">Purchase Date : </asp:Label>
                        <asp:Label id="lblPurchaseDate" runat="server"></asp:Label>
                    </div> 
                    <div class="col-sm-6">
                        <asp:Label id="lblTotalCostText"  runat="server">Total Cost : </asp:Label>
                        <asp:Label id="lblTotalCost" runat="server"></asp:Label>
                    </div> 
               </div>
               <div class="row">
                     <div class="col-sm-6">
                        <asp:Label id="lblRemarks"  runat="server">Remarks </asp:Label>
                        <asp:TextBox type="text" class="form-control" ID="txtRemarks" placeholder="Enter Remarks" TextMode="Multiline" runat="server"></asp:TextBox>
                    </div>
               </div>
               
               <div class="row">
            <h4 class="assetFormTitle">Associated Assets</h4>
       </div>
        <div class="row">
           <div class="col-sm-12">
                <asp:Panel ID="pnlAsset" runat="server" Height="100px">
                <asp:GridView runat="server" class="form-control" CssClass="Grid" 
                        AllowPaging="False" HeaderStyle-CssClass="header"  RowStyle-CssClass="rows" 
                        AutoGenerateColumns="False" OnSelectedIndexChanged="grdAsset_SelectedIndexChanged"
                        Width=100% ID="grdAsset">
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
            </div>
            <div class="row btnApproveInvoice ">
                   <div class="col-sm-1 ">
                    <asp:Button type="submit frmElement" class="btn btn-primary" ID="btnApprove" runat="server" Text="Approve"/>
                   </div>
                   <div class="col-sm-1">
                    <asp:Button type="submit frmElement" class="btn btn-danger" ID="btnReject" runat="server" Text="Reject"/>
                   </div>  
           </div>
       </div>
       </div>
       <div class="row assetForm">
           <h4 class="assetFormTitle">Approved Invoices</h4>
           <div class="col-sm-12">
            <asp:Panel ID="pnlApprovedInvoice" runat="server" Height="100px">
                <asp:GridView runat="server" class="form-control" AllowPaging="False" HeaderStyle-CssClass="header"  RowStyle-CssClass="rows" AutoGenerateColumns="False" OnSelectedIndexChanged="grdApprovedInvoice_SelectedIndexChanged"
                     CssClass="Grid" ID="grdApprovedInvoice" Width="100%">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:TemplateField HeaderText="Invoice ID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblInvoiceID" runat="server" Text='<%# Bind("InvoiceID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Invoice Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblInvoiceNumber" runat="server" Text='<%# Bind("InvoiceNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Invoice Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblInvoiceDate" runat="server" Text='<%# Bind("InvoiceDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Invoice File">
                                <ItemTemplate>
                                    <asp:Label ID="lblInvoiceFile" runat="server" Text='<%# Bind("InvoiceFile") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Invoice Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lblInvoiceAmount" runat="server" Text='<%# Bind("InvoiceAmount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VendorID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblVendorID" runat="server" Text='<%# Bind("VendorID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vendor Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblVendorName" runat="server" Text='<%# Bind("VendorName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Approval Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblActiveStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ActionTime">
                                <ItemTemplate>
                                    <asp:Label ID="lblActionTime" runat="server" Text='<%# Bind("ActionTime") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="EntryBy">
                                <ItemTemplate>
                                    <asp:Label ID="lblEntryBy" runat="server" Text='<%# Bind("EntryBy") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                            
                        </Columns>
                 </asp:GridView>
                </asp:Panel>
            </div>
       </div> 
       <div class="row assetForm">
           <h4 class="assetFormTitle">Rejected Invoices</h4>
           <div class="col-sm-12">
            <asp:Panel ID="pnlRejectedInvoice" runat="server" Height="100px">
             <asp:GridView ID="grdRejectedInvoice" runat="server" AllowPaging="False" AutoGenerateColumns="False" class="form-control" CssClass="Grid" HeaderStyle-CssClass="header" OnSelectedIndexChanged="grdRejectedInvoice_SelectedIndexChanged" RowStyle-CssClass="rows" Width="100%">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:TemplateField HeaderText="Invoice ID" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblInvoiceID" runat="server" Text='<%# Bind("InvoiceID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Invoice Number">
                            <ItemTemplate>
                                <asp:Label ID="lblInvoiceNumber" runat="server" Text='<%# Bind("InvoiceNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Invoice Date">
                            <ItemTemplate>
                                <asp:Label ID="lblInvoiceDate" runat="server" Text='<%# Bind("InvoiceDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Invoice File">
                            <ItemTemplate>
                                <asp:Label ID="lblInvoiceFile" runat="server" Text='<%# Bind("InvoiceFile") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Invoice Amount">
                            <ItemTemplate>
                                <asp:Label ID="lblInvoiceAmount" runat="server" Text='<%# Bind("InvoiceAmount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="VendorID" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblVendorID" runat="server" Text='<%# Bind("VendorID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vendor Name">
                            <ItemTemplate>
                                <asp:Label ID="lblVendorName" runat="server" Text='<%# Bind("VendorName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Approval Status">
                            <ItemTemplate>
                                <asp:Label ID="lblApproveStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                            
                        <asp:TemplateField HeaderText="ActionTime">
                            <ItemTemplate>
                                <asp:Label ID="lblActionTime" runat="server" Text='<%# Bind("ActionTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Entry By">
                            <ItemTemplate>
                                <asp:Label ID="lblEntryBy" runat="server" Text='<%# Bind("EntryBy") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
               </asp:Panel>
            </div>
       </div>       
</div>
</asp:Content>

