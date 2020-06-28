<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="post-ad.aspx.cs" Inherits="StudentMarketWebApp.Seller.post_ad" %>

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
                <style>
                    input[type="file"] {
                        display: block;
                    }

                    .imageThumb {
                        max-height: 175px;
                        border: 2px solid;
                        padding: 1px;
                        cursor: pointer;
                        width: 175px;
                        height: 300px;
                    }

                    .pip {
                        display: inline-block;
                        margin: 10px 10px 0 0;
                    }

                    .upload-btn-wrapper {
                        position: relative;
                        overflow: hidden;
                        display: inline-block;
                    }

                    /*.btns {
                        border: 2px solid gray;
                        color: gray;
                        background-color: white;
                        padding: 8px 20px;
                        border-radius: 8px;
                        font-size: 20px;
                        font-weight: bold;
                    }*/

                    .upload-btn-wrapper input[type=file] {
                        font-size: 100px;
                        position: absolute;
                        left: 0;
                        top: 0;
                        opacity: 0;
                    }
                </style>
                <div class="content">
                    <div class="container-fluid">
                        <div class="col-md-12 card card-primary card-outline">
                            <div class="card-title">
                                <h3>Post Ad</h3>
                            </div>
                            <hr />
                            <div class="col-md-12 card-body bc">
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">
                                        Choose Category : 
                                    </div>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlCategory" class="form-control1 wd" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-3"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">
                                       Product Name : 
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtProductName" class="form-control1 wd" placeholder="Pencil box,Website etc" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3"></div>
                                </div>
                                 <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">
                                       Description : 
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtDescription" class="form-control1 wd" TextMode="MultiLine" style="height: 80px;" placeholder="About your product and more" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3"></div>
                                </div>
                                 <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">
                                       Price : 
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtPrice" class="form-control1 wd" TextMode="Number" placeholder="৳2000" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12" style="text-align: center;">
                                        <div class="upload-btn-wrapper col-md-12" id="divs" style="text-align: center;">
                                            <button class="btn btn-primary" style="height: 40px; width:50%;"><i class="fas fa-camera"></i>&nbsp;&nbsp;Upload Image</button>
                                            <asp:FileUpload class="files" id="files" runat="server" name="files[]" AllowMultiple="True" accept=".png,.jpg,.jpeg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="lblfileSize" Visible="False" runat="server" Text="Label"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Button ID="btnPost" runat="server" class="btn btn-success" style="margin-top: 5px; width: 100%;" title="Post Ad" OnClick="btnPost_OnClick" Text="Post Ad" />
                                    </div>
                                    <div class="col-md-3"></div>
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
    <script>
        $(document).ready(function () {
            if (window.File && window.FileList && window.FileReader) {
                $("#files").on("change", function (e) {
                    var files = e.target.files,
                      filesLength = files.length;
                    $("#<%=lblfileSize.ClientID %>").text(filesLength);
                    if (filesLength < 6) {
                        for (var i = 0; i < filesLength; i++) {
                            var f = files[i];
                            var fileReader = new FileReader();
                            fileReader.onload = (function(e) {
                                var file = e.target;
                                $("<span class=\"pip\">" +
                                    "<img class=\"imageThumb\" src=\"" + e.target.result + "\" title=\"" + file.name + "\"/>" +
                                    "<br/>" +
                                    "</span>").insertAfter("#divs");
                                //<span class=\"remove btn btn-danger\" style=\"width:100%;\"><i class=\"fas fa-trash-alt\"></i>Remove</span>
                                //$(".remove").click(function () {

                                //    $(this).parent(".pip").remove();
                                //    $(this).parent(".files").remove();

                                //});
                            });
                            fileReader.readAsDataURL(f);
                        }
                    } else {
                        Swal.fire({
                            position: 'center',
                            icon: 'warning',
                            title: 'Please choose maximum 5 photos',
                            showConfirmButton: true,
                            timer: 6000
                        });
                    }
                });
            }
            else {
                Swal.fire({
                    position: 'center',
                    icon: 'warning',
                    title: 'Your browser does not support to File API',
                    showConfirmButton: true,
                    timer: 6000
                });
                }
        });
    </script>
</body>
</html>
