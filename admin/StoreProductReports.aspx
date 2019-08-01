<%@ Page Title="" MaintainScrollPositionOnPostback="true" EnableEventValidation="false" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="StoreProductReports.aspx.cs" Inherits="admin_StoreProductReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="breadcrumbs">
        <div class="col-sm-4">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>Store Report</h1>
                </div>
            </div>
        </div>
    </div>
    <div class="content mt-3">
        <div class="animated fadeIn">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="row form-group">
                                <div class="col col-md-3">
                                    <label for="text-input" class=" form-control-label">Search by Store Name</label>
                                </div>
                                <div class="col col-md-6">
                                    <asp:DropDownList class="form-control" ID="ddlSelectStoreName" AutoPostBack="True" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlSelectStoreName_SelectedIndexChanged" runat="server">
                                        <asp:ListItem Value="0" Text="Please Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col col-md-3">
                                    <label for="text-input" class=" form-control-label">Store Name</label>
                                </div>
                                <div class="col-12 col-md-9">
                                    <asp:Label ID="lblStoreName" runat="server" Text=" "></asp:Label>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col col-md-3">
                                    <label for="text-input" class=" form-control-label">Total Products</label>
                                </div>
                                <div class="col-12 col-md-9">
                                    <asp:Label ID="lblTotalProduct" runat="server" Text=" "></asp:Label>
                                </div>
                            </div>

                            <asp:GridView class="table table-striped table-bordered" ID="GridViewStoresProduct" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridViewStoresProduct_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                                    <asp:BoundField DataField="ProductDescription" HeaderText="ProductDescription" SortExpression="ProductDescription" />
                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                                    <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand" />
                                    <asp:BoundField DataField="Supplier" HeaderText="Supplier" SortExpression="Supplier" />
                                    <asp:BoundField DataField="Size" HeaderText="Size" SortExpression="Size" />
                                    <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                                    <asp:TemplateField HeaderText="ProductPhoto" SortExpression="ProductPhoto">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ProductPhoto") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" ImageUrl='<%# "./ProductImages/"+ Eval("ProductPhoto") %>' runat="server" Width="100px"  />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                    <asp:BoundField DataField="TotalPrice" HeaderText="TotalPrice" SortExpression="TotalPrice" DataFormatString="{0:c}" HtmlEncode="false" />
                                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date"  DataFormatString="{0:d}" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- .animated -->
    </div>
</asp:Content>

