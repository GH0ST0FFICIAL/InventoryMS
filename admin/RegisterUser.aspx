<%@ Page Title="" MaintainScrollPositionOnPostback="true" EnableEventValidation="false" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="RegisterUser.aspx.cs" Inherits="admin_RegisterUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                    <label for="text-input" class=" form-control-label">Name</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtName" placeholder="Name" class="form-control" runat="server" required="true"></asp:TextBox>
                </div>
            </div>

            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="email-input" class=" form-control-label">Email</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtEmail" placeholder="Email" class="form-control" runat="server" TextMode="Email" required="true"></asp:TextBox>

                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="email-input" class=" form-control-label">Phone Number</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtPhone" placeholder="Phone Number" class="form-control" runat="server" TextMode="Phone" required="true"></asp:TextBox>

                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="text-input" class=" form-control-label">User Name</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtUserName" placeholder="User Name" class="form-control" runat="server" required="true"></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="password-input" class=" form-control-label">Password</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtPassword" placeholder="Password" class="form-control" runat="server" TextMode="SingleLine" required="true"></asp:TextBox>

                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="disabled-input" class=" form-control-label">User Type</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:DropDownList ID="ddlUserType" AutoPostBack="true" AppendDataBoundItems="true" class="form-control" runat="server" required="true">
                        <asp:ListItem Value="0">Please Select</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="textarea-input" class=" form-control-label">Photo</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:FileUpload ID="fupPhoto" class="form-control-file" runat="server" required="true" />
                </div>
            </div>
        </div>
        <div class="card-footer">
            <asp:Button ID="btnSubmit" type="submit" class="btn btn-primary btn-sm" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

        </div>
    </div>

</asp:Content>

