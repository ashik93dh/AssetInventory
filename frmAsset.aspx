<%@ Page Language="VB" MasterPageFile="~/AssetInventory.master" AutoEventWireup="false" CodeFile="frmAsset.aspx.vb" Inherits="frmAsset" title="Add Asset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div class="container">
    <div class="row templateBody assetForm">
            <div class="container-fluid">
                <div class="row">
                    <h3 >Procurement Details</h3>
                </div>
                <div class="row">
                    <h5 class="assetFormTitle"><asp:Label id="lblWaitingInvoice" runat="server"></asp:Label></h5>
                </div>
                <div class="row">
                    <div class="col-sm-1">
                        <asp:Button type="submit frmElement" class="btn btn-primary" ID="btnInvoice" runat="server" Text="Go to create invoice "/>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
            <asp:Panel ID="pnlWaitingInvoice" runat="server" Height="150px">
                <asp:GridView runat="server" class="form-control" AllowPaging="False" HeaderStyle-CssClass="header"  RowStyle-CssClass="rows" AutoGenerateColumns="False" OnSelectedIndexChanged="grdWaitingInvoice_SelectedIndexChanged"
                     CssClass="Grid" ID="grdWaitingInvoice" Width="100%">
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
                        <asp:Label id="lblWaitingInvoiceNumber" runat="server"></asp:Label>
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
            </div>
       </div>
       <div class="row assetForm ">
           <div class="container ">
               <div class="row">
                    <div class="col-sm-3">
                        <asp:Label id="lblAllocationRemainingText" for="lblAllocation" runat="server">Allocation Remaining</asp:Label>
                        <asp:Label id="lblAllocationRemaining" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <label id="lblAssetTypeText"  runat="server">Type</label>
                        <asp:DropDownList ID="ddlAssetType" class="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" id="rfvAssetType" controltovalidate="ddlAssetType" ValidationGroup="addAsset" errormessage="Please select type." />
                    </div>
                    <div class="col-sm-3">
                        <label id="Brand"  runat="server">Brand</label>
                        <asp:DropDownList ID="ddlBrand" class="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" id="rfvBrand" controltovalidate="ddlBrand" ValidationGroup="addAsset" errormessage="Please select brand." />
                    </div>
                    <div class="col-sm-3">
                        <label id="Model"  runat="server">Model</label>
                        <asp:DropDownList ID="ddlModel" class="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" id="rfvModel" controltovalidate="ddlModel" ValidationGroup="addAsset" errormessage="Please select model." />
                    </div>      
               </div>
               <div class="row">
                     <div class="col-sm-6">
                        <label id="lblAssetQuantity"  runat="server">Quantity</label>
                        <asp:TextBox type="txtAssetQuantity" class="form-control" ID="txtAssetQuantity" placeholder="Enter Quantity" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="rfvAssetQuantity" controltovalidate="txtAssetQuantity" ValidationGroup="addAsset" errormessage="Please enter quantity." />
                        <asp:RegularExpressionValidator ID="revQuanity" runat="server" ControlToValidate="txtAssetQuantity" ValidationGroup="addAsset" ValidationExpression="^[0-9]{1,10}$">
                            Quantity must be a number
                        </asp:RegularExpressionValidator>
                    </div>
                    <div class="col-sm-6">
                        <label id="lblUnitAmountText" for="lblAllocation" runat="server">Unit Price</label>
                        <asp:TextBox type="text" class="form-control" ID="txtUnitAmount" placeholder="Enter Unit Amount" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="rfvUnitAmount" controltovalidate="txtUnitAmount" ValidationGroup="addAsset" errormessage="Please enter amount." />
                        <asp:RegularExpressionValidator ID="revUnitAmount" runat="server" ControlToValidate="txtUnitAmount" ValidationGroup="addAsset" ValidationExpression="^[0-9]{1,20}$">
                            Unit price must be between 20 digits
                        </asp:RegularExpressionValidator>
                    </div>  
               </div>
               <div class="row">
                    <asp:Button type="submit frmElement" class="btn btn-primary" ID="btnAdd" ValidationGroup="addAsset" runat="server" Text="Add"/>
               </div>
           </div>
       </div>
       <div class="row assetForm">
           <div class="col-sm-7">
                <asp:Panel ID="pnlAsset" runat="server" Height="150px">
                <asp:GridView runat="server" class="form-control" CssClass="Grid" 
                        AllowPaging="False" HeaderStyle-CssClass="header"  RowStyle-CssClass="rows" 
                        AutoGenerateColumns="False" OnRowDeleting="OnRowDeleting" OnSelectedIndexChanged="grdAsset_SelectedIndexChanged"
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
                                    <asp:Label ID="lblBrand" runat="server" Text='<%# Bind("Brand") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BrandID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblBrandID" runat="server" Text='<%# Bind("BrandID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Model">
                                <ItemTemplate>
                                    <asp:Label ID="lblModel" runat="server" Text='<%# Bind("Model") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ModelID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblModelID" runat="server" Text='<%# Bind("ModelID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="InvoiceID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblInvoiceID" runat="server" Text='<%# Bind("InvoiceID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit Price">
                                <ItemTemplate>
                                    <asp:Label ID="lblUnitPrice" runat="server" Text='<%# Bind("UnitPrice") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Price">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalPrice" runat="server" Text='<%# Bind("TotalPrice") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="deleteButton" runat="server" CommandName="Delete"  OnClientClick="return confirm('Are you sure?');" Text="Delete" />               
                                </ItemTemplate>
                            </asp:TemplateField>          
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                
                
           </div> 
           <div class="col-sm-5">
                <div class="row">
                   <h4 class="totalAssetAmount">
                       <label id="lblTotalAmountText" for="lblTotalAmount" runat="server">Total</label>
                       <asp:Label id="lblTotalAmount" runat="server"></asp:Label> 
                   </h4>
                </div>
               <div class="row ">
                   <div class="col-sm-3">
                        <asp:Button type="submit frmElement" class="btn btn-success" ID="btnSubmit" runat="server" Text="Submit"/>
                   </div>
                   <div class="col-sm-3">
                        <asp:Button type="submit frmElement" class="btn btn-danger" ID="btnCancel" runat="server" Text="Cancel"/>
                   </div>     
               </div>  
           </div>
       </div> 
           
</div>
</asp:Content>

