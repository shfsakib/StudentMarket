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
    public partial class edit_profile : System.Web.UI.Page
    {
        private AdminGateway adminGateway;
        private BaseClass func;
        private Alert alert;
        private AdminModel adminModel;
        public edit_profile()
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
            adminModel = new AdminModel();
            adminModel = adminGateway.GetAllAdminById(Convert.ToInt32(func.UserId()));
            ViewState["ProfilePicture"] = adminModel.ProfilePicture;
            profilePictureImage.ImageUrl = ViewState["ProfilePicture"].ToString();
            lblEmail.Text = adminModel.Email;
            nameLabel.Text = txtName.Text = adminModel.Name;
            lblEmail.Text = adminModel.Email;
            lblMobile.Text = txtMobile.Text = adminModel.MobileNumber;
            lblNid.Text = txtNid.Text = adminModel.NidNo;
            lblDOB.Text = txtDob.Text = adminModel.DateofBirth;
            ddlGender.SelectedValue = adminModel.Gender;
            txtPass.Text = lblPassword.Text = adminModel.Password;
        }
        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }

        protected void updateButton_OnClick(object sender, EventArgs e)
        {
            adminModel = new AdminModel();
            adminModel.AdminId = Convert.ToInt32(func.UserId());
            adminModel.Name = txtName.Text;
            adminModel.MobileNumber = txtMobile.Text;
            adminModel.DateofBirth = txtDob.Text;
            adminModel.Gender = ddlGender.Text;
            adminModel.Email = func.Email();
            adminModel.NidNo = txtNid.Text;
            adminModel.Password = txtPass.Text;
            if (userFileUpload.HasFile)
            {
                string imagePath = Server.MapPath("/Photos/Admin/") + adminModel.AdminId + ".png";
                userFileUpload.SaveAs(imagePath);
                adminModel.ProfilePicture = "/Photos/Admin/" + adminModel.AdminId + ".png";
            }
            else
            {
                adminModel.ProfilePicture = ViewState["ProfilePicture"].ToString();
            }
            int a = adminGateway.UpdateAdminData(adminModel);
            if (a > 0)
            {
                func.Alert(Page, alert.UpdateSuccess, "s", false);
                AdminData();
            }
            else
            {
                func.Alert(Page, alert.UpdateFailed, "e", true);
            }
        }
    }
}