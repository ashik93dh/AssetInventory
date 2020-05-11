<%@ Page Language="VB" MasterPageFile="~/AssetInventory.master" AutoEventWireup="false" CodeFile="frmModel.aspx.vb" Inherits="frmModel" title="Add Model" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add Brand</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
       <div class="row assetForm">
            <div class="container ">
               <div class="row">
                    <h3>Add Model</h3>
               </div>
               <div class="row">
                    <div class="col-sm-6">
                        <label for="ModelName" class="col-sm-2 col-form-label">Name</label>
                        <asp:TextBox type="text" class="form-control" ID="txtModelName" placeholder="Enter Model Name" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="txtModelName"  ValidationGroup="addModel" errormessage="Please enter model name." />
                        <asp:RegularExpressionValidator ID="revModelName" runat="server" ControlToValidate="txtModelName"  ValidationGroup="addModel" ValidationExpression="^[a-zA-Z0-9 ]{1,20}$">
                            Please enter a valid model name
                        </asp:RegularExpressionValidator>
                    </div>     
               </div>
               <div class="row">
                    <div class="col-sm-6">
                        <label for="BrandName" class="col-sm-2 col-form-label">Brand</label>
                        <asp:DropDownList ID="ddlModelBrand" class="form-control" runat="server" ></asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="ddlModelBrand"  ValidationGroup="addModel" errormessage="Please select brand." />
                    </div>     
               </div>
              <div class="row btnApproveInvoice ">
                   <div class="col-sm-1 ">
                        <asp:Button type="submit frmElement" class="btn btn-primary" ID="btnAdd"  ValidationGroup="addModel" runat="server" Text="Add"/>
                   </div>
                   <div class="col-sm-1 ">
                        <asp:Button type="submit frmElement" class="btn btn-primary" ID="btnUpdate" runat="server" Text="Update"/>
                   </div>
              </div>
            </div> 
       </div>
       <div class="row assetForm">
           <div class="col-sm-7">
                <asp:Panel ID="pnlModel" runat="server" Height="200px">
                     <asp:GridView runat="server" class="form-control" CssClass="Grid" AllowPaging="True" HeaderStyle-CssClass="header"  RowStyle-CssClass="rows" AutoGenerateColumns="False" OnSelectedIndexChanged="grdModel_SelectedIndexChanged"
                        ID="grdModel" Width="100%">
                        <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                            <asp:CommandField ShowSelectButton="False" />
                            <asp:TemplateField HeaderText="ModelID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblModelID" runat="server" Text='<%# Bind("ModelID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ModelName">
                                <ItemTemplate>
                                    <asp:Label ID="lblModelName" runat="server" Text='<%# Bind("ModelName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
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



