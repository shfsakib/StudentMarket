<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit-profile.aspx.cs" Inherits="StudentMarketWebApp.Seller.ViewProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Market | Seller</title>
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
                            <i class="far fa-bell"></i>
                            <span class="badge badge-warning navbar-badge">15</span>
                        </a>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link" data-toggle="dropdown" href="#">
                            <i class="fas fa-ellipsis-v fa-lg"></i>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right">
                            <a href="/Seller/edit-profile.aspx" class="dropdown-item">
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
                                <h3>View Profile</h3>
                            </div>
                            <hr />
                            <div class="col-md-12 card-body">
                                <div class="row">
                                    <div class="col-md-4"></div>
                                    <div class="col-md-4" style="text-align: center">
                                        <asp:Image ID="profilePictureImage" runat="server" ImageUrl="/DashboardFile/images/photo_dummy.png" class="rounded-circle" Width="250px" Height="250px" alt="profile_image" Style="border: 1px solid black;" />
                                    </div>
                                    <div class="col-md-4"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4"></div>
                                    <div class="col-md-4" style="text-align: center">
                                        <br />
                                        <asp:Label ID="nameLabel" runat="server" Style="font-family: comic sans ms; font-size: 20px;" Text="Label"></asp:Label>
                                    </div>
                                    <div class="col-md-4"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4"></div>
                                    <div class="col-md-4" style="text-align: center">
                                        <br />
                                        <a id="editButton" class="btn btn-primary" style="color: white;" title="Edit Profile"><i class="fas fa-pen" title="Edit Your Profile"></i>&nbsp;&nbsp;Edit</a>
                                    </div>
                                    <div class="col-md-4"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:Label ID="Label1" runat="server" Style="font-family: comic sans ms; font-size: 24px; font-weight: bold;" Text="Info : "></asp:Label>
                                    </div>
                                    <div class="col-md-4">
                                    </div>
                                    <div class="col-md-4"></div>
                                </div>
                                <div class="row">
                                    &nbsp;<br />
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        Email : 
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblEmail" runat="server" Style="font-family: comic sans ms; font-size: 16px;" Text="Email"></asp:Label>
                                    </div>
                                    <div class="col-md-2">
                                        Contact No. : 
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblMobile" runat="server" Style="font-family: comic sans ms; font-size: 16px;" Text="Mobile"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        Date of Birth : 
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblDOB" runat="server" Style="font-family: comic sans ms; font-size: 16px;" Text="Date of Birth"></asp:Label>
                                    </div>
                                    <div class="col-md-2">
                                        Gender : 
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblGender" runat="server" Style="font-family: comic sans ms; font-size: 16px;" Text="Gender"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        Nid No. : 
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblNid" runat="server" Style="font-family: comic sans ms; font-size: 16px;" Text="Nid No."></asp:Label>
                                    </div>
                                    <div class="col-md-2">
                                        Birth Certificate No. : 
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblBCert" runat="server" Style="font-family: comic sans ms; font-size: 16px;" Text="Birth Certificate No."></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        Guardian Nid No. : 
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblGNid" runat="server" Style="font-family: comic sans ms; font-size: 16px;" Text="Guardian Nid No."></asp:Label>
                                    </div>
                                    <div class="col-md-2">
                                        Password : 
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblPassword" runat="server" Style="font-family: comic sans ms; font-size: 16px;" Text="Password"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        About : 
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblAbout" runat="server" Style="font-family: comic sans ms; font-size: 16px;" Text="About"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:Label ID="Label2" runat="server" Style="font-family: comic sans ms; font-size: 24px; font-weight: bold;" Text="Location : "></asp:Label>
                                    </div>
                                    <div class="col-md-4">
                                    </div>
                                    <div class="col-md-4"></div>
                                </div>
                                <div class="row">
                                    &nbsp;<br />
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        Division : 
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblDivision" runat="server" Style="font-family: comic sans ms; font-size: 16px;" Text="Division"></asp:Label>
                                    </div>
                                    <div class="col-md-2">
                                        District : 
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblDistrict" runat="server" Style="font-family: comic sans ms; font-size: 16px;" Text="District"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <style>
                                .bg_personalInfor-model {
                                    width: 100%;
                                    height: 100%;
                                    background-color: rgba(0,0,0,0.7);
                                    display: none;
                                    margin-top: 70px;
                                    justify-content: center;
                                    align-items: center;
                                    position: absolute;
                                    top: 0;
                                    left: 0;
                                    overflow: hidden;
                                }
                            </style>
                            <div class="bg_personalInfor-model" id="popupDiv">
                                <div class="model_personalInfo" style="overflow: scroll; overflow-x: hidden; width: 400px; height: 700px; background-color: white; position: relative">
                                    <div class="close p-t-2" style="position: absolute; top: 0; right: 0; font-size: 35px; transform: rotate(90deg); cursor: pointer; font-family: arial, sans-serif;">x</div>
                                    <br />
                                    <br />
                                    <br />
                                    <div class="col-md-12">
                                        <div class="row">
                                            <div class="col-md-12">Name :</div>
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtName" runat="server" class="form-control1 wd" placeholder="Mr. xyz"></asp:TextBox>
                                            </div>
                                            <div class="col-md-12">Contact No. :</div>
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtMobile" runat="server" class="form-control1 wd" placeholder="01XXXXXXXXX"></asp:TextBox>
                                            </div>
                                            <div class="col-md-12">Date of Birth :</div>
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtDob" runat="server" class="form-control1 wd" placeholder="mm-dd-yyyy"></asp:TextBox>
                                            </div>
                                            <div class="col-md-12">Gender :</div>
                                            <div class="col-md-12">
                                                <asp:DropDownList ID="ddlGender" class="form-control1" runat="server">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                    <asp:ListItem>Male</asp:ListItem>
                                                    <asp:ListItem>Female</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-12">About :</div>
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtAbout" runat="server" class="form-control1 wd" placeholder="write something about you"></asp:TextBox>
                                            </div>
                                            <div class="col-md-12">Nid No. :</div>
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtNid" runat="server" class="form-control1 wd" placeholder="123456..."></asp:TextBox>
                                            </div>
                                            <div class="col-md-12">Birth Certificate No. :</div>
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtBCert" runat="server" class="form-control1 wd" placeholder="123456..."></asp:TextBox>
                                            </div>
                                            <div class="col-md-12">Guardian Nid No. :</div>
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtGNid" runat="server" class="form-control1 wd" placeholder="123456..."></asp:TextBox>
                                            </div>
                                            <div class="col-md-12">Password :</div>
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtPass" runat="server" class="form-control1 wd" placeholder="Enter your password"></asp:TextBox>
                                            </div>
                                            <div class="col-md-12">Picture :</div>
                                            <div class="col-md-12">
                                                <asp:FileUpload ID="userFileUpload" Style="width: 80%" onchange="ImagePreview(this);" class="form-control" accept=".png,.jpg,.jpeg" runat="server" />
                                            </div>
                                            <div class="col-md-12">
                                                <img id="userImage" src="/DashboardFile/images/photo_dummy.png" alt="employee Image" style="height: 250px; width: 250px" runat="server" class="form-control" />
                                            </div>

                                            <div class="col-md-12">
                                                <br />
                                            </div>
                                            <div class="col-md-12">
                                                <asp:Button ID="updateButton" OnClick="updateButton_OnClick" runat="server" Style="width: 100%;" Text="Update" class="btn btn-primary" title="Update Profile" />
                                            </div>
                                            <div class="col-md-12">
                                                <br />
                                            </div>
                                        </div>
                                    </div>
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

            $('#accordionSidebar').load("/Seller/menu.html");

        });
    </script>
    <script type="text/javascript">
        document.getElementById('editButton').addEventListener('click',
            function () {

                document.querySelector('.bg_personalInfor-model').style.display = 'flex';

            });
        document.querySelector('.close').addEventListener('click',
            function () {

                document.querySelector('.bg_personalInfor-model').style.display = 'none';
            });

    </script>
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
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=userImage.ClientID%>').prop('src', e.target.result)
                };
                reader.readAsDataURL(input.files[0]);
                }
            }

    </script>
</body>
</html>
