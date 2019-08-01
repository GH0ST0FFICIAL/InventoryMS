<%@ Page Title="" MaintainScrollPositionOnPostback="false" EnableEventValidation="false" Language="C#" MasterPageFile="~/user/User.master" AutoEventWireup="true" CodeFile="AddOrder.aspx.cs" Inherits="user_AddOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <div class="breadcrumbs">
        <div class="col-sm-4">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>Register User</h1>
                </div>
            </div>
        </div>
        <div class="col-sm-8">
            <div class="page-header float-right">
                <div class="page-title">
                    <ol class="breadcrumb text-right">
                        <li><a href="#">Manage</a></li>
                        <li><a href="#">Users</a></li>
                        <li class="active">Register User</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>
    <div class="card">
        <%--    <div class="card-header">
            <strong>Basic Form</strong> Elements
        </div>--%>
        <div class="card-body card-block">
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="text-input" class=" form-control-label">Customer Name</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtCustomerName" placeholder="Customer Name" class="form-control" runat="server" required="true"></asp:TextBox>
                </div>
            </div>

            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="text-input" class=" form-control-label">Address</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtAddress" placeholder="Customer Address" class="form-control" runat="server" required="false"></asp:TextBox>

                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="text-input" class=" form-control-label">Phone Number</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtCustomerphn" placeholder="Customer Phone Number" class="form-control" runat="server" TextMode="Phone" required="true"></asp:TextBox>

                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="text-input" class=" form-control-label">Date Of Birth</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtCDOB" placeholder="Date Of Birth" class="form-control" runat="server" required="true" TextMode="Date"></asp:TextBox>
                </div>
            </div>

            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="disabled-input" class=" form-control-label">Product</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:DropDownList ID="ddlProduct" AutoPostBack="true" AppendDataBoundItems="true" class="form-control" runat="server" required="true" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                        <asp:ListItem Value="0">Please Select</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="text-input" class=" form-control-label">Quantity</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtQuantity" placeholder="Quantity" class="form-control" runat="server" required="true" TextMode="Number"></asp:TextBox>

                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="text-input" class=" form-control-label">Rate</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtRate" placeholder="Rate" class="form-control" runat="server" required="true" TextMode="Number"></asp:TextBox>

                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                </div>
                <div class="col-12 col-md-9">
                    <asp:Button ID="btnCalculateAmount" class="btn btn-warning btn-sm" runat="server" Text="Calculate Amount" OnClick="btnCalculateAmount_Click" />
                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="text-input" class=" form-control-label">Amount</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtAmount" Enabled="false" placeholder="Amount" class="form-control" runat="server" TextMode="SingleLine" required="false"></asp:TextBox>

                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="disabled-input" class=" form-control-label">Vat %</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:DropDownList ID="ddlvat" AutoPostBack="true" AppendDataBoundItems="true" class="form-control" runat="server" required="false">
                        <asp:ListItem Value="0">Please Select</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="disabled-input" class=" form-control-label">Service Charge %</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:DropDownList ID="ddlServiceCharge" AutoPostBack="true" AppendDataBoundItems="true" class="form-control" runat="server" required="false">
                        <asp:ListItem Value="0">Please Select</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="text-input" class=" form-control-label">Discount %</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtDiscount" placeholder="Discount" class="form-control" runat="server" TextMode="Number"></asp:TextBox>

                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                </div>
                <div class="col-12 col-md-9">
                    <asp:Button ID="btnCalculateNet" class="btn btn-danger btn-sm" runat="server" Text="Calculate Net Amount" OnClick="btnCalculateNet_Click" />
                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="text-input" class=" form-control-label">Net Amount</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox Enabled="false" ID="txtNetAmount" placeholder="Net Amount" class="form-control" runat="server" TextMode="SingleLine" required="false"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="card-footer">
            <asp:Button ID="btnOrderSubmit" type="submit" class="btn btn-primary btn-sm" runat="server" Text="Submit" OnClick="btnOrderSubmit_Click" OnClientClick="if ( ! AllConfirmation()) return false;"
                meta:resourcekey="btnOrderSubmitResource1" />
        </div>
    </div>

    <script>
        function AllConfirmation() {
            return confirm("Are you sure you want to submit this order?");
        }
    </script>
</asp:Content>

