<%@ Page Title="" MaintainScrollPositionOnPostback="true" EnableEventValidation="false" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="Store.aspx.cs" Inherits="admin_Store" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs">
        <div class="col-sm-4">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>Add Store</h1>
                </div>
            </div>
        </div>
        <div class="col-sm-8">
            <div class="page-header float-right">
                <div class="page-title">
                    <ol class="breadcrumb text-right">
                        <li><a href="#">Manage</a></li>
                        <li><a href="#">Store</a></li>
                        <li class="active">Add Store</li>
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
                    <label for="text-input" class=" form-control-label">Store Name</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtStoredName" placeholder="Store Name" class="form-control" runat="server" required="true"></asp:TextBox>
                </div>
            </div>
            <div class="card-footer">
                <asp:Button ID="btnStoreSubmit" type="submit" class="btn btn-primary btn-sm" runat="server" Text="Submit" OnClick="btnStoreSubmit_Click" />

            </div>
        </div>
    </div>
</asp:Content>

