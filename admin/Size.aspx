<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="Size.aspx.cs" Inherits="admin_Size" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs">
        <div class="col-sm-4">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>Add Size</h1>
                </div>
            </div>
        </div>
        <div class="col-sm-8">
            <div class="page-header float-right">
                <div class="page-title">
                    <ol class="breadcrumb text-right">
                        <li><a href="#">Manage</a></li>
                        <li><a href="#">Size</a></li>
                        <li class="active">Add Size</li>
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
                    <label for="text-input" class=" form-control-label">Size</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtSize" placeholder="Size" class="form-control" runat="server" required="true"></asp:TextBox>
                </div>
            </div>
            <div class="card-footer">
                <asp:Button ID="btnSizeSubmit" type="submit" class="btn btn-primary btn-sm" runat="server" Text="Submit" OnClick="btnSizeSubmit_Click" />

            </div>
        </div>
    </div>
</asp:Content>

