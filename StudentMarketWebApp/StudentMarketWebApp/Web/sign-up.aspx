<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sign-up.aspx.cs" Inherits="StudentMarketWebApp.Web.sign_up" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign up</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="Colorlib Templates" />
    <meta name="author" content="Colorlib" />
    <meta name="keywords" content="Colorlib Templates" />
    <!-- Icons font CSS-->
    <link href="/DashboardFile/Signup/avendor/mdi-font/css/material-design-iconic-font.min.css" rel="stylesheet" media="all">
    <link href="/DashboardFile/Signup/vendor/font-awesome-4.7/css/font-awesome.min.css" rel="stylesheet" media="all">
    <!-- Font special for pages-->
    <link href="https://fonts.googleapis.com/css?family=Poppins:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">

    <!-- Vendor CSS-->
    <link href="/DashboardFile/Signup/vendor/select2/select2.min.css" rel="stylesheet" media="all">
    <link href="/DashboardFile/Signup/vendor/datepicker/daterangepicker.css" rel="stylesheet" media="all">
    <link href="../DashboardFile/Custom/sweet-alert.css" rel="stylesheet" />
    <script src="../DashboardFile/Custom/sweetalert2.all.min.js"></script>
    <script src="../DashboardFile/Custom/sweetalert2@9.js"></script>
    <!-- Main CSS-->
    <link href="/DashboardFile/Signup/css/main.css" rel="stylesheet" media="all">

</head>
<body>
    <div class="page-wrapper bg-gra-02 p-t-130 p-b-100 font-poppins">
        <div class="wrapper wrapper--w680">
            <div class="card card-4">
                <div class="card-body">
                    <h2 class="title">Registration Form</h2>
                    <form runat="server">
                        <div class="input-group">
                            <div class="col-4">
                                <div class="input-group">
                                    <label class="label">first name</label>
                                    <input class="input--style-4" id="txtname" runat="server" type="text" autocomplete="off" placeholder="Mr. xyz" />
                                </div>
                            </div>
                        </div>
                        <div class="row row-space">
                            <div class="col-2">
                                <div class="input-group">
                                    <label class="label">Email</label>
                                    <input class="input--style-4" id="txtEmail" autocomplete="off" runat="server" type="email" placeholder="example@example.com" />
                                </div>
                            </div>
                            <div class="col-2">
                                <div class="input-group">
                                    <label class="label">Mobile</label>
                                    <input class="input--style-4" id="txtMobile" autocomplete="off" runat="server" type="text" placeholder="01XXXXXXXXX" />
                                </div>
                            </div>
                        </div>
                        <div class="row row-space">
                            <div class="col-2">
                                <div class="input-group">
                                    <label class="label">Birthday</label>
                                    <div class="input-group-icon">
                                        <input class="input--style-4" id="txtDob" autocomplete="off" runat="server" type="text" placeholder="dd-mm-yyyy" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-2">
                                <div class="input-group">
                                    <label class="label">Gender</label>
                                    <asp:DropDownList ID="ddlGender" class="form-control1" runat="server">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row row-space">
                            <div class="col-2">
                                <div class="input-group">
                                    <label class="label">Division</label>
                                    <asp:DropDownList ID="ddlDivision" AutoPostBack="True" OnSelectedIndexChanged="ddlDivision_OnSelectedIndexChanged" class="form-control1" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-2">
                                <div class="input-group">
                                    <label class="label">District</label>
                                    <asp:DropDownList ID="ddlDistrict" class="form-control1" runat="server">
                                        <asp:ListItem>--SELECT--</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="input-group">
                            <div class="col-4">
                                <div class="input-group">
                                    <label class="label">Address</label>
                                    <asp:TextBox ID="txtAddress" runat="server" autocomplete="off" class="input--style-4" Height="50px" placeholder="Address"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <div class="row row-space">
                             <div class="col-2">
                                <div class="input-group">
                                    <label class="label">User Type</label>
                                     <asp:DropDownList ID="ddlType" class="form-control1" runat="server">
                                        <asp:ListItem Value="Select">Select</asp:ListItem>
                                        <asp:ListItem Value="Buyer">Buyer</asp:ListItem>
                                        <asp:ListItem Value="Seller">Seller</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-2">
                                <div class="input-group">
                                    <label class="label">Password</label>
                                    <asp:TextBox ID="txtPassword" runat="server" autocomplete="off" class="input--style-4" placeholder="Enter Password" MaxLength="20"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="input-group">
                            <div class="col-2">
                                <div class="input-group">
                                    <label class="label">Picture</label>
                                    <asp:FileUpload ID="filePicture" onchange="ImagePreview(this);" class="" runat="server" accept=".png,.jpg,.jpeg" />
                                </div>
                            </div>
                        </div>
                        <div class="input-group">
                            <div class="col-2">
                                <div class="input-group">
                                    <asp:Image ID="imgProfile" runat="server" Width="175px" Height="175px" ImageUrl="/DashboardFile/images/photo_dummy.png" alt="picture" Style="border: 1px solid black;" />
                                </div>
                            </div>
                        </div>
                        <div class="p-t-15">
                            <button class="btn btn--radius-2 btn--blue" type="submit" id="btnSignup" runat="server" OnServerClick="btnSignup_OnServerClick">Sign up</button>
                            <span>Back to <a href="/Web/login.aspx">Login</a></span>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <!-- Jquery JS-->
    <script src="/DashboardFile/Signup/vendor/jquery/jquery.min.js"></script>
    <!-- Vendor JS-->
    <script src="/DashboardFile/Signup/vendor/select2/select2.min.js"></script>
    <script src="/DashboardFile/Signup/vendor/datepicker/moment.min.js"></script>
    <script src="/DashboardFile/Signup/vendor/datepicker/daterangepicker.js"></script>

    <!-- Main JS-->
    <script src="/DashboardFile/Signup/js/global.js"></script>
    <link href="../DashboardFile/AutoComplete-jquery-ui.css" rel="stylesheet" />
    <script src="../DashboardFile/Date-jquery-1.12.4.js"></script>
    <script src="../DashboardFile/Date-jquery-ui.js"></script>
    <script>
        $(function () {
            $("#txtDob").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd-mm-yy',
                yearRange: '1901:2099'
            });
        });
    </script>
    <script>
        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgProfile.ClientID%>').prop('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }
    </script>
</body>
</html>
