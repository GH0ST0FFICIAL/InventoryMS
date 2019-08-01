<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="user_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
     <div class="breadcrumbs">
        <div class="col-sm-4">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>Dashboard</h1>
                </div>
            </div>
        </div>
        <div class="col-sm-8">
            <div class="page-header float-right">
                <div class="page-title">
                    <ol class="breadcrumb text-right">
                        <li class="active">Dashboard</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>
<div class="content mt-3">
        <%-- offer notification --%>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                <div class="col-xl-4 col-lg-6">
                    <div class="card">
                        <div class="card-body">
                            <div class="stat-widget-one">
                                <div class="stat-icon dib"><i class="ti-money text-warning border-success"></i></div>
                                <div class="stat-content dib">
                                    <div class="stat-text text-danger">5% Offer</div>
                                    <div class="stat-digit">
                                        <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                                    </div>
                                      <div class="stat-text">
                                          Remaining items: 
                                        <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity")%>'></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT ProductName, Quantity FROM Product WHERE (Quantity &lt;&gt; @Quantity) AND (Date &lt; DATEADD(day, -20, GETDATE()))">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="Quantity" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>

    <div class="content mt-3">
        <%-- daily --%>
        <div class="col-xl-4 col-lg-6">
            <div class="card">
                <div class="card-body">
                    <div class="stat-widget-one">
                        <div class="stat-icon dib"><i class="ti-money text-success border-success"></i></div>
                        <div class="stat-content dib">
                            <div class="stat-text">Today Income</div>
                            <div class="stat-digit">
                                <asp:Label ID="lblTodayIncome" runat="server" Text="0"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xl-4 col-lg-6">
            <div class="card">
                <div class="card-body">
                    <div class="stat-widget-one">
                        <div class="stat-icon dib"><i class="ti-money text-danger border-danger"></i></div>
                        <div class="stat-content dib">
                            <div class="stat-text">Today Expenditure</div>
                            <div class="stat-digit">
                                <asp:Label ID="lblTodayExpenditure" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xl-4 col-lg-6">
            <div class="card">
                <div class="card-body">
                    <div class="stat-widget-one">
                        <div class="stat-icon dib"><i class="ti-money text-primary border-primary"></i></div>
                        <div class="stat-content dib">
                            <div class="stat-text">Today Profit/Loss</div>
                            <div class="stat-digit">
                                <asp:Label ID="lblTodayProfit" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%-- others --%>
        <div class="col-xl-3 col-lg-6">
            <div class="card">
                <div class="card-body">
                    <div class="stat-widget-one">
                        <div class="stat-icon dib"><i class="ti-money text-success border-success"></i></div>
                        <div class="stat-content dib">
                            <div class="stat-text">Total Stock</div>
                            <div class="stat-digit">
                                <asp:Label ID="lblTotalStock" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xl-3 col-lg-6">
            <div class="card">
                <div class="card-body">
                    <div class="stat-widget-one">
                        <div class="stat-icon dib"><i class="ti-money text-danger border-danger"></i></div>
                        <div class="stat-content dib">
                            <div class="stat-text">Total Order</div>
                            <div class="stat-digit">
                                <asp:Label ID="lblTotalOrder" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xl-3 col-lg-6">
            <div class="card">
                <div class="card-body">
                    <div class="stat-widget-one">
                        <div class="stat-icon dib"><i class="ti-user text-primary border-primary"></i></div>
                        <div class="stat-content dib">
                            <div class="stat-text">Total Customer</div>
                            <div class="stat-digit">
                                <asp:Label ID="lblTotalCustomer" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xl-3 col-lg-6">
            <div class="card">
                <div class="card-body">
                    <div class="stat-widget-one">
                        <div class="stat-icon dib"><i class="ti-money text-primary border-primary"></i></div>
                        <div class="stat-content dib">
                            <div class="stat-text">Total Stock Out</div>
                            <div class="stat-digit">
                                <asp:Label ID="lblTotalStockOut" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

