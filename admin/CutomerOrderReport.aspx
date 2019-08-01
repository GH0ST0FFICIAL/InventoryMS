<%@ Page Title="" MaintainScrollPositionOnPostback="true" EnableEventValidation="false" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="CutomerOrderReport.aspx.cs" Inherits="admin_report_CutomerOrderReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs">
        <div class="col-sm-4">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>Customer Report</h1>
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
                                    <label for="text-input" class=" form-control-label">Search By Customer</label>
                                </div>
                                <div class="col col-md-6">
                                    <asp:DropDownList class="form-control" ID="ddlSelectCustomer" AutoPostBack="True" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlSelectCustomer_SelectedIndexChanged" runat="server">
                                        <asp:ListItem Value="0" Text="Please Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col col-md-3">
                                    <label for="text-input" class=" form-control-label">Customer Name</label>
                                </div>
                                <div class="col-12 col-md-9">
                                    <asp:Label ID="lblCustomerName" runat="server" Text=" "></asp:Label>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col col-md-3">
                                    <label for="text-input" class=" form-control-label">Total Orders</label>
                                </div>
                                <div class="col-12 col-md-9">
                                    <asp:Label ID="lblTotalOrder" runat="server" Text=" "></asp:Label>
                                </div>
                            </div>

                            <asp:GridView class="table table-striped table-bordered" ID="GridViewCustomerOrders" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" AllowPaging="True" OnPageIndexChanging="GridViewCustomerOrders_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                    <asp:BoundField DataField="OrderDate" DataFormatString="{0:d}" HeaderText="Order Date" SortExpression="OrderDate" />
                                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                                    <asp:BoundField DataField="NetAmount" HeaderText="Paid Amount" SortExpression="NetAmount" DataFormatString="{0:c}" HtmlEncode="false" />
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

