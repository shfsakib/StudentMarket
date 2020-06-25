using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitSoftware;
using StudentMarketWebApp.DAL.Gateway;
using StudentMarketWebApp.DAL.Model;

namespace StudentMarketWebApp.Web
{
    public partial class login : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private UserListModel userListModel;
        private UserListGateway userListGateway;
        HttpCookie cookie = new HttpCookie("Stu");
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
                    Response.Redirect("http://www.microsoft.com/gohere/look.htm");
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
                if (password==txtPassword.Value)
                {
                    cookie["Name"]= func.IsExist($"SELECT Name FROM UserList WHERE Email='{txtEmail.Value}'");
                    cookie["Type"]= func.IsExist($"SELECT Type FROM UserList WHERE Email='{txtEmail.Value}'");
                    cookie["UserId"]= func.IsExist($"SELECT UserId FROM UserList WHERE Email='{txtEmail.Value}'");
                    cookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cookie);
                    Response.Redirect("http://www.microsoft.com/gohere/look.htm");

                }
                else
                {
                    func.Alert(Page, "Invalid email & password", "w", true);
                }
            }
        }
    }
}