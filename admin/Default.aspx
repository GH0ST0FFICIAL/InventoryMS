<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [ProductName], [Quantity] FROM [Product] WHERE ([Quantity] &lt;&gt; @Quantity) AND (Date &lt; DATEADD(day, -20, GETDATE()))">
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

        <%-- weekly --%>
        <div class="col-xl-4 col-lg-6">
            <div class="card">
                <div class="card-body">
                    <div class="stat-widget-one">
                        <div class="stat-icon dib"><i class="ti-money text-success border-success"></i></div>
                        <div class="stat-content dib">
                            <div class="stat-text">This Week Income</div>
                            <div class="stat-digit">
                                <asp:Label ID="lblWeeklyIncome" runat="server" Text="Label"></asp:Label>
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
                            <div class="stat-text">This Week Expenditure</div>
                            <div class="stat-digit">
                                <asp:Label ID="lblWeeklyExpenditure" runat="server" Text="Label"></asp:Label>
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
                            <div class="stat-text">This Week Profit/Loss</div>
                            <div class="stat-digit">
                                <asp:Label ID="lblWeeklyProfit" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%-- monthly --%>
        <div class="col-xl-4 col-lg-6">
            <div class="card">
                <div class="card-body">
                    <div class="stat-widget-one">
                        <div class="stat-icon dib"><i class="ti-money text-success border-success"></i></div>
                        <div class="stat-content dib">
                            <div class="stat-text">This Month Income</div>
                            <div class="stat-digit">
                                <asp:Label ID="lblMonthlyIncome" runat="server" Text=""></asp:Label>
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
                            <div class="stat-text">This Month Expenditure</div>
                            <div class="stat-digit">
                                <asp:Label ID="lblMonthlyExpenditure" runat="server" Text="Label"></asp:Label>
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
                            <div class="stat-text">This Month Profit/Loss</div>
                            <div class="stat-digit">
                                <asp:Label ID="lblMonthlyProfit" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%-- yearly --%>
        <div class="col-xl-4 col-lg-6">
            <div class="card">
                <div class="card-body">
                    <div class="stat-widget-one">
                        <div class="stat-icon dib"><i class="ti-money text-success border-success"></i></div>
                        <div class="stat-content dib">
                            <div class="stat-text">This Year Income</div>
                            <div class="stat-digit">
                                <asp:Label ID="lblYearlyIncome" runat="server" Text=""></asp:Label>
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
                            <div class="stat-text">This Year Expenditure</div>
                            <div class="stat-digit">
                                <asp:Label ID="lblYearlyExpenditure" runat="server" Text="Label"></asp:Label>
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
                            <div class="stat-text">This Year Profit/Loss</div>
                            <div class="stat-digit">
                                <asp:Label ID="lblYearlyProfit" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%-- total --%>
        <div class="col-xl-4 col-lg-6">
            <div class="card">
                <div class="card-body">
                    <div class="stat-widget-one">
                        <div class="stat-icon dib"><i class="ti-money text-success border-success"></i></div>
                        <div class="stat-content dib">
                            <div class="stat-text">Total Income</div>
                            <div class="stat-digit">
                                <asp:Label ID="lblTotalIncome" runat="server" Text="Label"></asp:Label>
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
                            <div class="stat-text">Total Expenditure</div>
                            <div class="stat-digit">
                                <asp:Label ID="lblTotalExpenditure" runat="server" Text="Label"></asp:Label>
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
                            <div class="stat-text">Total Profit/Loss</div>
                            <div class="stat-digit">
                                <asp:Label ID="lblTotalProfit" runat="server" Text="Label"></asp:Label>
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
    <!-- .content -->
    </div><!-- /#right-panel -->


</asp:Content>

