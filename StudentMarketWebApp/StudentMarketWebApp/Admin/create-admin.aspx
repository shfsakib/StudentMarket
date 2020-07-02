<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create-admin.aspx.cs" Inherits="StudentMarketWebApp.Admin.create_admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Market | Admin</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
    <!-- Font Awesome Icons -->
    <link rel="stylesheet" href="/DashboardFile/Admin/plugins/fontawesome-free/css/all.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="/DashboardFile/Admin/dist/css/adminlte.min.css" />
    <script src="../DashboardFile/style.js"></script>
    <link href="../DashboardFile/PopDiv.css" rel="stylesheet" />
    <script src="../DashboardFile/Custom/FontAwesome.js"></script>
    <link href="../DashboardFile/Custom/sweet-alert.css" rel="stylesheet" />
    <script src="../DashboardFile/Custom/sweetalert2.all.min.js"></script>
    <script src="../DashboardFile/Custom/sweetalert2@9.js"></script>
    <link href="../DashboardFile/PopDiv.css" rel="stylesheet" />
</head>
<body class="hold-transition sidebar-mini">
    <div class="wrapper">
        <!-- Navbar -->
        <form runat="server">
            <nav class="main-header navbar navbar-expand navbar-white navbar-light">
                <!-- Left navbar links -->
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" data-widget="pushmenu" href="#" role="button"><i class="fas fa-bars"></i></a>
                    </li>
                </ul>
                <!-- SEARCH FORM -->
                <!-- SEARCH FORM -->
                <!-- Right navbar links -->
                <ul class="navbar-nav ml-auto">
                    <!-- Messages Dropdown Menu -->
                    <!-- Notifications Dropdown Menu -->
                    <li class="nav-item dropdown">
                        <a class="nav-link" data-toggle="dropdown" href="#">
                            <i class="fas fa-ellipsis-v fa-lg"></i>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right">
                            <a href="/Admin/edit-profile.aspx" class="dropdown-item">
                                <!-- Message Start -->
                                Edit Profile
                           <!-- Message End -->
                            </a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" id="logOut" runat="server" onserverclick="logOut_OnServerClick">
                                <!-- Message Start -->
                                Log out
                            <!-- Message End -->
                            </a>
                        </div>
                    </li>
                </ul>
            </nav>
            <!-- /.navbar -->
            <!-- Main Sidebar Container -->
            <%  HttpCookie cookieData = HttpContext.Current.Request.Cookies["Stu"]; %>
            <aside class="main-sidebar sidebar-dark-primary elevation-4" data-visible="true">
                <!-- Brand Logo -->
                <a href="/Admin/add-category.aspx" class="brand-link">
                    <img src="../DashboardFile/images/favSmall.png" alt="AdminLTE Logo" class="brand-image img-circle elevation-3" style="opacity: .8" />
                    <span class="brand-text font-weight-light">StuMarket</span>
                </a>
                <!-- Sidebar -->
                <div class="sidebar">
                    <!-- Sidebar user panel (optional) -->
                    <div class="user-panel mt-3 pb-3 mb-3 d-flex">
                        <div class="image">
                            <img src='<% =cookieData["Picture"].ToString()%>' class="img-circle elevation-2" alt="User Image" />
                        </div>
                        <div class="info">
                            <a href="#" class="d-block"><% =cookieData["Name"].ToString()%></a>
                        </div>
                    </div>
                    <!-- Sidebar Menu -->
                    <nav class="mt-2">
                        <ul class="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false" id="accordionSidebar">
                            <!-- Add icons to the links using the .nav-icon class
                             with font-awesome or any other icon font library -->

                        </ul>
                    </nav>
                    <!-- /.sidebar-menu -->
                </div>
                <!-- /.sidebar -->
            </aside>
            <!-- Content Wrapper. Contains page content -->
            <div class="content-wrapper">
                <!-- Content Header (Page header) -->
                <div class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.container-fluid -->
                </div>
                <!-- /.content-header -->
                <!-- Main content -->
                <div class="content">
                    <div class="container-fluid">
                        <div class="col-md-12 card card-primary card-outline">
                            <div class="card-title">
                                <h3>Posted Ads</h3>
                            </div>
                            <hr />
                            <div class="col-md-12 card-body bc">
                                <div class="row">
                                    <div class="col-md-2"></div>
                                    <div class="col-md-2">Name : </div>
                                    <div class="col-md-6">
                                        <input type="text" runat="server" class="form-control1 wd" placeholder="Mr. xyz" id="nameTextBox" />
                                    </div>
                                    <div class="col-md-2"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2"></div>
                                    <div class="col-md-2">Email : </div>
                                    <div class="col-md-6">
                                        <input class="form-control1 wd" id="txtEmail" autocomplete="off" runat="server" type="email" placeholder="example@example.com" />
                                    </div>
                                    <div class="col-md-2"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2"></div>
                                    <div class="col-md-2">Mobile No. : </div>
                                    <div class="col-md-6">
                                        <input type="number" runat="server" autocomplete="off" class="form-control1 wd" placeholder="01XXXXXXXXX" id="mobileNoTextBox" />
                                    </div>
                                    <div class="col-md-2"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2"></div>
                                    <div class="col-md-2">Nid No. : </div>
                                    <div class="col-md-6">
                                        <input type="number" runat="server" autocomplete="off" class="form-control1 wd" placeholder="123456..." id="nidTextBox" />
                                    </div>
                                    <div class="col-md-2"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2"></div>
                                    <div class="col-md-2">Date of Birth : </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="dateofBirthTextBox" autocomplete="off" class="form-control1 wd" runat="server" required="required" placeholder="dd/mm/yyyy"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2"></div>
                                    <div class="col-md-2">Gender : </div>
                                    <div class="col-md-6">
                                        <asp:RadioButton ID="maleRadioButton" runat="server" Text="Male" GroupName="gender" Checked="True" />
                                        <asp:RadioButton ID="femaleRadioButton" runat="server" Text="Female" GroupName="gender" />
                                    </div>
                                    <div class="col-md-2"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2"></div>
                                    <div class="col-md-2">Profile Picture : </div>
                                    <div class="col-md-6">
                                        <asp:FileUpload ID="profilePicFileUpload" onchange="ImagePreview(this);" class="form-control1 wd" accept=".png,.jpg,.jpeg" alt="profile pic" required="required" runat="server" />
                                    </div>
                                    <div class="col-md-2"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2"></div>
                                    <div class="col-md-2"></div>
                                    <div class="col-md-6">
                                        <br />
                                        <img id="profilePicImage" runat="server" class="form-control1 wd" src="/DashboardFile/images/photo_dummy.png" alt="ProfilePic" style="height: 250px; width: 250px" />
                                    </div>
                                    <div class="col-md-2"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2"></div>
                                    <div class="col-md-2">Type : </div>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="typeDropDownList" class="form-control1 wd" required="required" runat="server">
                                            <asp:ListItem Text="Select"></asp:ListItem>
                                            <asp:ListItem Text="Super Admin"></asp:ListItem>
                                            <asp:ListItem Text="Admin"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2"></div>
                                    <div class="col-md-2">Password : </div>
                                    <div class="col-md-6">
                                        <input type="text" runat="server" autocomplete="off" class="form-control1 wd" placeholder="enter password" id="passwordTextBox" />
                                    </div>
                                    <div class="col-md-2"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2"></div>
                                    <div class="col-md-2">Confirm Password : </div>
                                    <div class="col-md-6">
                                        <input type="text" runat="server" autocomplete="off" class="form-control1 wd" placeholder="confirm password" id="confirmPasswordTextBox" />
                                    </div>
                                    <div class="col-md-2"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2"></div>
                                    <div class="col-md-2"></div>
                                    <div class="col-md-6">
                                        <asp:LinkButton ID="createButton" OnClick="createButton_OnClick" Style="width: 100%;" runat="server" class="btn btn-primary"> <i class="icon-add_to_queue"></i> Create</asp:LinkButton>
                                    </div>
                                    <div class="col-md-2"></div>
                                </div>
                            </div>
                            <!-- /.row -->
                        </div>

                    </div>

                    <!-- /.container-fluid -->
                </div>
                <!-- /.content -->
            </div>

            <!-- /.content-wrapper -->
            <!-- Control Sidebar -->

            <!-- /.control-sidebar -->
            <!-- Main Footer -->
            <footer class="main-footer">
                <!-- To the right -->
                <!-- Default to the left -->
                <strong>Copyright &copy; 2020.</strong> All rights reserved.
            </footer>
        </form>
    </div>
    <script src="/DashboardFile/Admin/plugins/jquery/jquery.min.js"></script>
    <!-- Bootstrap 4 -->
    <script src="/DashboardFile/Admin/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- AdminLTE App -->
    <script src="/DashboardFile/Admin/dist/js/adminlte.min.js"></script>
    <script>
        $(document).ready(function () {

            $('#accordionSidebar').load("/Admin/menu.html");

        });
    </script>
    <script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=profilePicImage.ClientID%>').prop('src', e.target.result)
                        .width(200)
                        .height(200);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }

    </script>
    <link href="../DashboardFile/AutoComplete-jquery-ui.css" rel="stylesheet" />
    <script src="../DashboardFile/Date-jquery-1.12.4.js"></script>
    <script src="../DashboardFile/Date-jquery-ui.js"></script>
    <script>
        $(function () {
            $("#dateofBirthTextBox").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd-mm-yy',
                yearRange: '1901:2099'
            });
        });
    </script>
</body>
</html>
