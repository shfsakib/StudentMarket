<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="StudentMarketWebApp.Web.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log in</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="/DashboardFile/Login/images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="/DashboardFile/Login/vendor/bootstrap/css/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="/DashboardFile/Login/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="/DashboardFile/Login/fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="/DashboardFile/Login/vendor/animate/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="/DashboardFile/Login/vendor/css-hamburgers/hamburgers.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="/DashboardFile/Login/vendor/animsition/css/animsition.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="/DashboardFile/Login/vendor/select2/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="/DashboardFile/Login/vendor/daterangepicker/daterangepicker.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="/DashboardFile/Login/css/util.css">
    <link rel="stylesheet" type="text/css" href="/DashboardFile/Login/css/main.css">
    <link href="../DashboardFile/Custom/sweet-alert.css" rel="stylesheet" />
    <script src="../DashboardFile/Custom/sweetalert2.all.min.js"></script>
    <script src="../DashboardFile/Custom/sweetalert2@9.js"></script>
    <link href="../DashboardFile/PopDiv.css" rel="stylesheet" />
    <script src="../DashboardFile/style.js"></script>

</head>
<body>
    <div class="limiter">
        <div class="container-login100" style="background-image: url('/DashboardFile/Login/images/bg-01.jpg');">
            <div class="wrap-login100 p-t-30 p-b-50">
                <span class="login100-form-title p-b-41">Login
                </span>
                <form class="login100-form validate-form p-b-33 p-t-5" runat="server">
                    <div class="wrap-input100 validate-input" data-validate="Enter username">
                        <input class="input100" type="text" id="txtEmail" runat="server" name="username" placeholder="User name" autocomplete="off" />
                        <span class="focus-input100" data-placeholder="&#xe82a;"></span>
                    </div>

                    <div class="wrap-input100 validate-input" data-validate="Enter password">
                        <input class="input100" id="txtPassword" runat="server" type="password" name="pass" placeholder="Password" />
                        <span class="focus-input100" data-placeholder="&#xe80f;"></span>
                    </div>
                    <div class="wrap-input100 validate-input ml-4">
                        <asp:LinkButton ID="lnkForgot" runat="server" Style="color: blue;" OnClick="lnkForgot_OnClick">Forgot Password?</asp:LinkButton>
                    </div>
                    <div class="container-login100-form-btn m-t-32">
                        <button class="login100-form-btn" id="btnLogin" runat="server" onserverclick="btnLogin_OnServerClick">Login</button>
                    </div>
                    <br />
                    <span style="margin-left: 30px">Don't have an account?<a href="/Web/sign-up.aspx">Sign up</a></span><br />
                    <span style="margin-left: 30px">Back to<a href="/Web/sign-up.aspx">Home</a></span>
                </form>
            </div>
        </div>
    </div>
    <div id="dropDownSelect1"></div>
    <!--==============================================================================================-->
    <script src="/DashboardFile/Login/vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="/DashboardFile/Login/vendor/animsition/js/animsition.min.js"></script>
    <!--===============================================================================================-->
    <script src="/DashboardFile/Login/vendor/bootstrap/js/popper.js"></script>
    <script src="/DashboardFile/Login/vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="/DashboardFile/Login/vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="/DashboardFile/Login/vendor/daterangepicker/moment.min.js"></script>
    <script src="/DashboardFile/Login/vendor/daterangepicker/daterangepicker.js"></script>
    <!--===============================================================================================-->
    <script src="/DashboardFile/Login/vendor/countdowntime/countdowntime.js"></script>
    <!--===============================================================================================-->
    <script src="/DashboardFile/Login/js/main.js"></script>
</body>
</html>
