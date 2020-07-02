using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;
using ShabolombiAndroidApp.DLL.Gateway;
using ShabolombiAndroidApp.DLL.Model;

namespace StudentMarketWebApp.Admin
{
    public partial class create_admin : System.Web.UI.Page
    {
        private AdminGateway adminGateway;
        private BaseClass func;
        private Alert alert;
        private AdminModel adminModel;
        public create_admin()
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

            }
        }

        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }

        protected void createButton_OnClick(object sender, EventArgs e)
        {
            if (func.CheckType() == "Super Admin")
            {
                if (passwordTextBox.Value == confirmPasswordTextBox.Value)
                {
                    if (nameTextBox.Value == "")
                        func.Alert(this, "Name is required", "w", true);
                    else if (txtEmail.Value == "")
                        func.Alert(this, "Email is required", "w", true);
                    else if (func.MobileNoValidation(mobileNoTextBox.Value))
                        func.Alert(this, "Enter valid mobile no.", "w", true);
                    else if (nidTextBox.Value == "")
                        func.Alert(this, "Nid no is required", "w", true);
                    else if (dateofBirthTextBox.Text == "")
                        func.Alert(this, "Date of birth is required", "w", true);
                    else if (passwordTextBox.Value == "")
                        func.Alert(this, "Password is required", "w", true);
                    else if (typeDropDownList.Text == "SELECT")
                        func.Alert(this, "Type is required", "w", true);
                    else if (adminGateway.IsEmailExist(txtEmail.Value))
                        func.Alert(this, "Email already exist", "w", true);
                    else if (adminGateway.IsMobileNumberExist(mobileNoTextBox.Value))
                        func.Alert(this, "Mobile no. already exist", "w", true);
                    else if (adminGateway.IsNidExist(nidTextBox.Value))
                        func.Alert(this, "Nid no. already exist", "w", true);
                    else
                    {
                        adminModel = new AdminModel();
                        adminModel.AdminId = adminGateway.GenerateId();
                        adminModel.Name = nameTextBox.Value;
                        adminModel.Email = txtEmail.Value;
                        adminModel.MobileNumber = mobileNoTextBox.Value;
                        adminModel.NidNo = nidTextBox.Value;
                        if (maleRadioButton.Checked)
                        {
                            adminModel.Gender = "Male";
                        }
                        else
                        {
                            adminModel.Gender = "Female";
                        }
                        adminModel.DateofBirth = dateofBirthTextBox.Text;
                        if (profilePicFileUpload.HasFile)
                        {
                            string imagePath = Server.MapPath("/Photos/Admin/") + adminModel.AdminId + ".png";
                            profilePicFileUpload.SaveAs(imagePath);
                            adminModel.ProfilePicture = "/Photos/Admin/" + adminModel.AdminId + ".png";
                        }
                        else
                        {
                            adminModel.ProfilePicture = "";
                        }
                        adminModel.Password = passwordTextBox.Value;
                        adminModel.Type = typeDropDownList.Text;
                        adminModel.ReferedBy = func.Email();
                        adminModel.Status = "Active";
                        adminModel.InTime = func.Date();
                        int a = adminGateway.Save(adminModel);
                        if (a > 0)
                        {
                            func.Alert(this, alert.InsertSuccess, "s", false);
                            Refresh();
                        }
                        else
                        {
                            func.Alert(this, alert.InsertFailed, "s", false);
                        }
                    }
                }
            }
            else
            {
                func.Alert(this,"Onlu super admin can create admin", "w", false);
            }
        }

        private void Refresh()
        {
            nameTextBox.Value =
                txtEmail.Value =
                    mobileNoTextBox.Value =
                        nidTextBox.Value = dateofBirthTextBox.Text = nidTextBox.Value = passwordTextBox.Value = "";
            typeDropDownList.SelectedIndex = -1;
        }
    }
}