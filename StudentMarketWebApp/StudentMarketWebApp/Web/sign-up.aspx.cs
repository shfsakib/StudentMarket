using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;

namespace StudentMarketWebApp.Web
{
    public partial class sign_up : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private UserListModel userListModel;
        private UserListGateway userListGateway;

        public sign_up()
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
                func.BindDropDown(ddlDivision, "select", "SELECT Division Name,ID FROM Division ORDER BY Division ASC");
                func.FocusTools(this, "txtName");
            }
        }

        protected void ddlDivision_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            func.BindDropDown(ddlDistrict, "select", "SELECT DistrictNM Name,DistrictId ID FROM District WHERE DivisionId='" + Convert.ToInt32(ddlDivision.SelectedValue) + "'");
            func.FocusTools(this, "ddlDistrict");
        }
        private bool IsEmailExist(string email)
        {
            bool result = false;
            string x = func.IsExist($"SELECT EMAIL FROM UserList WHERE Email='{email}'");
            if (x != "")
                result = true;
            return result;
        }
        private bool IsMobileExist(string mobile)
        {
            bool result = false;
            string x = func.IsExist($"SELECT MOBILENO FROM EMPINFO WHERE MOBILENO='{mobile}'");
            if (x != "")
                result = true;
            return result;
        }
        protected void btnSignup_OnServerClick(object sender, EventArgs e)
        {
            if (txtname.Value == "")
                func.Alert(Page, "Name is required", "w", true);
            else if (func.ValidDateI(txtDob))
                func.Alert(Page, "Date of birth required", "w", true);
            else if (ddlGender.Text == "Select")
                func.Alert(Page, "Select a gender", "w", true);
            else if (func.MobileNoValidation(txtMobile.Value))
                func.Alert(Page, "Enter valid mobile no.", "w", true);
            else if (ddlDivision.Text == "--SELECT--")
                func.Alert(Page, "Select division", "w", true);
            else if (ddlDistrict.Text == "--SELECT--")
                func.Alert(Page, "Select district", "w", true);
            else if (txtAddress.Text == "")
                func.Alert(Page, "Address is required", "w", true);
            else if (txtAddress.Text == "")
                func.Alert(Page, "Address is required", "w", true);
            else if (txtEmail.Value == "")
                func.Alert(Page, "Email id required", "w", true);
            else if (IsEmailExist(txtEmail.Value))
                func.Alert(Page, "Email already exist", "e", true);
            else if (IsMobileExist(txtMobile.Value))
                func.Alert(Page, "Mobile no already exist", "e", true);
            else if (txtPassword.Text == "")
                func.Alert(Page, "Password is required", "e", true);
            else if (txtBCert.Value == "")
                func.Alert(Page, "Birth certicate no is required", "e", true);
            else if (txtGNid.Value == "")
                func.Alert(Page, "Guardian Nid no is required", "e", true);
            else if (txtAbout.Value == "")
                func.Alert(Page, "About is required", "e", true);
            else
            {
                userListModel.UserId = Convert.ToInt32(func.GenerateId("SELECT MAX(UserId) FROM UserList"));
                userListModel.Name = txtname.Value;
                userListModel.Email = txtEmail.Value;
                userListModel.MobileNo = txtMobile.Value;
                userListModel.DOB = txtDob.Value;
                userListModel.Gender = ddlGender.Text;
                userListModel.Division = Convert.ToInt32(ddlDivision.SelectedValue);
                userListModel.District = Convert.ToInt32(ddlDistrict.SelectedValue);
                userListModel.Password = txtPassword.Text;
                userListModel.Type = ddlType.Text;
                userListModel.Status = "W";
                userListModel.NidNo = txtNid.Value;
                userListModel.BCertNo = txtBCert.Value;
                userListModel.GNidNo = txtGNid.Value;
                userListModel.Address = txtAddress.Text;
                userListModel.About = txtAbout.Value;
                if (filePicture.HasFile)
                {
                    string imagePath = Server.MapPath("/Photos/") + userListModel.UserId + ".png";
                    filePicture.PostedFile.SaveAs(imagePath);
                    userListModel.Picture = "/Photos/" + userListModel.UserId + ".png";
                }
                else
                {
                    userListModel.Picture = "";
                }
                userListModel.Intime = func.Date();
                bool result = userListGateway.SaveUser(userListModel);
                if (result)
                {
                    func.Alert(Page, "Signed up successfully, You will be contacted soon.", "s", false);
                    Refresh();
                }
                else
                {
                    func.Alert(Page, "Failed to sign up", "e", true);
                }
            }
        }

        private void Refresh()
        {
            txtname.Value = txtEmail.Value = txtMobile.Value = txtDob.Value = txtAddress.Text = "";
            ddlDivision.SelectedIndex = ddlDistrict.SelectedIndex = -1;
            ddlGender.Text = "Select";
        }
    }
}