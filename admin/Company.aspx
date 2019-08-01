<%@ Page Title="" MaintainScrollPositionOnPostback="false" EnableEventValidation="false" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="Company.aspx.cs" Inherits="admin_Company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs">
        <div class="col-sm-4">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>Company Policy</h1>
                </div>
            </div>
        </div>
        <div class="col-sm-8">
            <div class="page-header float-right">
                <div class="page-title">
                    <ol class="breadcrumb text-right">
                        <li><a href="#">Manage</a></li>
                        <li><a href="#">Company</a></li>
                        <li class="active">Company Policy</li>
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
                    <label for="text-input" class=" form-control-label">Service Charge</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtServiceCharge" placeholder="Product Price" class="form-control" runat="server" TextMode="Number" required="true"></asp:TextBox>

                </div>
            </div>
            <div class="row form-group">
                <div class="col col-md-3">
                    <label for="text-input" class=" form-control-label">Price Vat %</label>
                </div>
                <div class="col-12 col-md-9">
                    <asp:TextBox ID="txtVat" placeholder="Product Price Tax %" class="form-control" runat="server" TextMode="Number" required="false"></asp:TextBox>

                </div>
            </div>
        </div>

        <div class="card-footer">

            <asp:Button ID="btnComSubmit" type="submit" class="btn btn-primary btn-sm" runat="server" Text="Submit" OnClick="btnComSubmit_Click" />

        </div>
    </div>
</asp:Content>

