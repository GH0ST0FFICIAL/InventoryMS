<%@ Page Title="" MaintainScrollPositionOnPostback="true" EnableEventValidation="false" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="Supplier.aspx.cs" Inherits="admin_supplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs">
        <div class="col-sm-4">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>Add Supplier</h1>
                </div>
            </div>
        </div>
        <div class="col-sm-8">
            <div class="page-header float-right">
                <div class="page-title">
                    <ol class="breadcrumb text-right">
                        <li><a href="#">Manage</a></li>
                        <li><a href="#">Supplier</a></li>
                        <li class="active">Add Supplier</li>
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
                    <label for="text-input" class=" form-control-label">Supplier Name</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtSupplierName" placeholder="Supplier Name" class="form-control" runat="server" required="true"></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="text-input" class=" form-control-label">Supplier Address</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtSupplierAddress" placeholder="Supplier Address" class="form-control" runat="server" required="true"></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="text-input" class=" form-control-label">Supplier Phone Number</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtSupplierPhone" placeholder="Supplier Phone Number" class="form-control" runat="server" required="true"></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="text-input" class=" form-control-label">Supplier Product</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtSupplierProduct" placeholder="Supplier Product" class="form-control" runat="server" required="true"></asp:TextBox>
                </div>
            </div>
            <div class="card-footer">
                <asp:Button ID="btnSupplierSubmit" type="submit" class="btn btn-primary btn-sm" runat="server" Text="Submit" OnClick="btnSupplierSubmit_Click" />

            </div>
        </div>
    </div>
</asp:Content>

