using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;
using ShabolombiAndroidApp.DLL.Gateway;
using ShabolombiAndroidApp.DLL.Model;

namespace StudentMarketWebApp.Admin
{
    public partial class admin_list : System.Web.UI.Page
    {
        private AdminGateway adminGateway;
        private BaseClass func;
        private Alert alert;
        private AdminModel adminModel;
        public admin_list()
        {
            adminGateway = new AdminGateway();
            adminModel = new AdminModel();
            func = BaseClass.GetInstance();
            alert = Alert.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                func.CheckCookies();
                func.AdminType(this, "Super Admin", "Admin");
                AdminData();
            }
        }
        public void AdminData()
        {
            adminGridView.DataSource = adminGateway.GetAllAdmin();
            adminGridView.DataBind();
        }
        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }

        protected void txtSearch_OnTextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                adminGridView.DataSource = adminGateway.GetAdminByData(txtSearch.Text);
                adminGridView.DataBind();
            }
            else
            {
                AdminData();
            }
        }

        protected void adminGridView_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            adminGridView.PageIndex = e.NewPageIndex;
            AdminData();
        }

        protected void restrictLinkButton_OnClick(object sender, EventArgs e)
        {
            if (func.CheckType() == "Super Admin")
            {
                LinkButton linkButton = (LinkButton)sender;
                DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
                GridViewRow row = (GridViewRow)cell.Parent;
                HiddenField idHiddenField = (HiddenField)row.FindControl("idHiddenField");
                int id = Convert.ToInt32(idHiddenField.Value);
                AdminModel adminModel = new AdminModel();
                adminModel.Status = "Restrict";
                adminModel.AdminId = id;
                int a = adminGateway.UpdateData(adminModel);
                if (a > 0)
                {
                    func.Alert(this, "Restricted Successfully", "s", false);
                    AdminData();
                }
                else
                {
                    func.Alert(this, "Restricted Failed", "e", false);
                }
            }
            else
            {
                func.Alert(this, "Onlu super admin can create admin", "w", false);
            }
        }
    }
}