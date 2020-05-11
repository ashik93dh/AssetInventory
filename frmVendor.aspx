<%@ Page Language="VB" MasterPageFile="~/AssetInventory.master" AutoEventWireup="false" CodeFile="frmVendor.aspx.vb" Inherits="frmVendor" title="Add Vendor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add Vendor</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">   
       <div class="row assetForm">
            <div class="container ">
               <div class="row">
                    <h3>Add Vendor</h3>
               </div>
               <div class="row">
                    <div class="col-sm-6">
                        <label for="VendorName" class="col-sm-2 col-form-label">Name</label>
                        <asp:TextBox type="text" class="form-control" ID="txtVendorName" placeholder="Enter Vendor Name" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="txtVendorName" errormessage="Please enter vendor name." />
                        <asp:RegularExpressionValidator ID="revVendorName" runat="server" ControlToValidate="txtVendorName" ValidationExpression="^[a-zA-Z0-9 ]{1,20}$">
                            Please enter a valid vendor name
                        </asp:RegularExpressionValidator>
                    </div>
                    <div class="col-sm-6">
                        <label for="VendorContactPerson" class="col-sm-2 col-form-label">ContactPerson</label>
                        <asp:TextBox type="text" class="form-control" ID="txtContactPerson" placeholder="Enter Contact Person" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="txtContactPerson" errormessage="Please enter contact person." />
                        <asp:RegularExpressionValidator ID="revContactPerson" runat="server" ControlToValidate="txtContactPerson" ValidationExpression="^[a-zA-Z0-9 ]{1,20}$">
                            Please enter a valid contact person name
                        </asp:RegularExpressionValidator>
                    </div>     
               </div>
               <div class="row">
                    <div class="col-sm-6">
                        <label for="VendorContactNo" class="col-sm-2 col-form-label">ContactNo</label>
                        <asp:TextBox type="text" class="form-control" ID="txtContactNo" placeholder="Enter Contact No" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" controltovalidate="txtContactNo" errormessage="Please enter contact no." />
                        <asp:RegularExpressionValidator ID="revContactNo" runat="server" ControlToValidate="txtContactNo" ValidationExpression="/^0\d{11}">
                            Please enter a valid contact no
                        </asp:RegularExpressionValidator>
                    </div>   
               </div>
               <div class="row">
                    <div class="col-sm-6">
                        <label for="VendorAddress" class="col-sm-2 col-form-label">Address</label>
                        <asp:TextBox type="text" class="form-control" ID="txtVendorAddress" placeholder="Enter Vendor Address" TextMode="Multiline" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3" controltovalidate="txtVendorAddress" errormessage="Please enter vendor address." />
                        <asp:RegularExpressionValidator ID="revVendorAddress" runat="server" ControlToValidate="txtVendorAddress" ValidationExpression="^[a-zA-Z0-9 ]{1,50}$">
                            Please enter a valid address
                        </asp:RegularExpressionValidator>
                    </div>     
               </div>
              <div class="row btnApproveInvoice ">
                   <div class="col-sm-1 ">
                        <asp:Button type="submit frmElement" class="btn btn-primary" ID="btnSubmit" runat="server" Text="Add" />
                   </div>
                   <div class="col-sm-1 ">
                        <asp:Button type="submit frmElement" class="btn btn-primary" ID="btnUpdate" runat="server" Text="Update"/>
                   </div>
              </div>
            </div> 
       </div>
       <div class="row assetForm">
            <div class="col-sm-12">
                <asp:Panel ID="pnlVendor" runat="server" Height="200px" >
                    <asp:GridView runat="server" class="form-control" CssClass="Grid" AllowPaging="True" HeaderStyle-CssClass="header"  RowStyle-CssClass="rows" AutoGenerateColumns="False" OnSelectedIndexChanged="grdVendor_SelectedIndexChanged"
                    ID="grdVendor" Width="100%">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
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
                            <asp:TemplateField HeaderText="Vendor Address">
                                <ItemTemplate>
                                    <asp:Label ID="lblVendorAddress" runat="server" Text='<%# Bind("VendorAddress") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact Person">
                                <ItemTemplate>
                                    <asp:Label ID="lblContactPerson" runat="server" Text='<%# Bind("ContactPerson") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact Person">
                                <ItemTemplate>
                                    <asp:Label ID="lblContactNo" runat="server" Text='<%# Bind("ContactNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

