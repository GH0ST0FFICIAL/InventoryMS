<%@ Page Title="" MaintainScrollPositionOnPostback="true" EnableEventValidation="false" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="ProductAdd.aspx.cs" Inherits="admin_ProducAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs">
        <div class="col-sm-4">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>Product Add</h1>
                </div>
            </div>
        </div>
        <div class="col-sm-8">
            <div class="page-header float-right">
                <div class="page-title">
                    <ol class="breadcrumb text-right">
                        <li><a href="#">Manage</a></li>
                        <li><a href="#">Admin</a></li>
                        <li class="active">Product Add</li>
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
                    <label for="text-input" class=" form-control-label">Product Name</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtProductName" placeholder="Product Name" class="form-control" runat="server" required="true"></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="text-input" class=" form-control-label">Product Description</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtDescription" placeholder="Product Description" class="form-control" runat="server" required="true" TextMode="MultiLine" Rows="4"></asp:TextBox>
                </div>
            </div>


            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="disabled-input" class=" form-control-label">Store</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:DropDownList ID="ddlstore" AutoPostBack="true" AppendDataBoundItems="true" class="form-control" runat="server" required="true">
                        <asp:ListItem Value="0">Please Select</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="disabled-input" class=" form-control-label">Brand</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:DropDownList ID="ddlBrand" AutoPostBack="true" AppendDataBoundItems="true" class="form-control" runat="server" required="true">
                        <asp:ListItem Value="0">Please Select</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="disabled-input" class=" form-control-label">Supplier</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:DropDownList ID="ddlSupplier" AutoPostBack="true" AppendDataBoundItems="true" class="form-control" runat="server" required="true">
                        <asp:ListItem Value="0">Please Select</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="disabled-input" class=" form-control-label">Size</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:DropDownList ID="ddlSize" AutoPostBack="true" AppendDataBoundItems="true" class="form-control" runat="server" required="true">
                        <asp:ListItem Value="0">Please Select</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="disabled-input" class=" form-control-label">Category</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:DropDownList ID="ddlCategory" AutoPostBack="true" AppendDataBoundItems="true" class="form-control" runat="server" required="true">
                        <asp:ListItem Value="0">Please Select</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>


            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="text-input" class=" form-control-label">Quantity</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtQuantity" placeholder="Quantity" class="form-control" runat="server" TextMode="Number" required="true"></asp:TextBox>

                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="text-input" class=" form-control-label">Product Price</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtProductPrice" placeholder="Product Price" class="form-control" runat="server" TextMode="Number" required="true"></asp:TextBox>

                </div>
            </div>

            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="text-input" class=" form-control-label">Product Price Tax %</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtTax" placeholder="Product Price Tax %" class="form-control" runat="server" TextMode="Number"></asp:TextBox>

                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                </div>
                <div class="col-12 col-md-9">
                    <asp:Button ID="btnCalculate" class="btn btn-danger btn-sm" runat="server" Text="Calculate Net Amount" OnClick="btnCalculate_Click" />
                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="text-input" class=" form-control-label">Total Price</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox Enabled="false" ID="txtTotalPrice" placeholder="Total Price" class="form-control" runat="server" TextMode="SingleLine" required="false"></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="textarea-input" class=" form-control-label">Product Photo</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:FileUpload ID="fupProductPhoto" class="form-control-file" runat="server" />
                </div>
            </div>
            <div class="card-footer">
                <asp:Button ID="btnProductAddSubmit" type="submit" class="btn btn-primary btn-sm" runat="server" Text="Submit" OnClick="btnProductAddSubmit_Click" />

            </div>
        </div>
</asp:Content>

