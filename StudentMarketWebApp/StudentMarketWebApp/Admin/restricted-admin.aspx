<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="restricted-admin.aspx.cs" Inherits="StudentMarketWebApp.Admin.restricted_admin" %>

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
                                <h3>Restricted Admin List</h3>
                            </div>
                            <hr />
                            <div class="col-md-12 card-body bc">
                                <div class="row">
                                    <div class="col-md-5">
                                        <asp:TextBox ID="txtSearch" class="form-control1 wd" placeholder="Search Profile" AutoPostBack="True" OnTextChanged="txtSearch_OnTextChanged" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-5"></div>
                                    <div class="col-md-2">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive" style="border: none;">
                                            <asp:GridView ID="adminGridView" EmptyDataText="No Data Found !" class="table table-bordered table-striped" runat="server" AutoGenerateColumns="False" CellPadding="3" PageSize="15" AllowPaging="True" OnPageIndexChanging="adminGridView_OnPageIndexChanging" HorizontalAlign="Left" ShowHeaderWhenEmpty="True">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SL">
                                                        <ItemTemplate>
                                                            <asp:Label ID="slLabel" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                            <asp:HiddenField ID="idHiddenField" runat="server" Value='<%#Eval("AdminId") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Email">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text=' <%#Eval("Email") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Mobile No.">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text=' <%#Eval("MobileNumber") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Nid No.">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text=' <%#Eval("NidNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Gender">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text=' <%#Eval("Gender") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="DateofBirth">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text=' <%#Eval("DateofBirth") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Profile Pic">
                                                        <ItemTemplate>
                                                            <asp:Image ID="profilesImage" ImageUrl='<%#Eval("ProfilePicture")%>' runat="server" Style="width: 50px; height: 50px;" /><br />
                                                            </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Type">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text=' <%#Eval("Type") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Refered By">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text=' <%#Eval("ReferedBy") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="In Time">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text=' <%#Eval("InTime") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <div class="">
                                                                <asp:LinkButton runat="server" ID="restrictLinkButton" OnClick="restrictLinkButton_OnClick" class="btn btn-success" Style="color: white; width: 100%">Activate</asp:LinkButton>
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

            $('#accordionSidebar').load("/Admin/menu.html");

        });
    </script>
    <link href="../DashboardFile/AutoComplete-jquery-ui.css" rel="stylesheet" />
    <script src="../DashboardFile/Autocomplete-jquery-ui.js"></script>
    <script>
        $("#<%=txtSearch.ClientID %>").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "Admin.asmx/GetBuyers",
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: "{ 'txt' : '" + $("#<%=txtSearch.ClientID %>").val() + "'}",
                    dataFilter: function (data) { return data; },
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item,
                                value: item
                            };
                        }));
                    },
                    error: function (result) {
                        Swal.fire({
                            position: 'center',
                            icon: 'warning',
                            title: 'User not found',
                            showConfirmButton: true,
                            timer: 6000
                        });
                    }
                });
            },

            minLength: 1,
        });
    </script>
    <script type="text/javascript">
        function SetTarget() {
            document.forms[0].target = "_blank";
        }
    </script>
</body>
</html>
