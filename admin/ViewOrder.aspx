<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="ViewOrder.aspx.cs" Inherits="admin_ViewOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs">
        <div class="col-sm-4">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>View Order</h1>
                </div>
            </div>
        </div>
        <div class="col-sm-8">
            <div class="page-header float-right">
                <div class="page-title">
                    <ol class="breadcrumb text-right">
                        <li><a href="#">Manage</a></li>
                        <li><a href="#">Order</a></li>
                        <li class="active">View Order</li>
                    </ol>
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
                                    <asp:TextBox ID="txtSearch" placeholder="Type to Search" runat="server" AutoPostBack="true" class="form-control" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                            <asp:GridView class="table table-striped table-bordered" ID="GridViewOrders" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" AllowPaging="True" OnPageIndexChanging="GridViewOrders_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                    <asp:BoundField DataField="OrderDate" DataFormatString="{0:d}" HeaderText="Order Date" SortExpression="OrderDate" />
                                    <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" SortExpression="CustomerName" />
                                    <asp:BoundField DataField="CustomerPhone" HeaderText="Customer Phone" SortExpression="CustomerPhone" />
                                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                                    <asp:BoundField DataField="Rate" HeaderText="Price Rate" SortExpression="Rate" DataFormatString="{0:c}" HtmlEncode="false" />
                                    <asp:BoundField DataField="Amount" HeaderText="Total Amount" SortExpression="Amount" DataFormatString="{0:c}" HtmlEncode="false" />
                                    <asp:BoundField DataField="Vat" HeaderText="Vat %" SortExpression="Vat" />
                                    <asp:BoundField DataField="ServiceCharge" HeaderText="Service Charge %" SortExpression="ServiceCharge" />
                                    <asp:BoundField DataField="Discount" HeaderText="Discount %" SortExpression="Discount" />
                                    <asp:BoundField DataField="NetAmount" HeaderText="Net Payable Amount" SortExpression="NetAmount" DataFormatString="{0:c}" HtmlEncode="false" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- .animated -->
    </div>
    <script>
        $(document).ready(function (textone, texttwo) {
            if (textone.indexOf(texttwo) != -1) {
                return true;
            }
            $("#txtSearch").keyup(function () {
                var searchText = $("$txtSearch").val().toLowerCase();
                $(".table").each(function () {
                    if (!Contains($(this).text().toLowerCase(), searchText)) {
                        $(this).hide();
                    }
                    else {
                        $(this).show();
                    }
                });
            });
        });
    </script>
</asp:Content>

