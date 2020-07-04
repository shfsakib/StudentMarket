<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order-history.aspx.cs" Inherits="StudentMarketWebApp.Seller.order_history" %>

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
                        <a class="nav-link" href="/Seller/notification.aspx">
                            <i class="far fa-bell"></i>
                            <span class="badge badge-warning navbar-badge" runat="server" id="countN"></span>
                        </a>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link" data-toggle="dropdown" href="#">
                            <i class="fas fa-ellipsis-v fa-lg"></i>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right">
                            <a href="/Buyer/edit-profile.aspx" class="dropdown-item">
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
                                <h3>Notification</h3>
                            </div>
                            <hr />
                            <div class="col-md-12 card-body bc">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive" style="border: none;">
                                            <asp:GridView ID="historyGridView" class="table table-bordered table-striped " runat="server" OnPageIndexChanging="historyGridView_OnPageIndexChanging" OnRowDataBound="historyGridView_OnRowDataBound" AutoGenerateColumns="False" ShowHeader="False" EmptyDataText="No Notification Found" ShowHeaderWhenEmpty="True" AllowPaging="True" PageSize="30">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Serial" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="slLabel" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="col-md-12">
                                                                <div class="row">
                                                                    <div class="col-md-2">
                                                                        <asp:HiddenField ID="HiddenField2" runat="server" Value='<%#Eval("BuyId") %>' />
                                                                        <asp:HiddenField ID="idHiddenField" runat="server" Value='<%#Eval("PostId") %>' />
                                                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("BuyerId") %>' />
                                                                        <asp:Image ID="profileImage" ImageUrl='<%#Eval("Picture")%>' runat="server" Style="width: 75px; height: 75px;" />
                                                                    </div>
                                                                    <div class="col-md-8">
                                                                        <h4>
                                                                            <asp:Label ID="titleLabel" runat="server" Text='<%#"You"+" have "+Eval("Status") +Eval("Name")+" request for "+Eval("ProductName")%>'></asp:Label>
                                                                            <asp:LinkButton ID="titleLinkButton" OnClick="titleLinkButton_OnClick" title="View Profile" runat="server"></asp:LinkButton>
                                                                        </h4>
                                                                        <br />
                                                                        <asp:Label ID="Label1" runat="server" Text='<%#"Quantity : "+Eval("Quantity")%>'></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label2" runat="server" Text='<%#"DeadLine : "+Eval("DeadLine")%>'></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label3" runat="server" Style="color: green;" Text='<%#"Price : "+"৳"+Eval("Price")%>'></asp:Label>
                                                                        <br />
                                                                        <asp:Label runat="server" Style="color: green; font-size: 18px;" Text='<%#"Total Price : ৳"+Eval("TotalPrice")%>'></asp:Label><br />
                                                                    </div>
                                                                    <div class="col-md-2">
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
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

            $('#accordionSidebar').load("/Buyer/menu.html");

        });
    </script>

</body>
</html>
