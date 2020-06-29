<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit-ad.aspx.cs" Inherits="StudentMarketWebApp.Seller.edit_ad" %>

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
                            <span class="badge badge-warning navbar-badge" runat="server"  id="countN"></span>
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
                                <h3>Ad Details</h3>
                            </div>
                            <hr />
                            <div class="col-md-12 card-body bc">
                                <div class="row">
                                    <div class="col-md-2"></div>
                                    <div class="col-md-8 table-responsive">
                                        <asp:GridView ID="adGridView" class="table table-bordered table-striped " Style="background: lavender;" runat="server" OnPageIndexChanging="categoryGridView_OnPageIndexChanging" OnRowCommand="adGridView_OnRowCommand" OnRowEditing="adGridView_OnRowEditing" OnRowUpdating="adGridView_OnRowUpdating" OnRowDeleting="adGridView_OnRowDeleting" OnRowCancelingEdit="adGridView_OnRowCancelingEdit" AutoGenerateColumns="False" ShowHeader="True" EmptyDataText="No Post Info Found" ShowHeaderWhenEmpty="True" AllowPaging="True" PageSize="10">
                                            <Columns>
                                                <asp:TemplateField HeaderText="">
                                                    <HeaderTemplate>
                                                        <table class="" width="100%">
                                                            <tr>
                                                                <th style="text-align: center">Choose_Picture</th>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:FileUpload ID="FileUpload" accept=".png,.jpg,.jpeg" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("PicId") %>' />   
                                                        <img id="repeaterImg" src='<%# Eval("Picture")%>' alt="photo" style="border: 2px solid black; cursor: pointer; width: 120px; height: 120px; border: 2px solid white;" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:HiddenField ID="HiddenField2" runat="server" Value='<%#Eval("PicId") %>'/>                                                                                                 
                                                        <asp:FileUpload ID="editFileUpload" accept=".png,.jpg,.jpeg" runat="server" />
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemStyle Width="20%"></ItemStyle>
                                                    <HeaderTemplate>
                                                        <table class="" width="100%">
                                                            <tr>
                                                                <th>
                                                                    <label>Action</label>
                                                                </th>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ID="addNewButton1" runat="server" class="btn btn-primary" CommandName="AddNew" ToolTip="Add New"><i class="fas fa-plus fa-lg"></i></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="editButton" runat="server" class="" CommandName="Edit" ToolTip="Edit"><i class="fas fa-edit fa-lg"></i></asp:LinkButton>
                                                        <asp:LinkButton ID="deleteButton" runat="server" class="" CommandName="Delete" ToolTip="Delete"><i class="fas fa-trash-alt fa-lg"></i></asp:LinkButton>

                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="updateButton" runat="server" class="" CommandName="Update" ToolTip="Update"><i class="fas fa-save fa-2x"></i></asp:LinkButton>
                                                        <asp:LinkButton ID="cancelButton1" runat="server" class="" CommandName="Cancel" ToolTip="Cancel"><i class="fas fa-times fa-2x"></i></asp:LinkButton>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div class="col-md-2"></div>
                                </div>
                                <div class="row">
                                    &nbsp;<br />
                                </div>
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
                                        <asp:TextBox ID="txtDescription" class="form-control1 wd" TextMode="MultiLine" Style="height: 80px;" placeholder="About your product and more" runat="server"></asp:TextBox>
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
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Button ID="btnUpdate" class="btn btn-primary" OnClick="btnUpdate_OnClick" runat="server" Text="Update" />
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
    <link href="../DashboardFile/AutoComplete-jquery-ui.css" rel="stylesheet" />
    <script src="../DashboardFile/Autocomplete-jquery-ui.js"></script>
    <script type="text/javascript">
        function SetTarget() {
            document.forms[0].target = "_blank";
        }
    </script>
</body>
</html>
