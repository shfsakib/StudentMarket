using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;

namespace StudentMarketWebApp.Web
{
    public partial class login : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private UserListModel userListModel;
        private UserListGateway userListGateway;

        public login()
        {
            func = BaseClass.GetInstance();
            alert = Alert.GetInstance();
            userListModel = UserListModel.GetInstance();
            userListGateway = UserListGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookies = HttpContext.Current.Request.Cookies["Stu"];
                if (cookies != null)
                {
                    if (cookies["Type"].ToString() == "Buyer")
                    {
                        Response.Redirect("/Buyer/view-ads.aspx");
                    }
                    else if (cookies["Type"].ToString() == "Seller")
                    {
                        Response.Redirect("/Seller/post-ad.aspx");
                    }
                    else if (cookies["Type"].ToString() == "Admin")
                    {
                        Response.Redirect("/Admin/add-category.aspx");
                    }
                    else if (cookies["Type"].ToString() == "Super Admin")
                    {
                        Response.Redirect("/Admin/add-category.aspx");
                    }
                }
                else
                {
                    txtEmail.Focus();
                }
            }
        }

        protected void btnLogin_OnServerClick(object sender, EventArgs e)
        {
            if (txtEmail.Value == "")
                func.Alert(Page, "Email id required", "w", true);
            else if (txtPassword.Value == "")
                func.Alert(Page, "Password id required", "w", true);
            else
            {
                string password =
                    func.IsExist(
                        $"SELECT Password FROM UserList WHERE Email='{txtEmail.Value}' AND Password='{txtPassword.Value}' AND Status='A' COLLATE Latin1_General_CS_AI");
                if (password == txtPassword.Value)
                {
                    HttpCookie cookie = new HttpCookie("Stu");
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    cookie["Name"] = func.IsExist($"SELECT Name FROM UserList WHERE Email='{txtEmail.Value}'");
                    cookie["Type"] = func.IsExist($"SELECT Type FROM UserList WHERE Email='{txtEmail.Value}'");
                    cookie["UserId"] = func.IsExist($"SELECT UserId FROM UserList WHERE Email='{txtEmail.Value}'");
                    cookie["Picture"] = func.IsExist($"SELECT Picture FROM UserList WHERE Email='{txtEmail.Value}'");
                    cookie["Mobile"] = func.IsExist($"SELECT MobileNo FROM UserList WHERE Email='{txtEmail.Value}'");
                    cookie["Email"] = func.IsExist($"SELECT Email FROM UserList WHERE Email='{txtEmail.Value}'");
                    cookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cookie);
                    if (cookie["Type"].ToString() == "Buyer")
                    {
                        Response.Redirect("/Buyer/view-ads.aspx");
                    }
                    else if (cookie["Type"].ToString() == "Seller")
                    {
                        Response.Redirect("/Seller/post-ad.aspx");
                    }
                }
                else
                {
                    string password1 =
                        func.IsExist(
                            $"SELECT Password FROM Admin WHERE Email='{txtEmail.Value}' AND Password='{txtPassword.Value}' AND Status='Active' COLLATE Latin1_General_CS_AI");
                    if (password1 == txtPassword.Value)
                    {
                        HttpCookie cookie = new HttpCookie("Stu");
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(cookie);
                        cookie["Name"] = func.IsExist($"SELECT Name FROM Admin WHERE Email='{txtEmail.Value}'");
                        cookie["Type"] = func.IsExist($"SELECT Type FROM Admin WHERE Email='{txtEmail.Value}'");
                        cookie["UserId"] = func.IsExist($"SELECT AdminId FROM Admin WHERE Email='{txtEmail.Value}'");
                        cookie["Picture"] =
                            func.IsExist($"SELECT ProfilePicture FROM Admin WHERE Email='{txtEmail.Value}'");
                        cookie["Mobile"] = func.IsExist($"SELECT MobileNumber FROM Admin WHERE Email='{txtEmail.Value}'");
                        cookie["Email"] = func.IsExist($"SELECT Email FROM Admin WHERE Email='{txtEmail.Value}'");
                        cookie.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(cookie);
                        if (cookie["Type"].ToString() == "Admin")
                        {
                            Response.Redirect("/Admin/add-category.aspx");
                        }
                        else if (cookie["Type"].ToString() == "Super Admin")
                        {
                            Response.Redirect("/Admin/add-category.aspx");
                        }
                    }
                    else
                    {
                        func.Alert(Page, "Invalid email & password", "w", true);
                    }

                }
            }
        }

        protected void lnkForgot_OnClick(object sender, EventArgs e)
        {
            if (txtEmail.Value == "")
                func.Alert(Page, "Email id required", "w", true);
            else
            {
                string x = func.IsExist($"SELECT Password FROM UserList WHERE Email='{txtEmail.Value}'");
                if (x == "")
                {
                    func.Alert(Page, "Email id does not exist for buyer or seller", "w", true);
                }
                else
                {
                    bool result = func.SendEmail("StuMarket5713@gmail.com", txtEmail.Value, "Recover Password", "Hello User,<br/>Your Password is : "+x+"<br/>", "Admin4321");
                    if (result)
                    {
                        func.Alert(Page, "Your password has been sent to your email id.", "s", true);
                    }
                    else
                    {
                        func.Alert(Page, "Recover password failed,Please contact with admin.", "e", true);

                    }
                }
            }
        }
    }
}