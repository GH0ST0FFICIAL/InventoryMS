<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Login</title>
    <!-- Meta-Tags -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta charset="utf-8" />
    <meta name="keywords" content="" />
    <script>
        addEventListener("load", function () {
            setTimeout(hideURLbar, 0);
        }, false);

        function hideURLbar() {
            window.scrollTo(0, 1);
        }
    </script>
    <!-- //Meta-Tags -->
    <!-- Index-Page-CSS -->
    <link rel="stylesheet" href="css/style.css?v={09/version-1}" type="text/css" media="all" />
    <!-- //Custom-Stylesheet-Links -->
    <!--fonts -->
    <link href="//fonts.googleapis.com/css?family=Mukta+Mahee:200,300,400,500,600,700,800" rel="stylesheet" />
    <!-- //fonts -->
    <link rel="stylesheet" href="css/font-awesome.css" type="text/css" media="all" />
    <!-- //Font-Awesome-File-Links -->
</head>
<body>
    <form id="form1" runat="server">
        <div class="content-w3ls">
            <div class="content-bottom">
                <form action="#" method="post">
                     
                    <div class="field-group">
                        <span class="fa fa-user" aria-hidden="true"></span>
                        <div class="wthree-field">
                            <asp:TextBox ID="txtUsername" value="" placeholder="username" required="required" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field-group">
                        <span class="fa fa-lock" aria-hidden="true"></span>
                        <div class="wthree-field">
                            <asp:TextBox name="password" id="txtPassword" type="password" required="required" placeholder="password" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field-group">
                        <div class="check">
                            <label class="">
                                <asp:CheckBox ID="CheckBox1" type="checkbox" onclick="myFunction()" runat="server" />
                                <%-- <input type="checkbox" onclick="myFunction()">--%>
                                show password</label>
                        </div>
                        <!-- script for show password -->
                        <script>
                            function myFunction() {
                                var x = document.getElementById("txtPassword");
                                if (x.type === "password") {
                                    x.type = "text";
                                } else {
                                    x.type = "password";
                                }
                            }
                        </script>
                        <!-- //script for show password -->
                    </div>
                    <div class="wthree-field">
                        <asp:Button name="saveForm" type="submit" ID="btnSignIn" runat="server" Text="Sign In" OnClick="btnSignIn_Click" />
                    </div>
                    <ul class="list-login">
                        <li class="switch-agileits">
                            <%--<label class="switch">
                                <input type="checkbox">
                                <span class="slider round"></span>
                                keep me signed in
                            </label>--%>
                        </li>
                        <li class="clearfix"></li>
                    </ul>
                </form>
            </div>
        </div>
    </form>
</body>
</html>
