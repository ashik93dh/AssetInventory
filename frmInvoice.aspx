<%@ Page Language="VB" MasterPageFile="~/AssetInventory.master" AutoEventWireup="false" CodeFile="frmInvoice.aspx.vb" Inherits="frmInvoice" title="Create Invoice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Create Invoice</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container ">
       <div class="row assetForm">
            <div class="container ">
               <div class="row ">
                    <h3>Create Invoice</h3>
               </div>
               <div class="row row-bottom-margin">
                   <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                   </cc1:ToolkitScriptManager>
                    <div class="col-sm-6">
                        <label for="InvoiceName">Invoice Number</label>
                        <asp:TextBox type="text" class="form-control" ID="txtInvoiceNumber" placeholder="Enter Invoice Number" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="rfvInvoiceNumber" controltovalidate="txtInvoiceNumber" ValidationGroup="addInvoice" errormessage="Please enter invoice number." />
                        <asp:RegularExpressionValidator ID="revInvoiceNumber" runat="server" ControlToValidate="txtInvoiceNumber" ValidationGroup="addInvoice" ValidationExpression="^[a-zA-Z0-9-\/ ]{1,20}$"> 
                            Please enter a valid invoice number
                        </asp:RegularExpressionValidator>
                    </div>                 
                     <div class="col-sm-6">
                        <label for="InvoiceAmount">Invoice Amount</label>
                        <asp:TextBox type="text" class="form-control" ID="txtInvoiceAmount" placeholder="Enter Invoice Amount" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="rfvInvoiceAmount" controltovalidate="txtInvoiceAmount" ValidationGroup="addInvoice" errormessage="Please enter invoice amount." />
                        <asp:RegularExpressionValidator ID="revInvoiceAmount" runat="server" ControlToValidate="txtInvoiceAmount" ValidationGroup="addInvoice" ValidationExpression="^[0-9]{1,20}$">
                            Please enter a valid  amount
                        </asp:RegularExpressionValidator>
                    </div> 
               </div>
               <div class="row row-bottom-margin">
                    <div class="col-sm-6">
                        <label for="InvoiceDate">Invoice Date</label>
                        <asp:textbox type="text"  class="form-control" ID="txtInvoiceDate" placeholder="mm/dd/yyyy"  runat="server"></asp:textbox>
                        <cc1:CalendarExtender ID="ceInvoiceDate" runat="server" Enabled="True" TargetControlID="txtInvoiceDate">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator runat="server" id="rfvInvoiceDate" controltovalidate="txtInvoiceDate" ValidationGroup="addInvoice" placeholder="mm/dd/yyyy" errormessage="Please enter invoice date." />
                        <asp:RegularExpressionValidator ID="revInvoiceDate" runat="server" ControlToValidate="txtInvoiceDate" ValidationGroup="addInvoice" ValidationExpression="^(0?[1-9]|1[0-2])/(0?[1-9]|1[0-9]|2[0-9]|3[01])/\d{4}$">
                            Please enter a valid date
                        </asp:RegularExpressionValidator>
                    </div>   
               </div>
               <div class="row row-bottom-margin">
                    <div class="col-sm-6">
                        <label for="Vendor">Vendor</label>
                        <asp:DropDownList ID="ddlVendor" class="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" id="rfvVendor" controltovalidate="ddlVendor" ValidationGroup="addInvoice" errormessage="Please select vendor." />
                    </div>
                    <div class="col-sm-6">
                         <div class="row">
                                <label for="InvoiceFile">Invoice File</label>
                         </div>
                         <div class="row">
                                <asp:FileUpload id="FileUploadControl" runat="server" />
                                
                         </div>
                    </div>      
               </div>
              <div class="row btnApproveInvoice row-bottom-margin ">
                   <div class="col-sm-1 ">
                        <asp:Button type="submit frmElement" class="btn btn-primary" ID="btnAdd" ValidationGroup="addInvoice" runat="server" Text="Add"/>
                   </div>
                   <div class="col-sm-1 ">
                        <asp:Button type="submit frmElement" class="btn btn-primary" ID="btnAssetPage" runat="server" Text="Go to Asset Page"/>
                   </div>
              </div>
            </div> 
       </div>
       <div class="row assetForm">
            <div class="col-sm-12">
                    <asp:Panel ID="pnlCreateInvoice" Height="150px" runat="server">
                        <asp:GridView runat="server" class="form-control" CssClass="Grid" AllowPaging="True" HeaderStyle-CssClass="header"  RowStyle-CssClass="rows" AutoGenerateColumns="False" OnSelectedIndexChanged="grdCreateInvoice_SelectedIndexChanged"
                                ID="grdCreateInvoice" Width="100%">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="False" />
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
                                    <asp:TemplateField HeaderText="Vendor">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendor" runat="server" Text='<%# Bind("VendorName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vendor" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendorID" runat="server" Text='<%# Bind("VendorID") %>'></asp:Label>
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
        </div>
        
</asp:Content>

