using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;

namespace StudentMarketWebApp.Seller
{
    public partial class ViewProfile : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private UserListModel userListModel;
        private UserListGateway userListGateway;
        public ViewProfile()
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
                func.CheckCookies();
                func.Type(this, "Seller");
                countN.InnerText = func.SellerNotification(Convert.ToInt32(func.UserId())).ToString();
                Load();
            }
        }
        private void Load()
        {
            userListModel = userListGateway.GetUser(Convert.ToInt32(func.UserId()));
            ViewState["pic"] = userListModel.Picture; ;
            profilePictureImage.ImageUrl = ViewState["pic"].ToString();
            nameLabel.Text = txtName.Text = userListModel.Name;
            lblEmail.Text = userListModel.Email;
            lblMobile.Text = txtMobile.Text = userListModel.MobileNo;
            lblDOB.Text = txtDob.Text = userListModel.DOB;
            lblGender.Text = ddlGender.Text = userListModel.Gender;
            lblNid.Text = txtNid.Text = userListModel.NidNo;
            lblBCert.Text = txtBCert.Text = userListModel.BCertNo;
            lblGNid.Text = txtGNid.Text = userListModel.GNidNo;
            lblPassword.Text = txtPass.Text = userListModel.Password;
            lblAbout.Text = txtAbout.Text = userListModel.About;
            lblDivision.Text = userListModel.DivisionName;
            lblDistrict.Text = userListModel.DistrictName;
            userImage.Src = userListModel.Picture;

        }
        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }

        protected void updateButton_OnClick(object sender, EventArgs e)
        {
            userListModel.UserId = Convert.ToInt32(func.UserId());
            userListModel.Name = txtName.Text;
            userListModel.MobileNo = txtMobile.Text;
            userListModel.DOB = txtDob.Text;
            userListModel.Gender = ddlGender.Text;
            userListModel.NidNo = txtNid.Text;
            userListModel.BCertNo = txtBCert.Text;
            userListModel.GNidNo = txtGNid.Text;
            userListModel.Password = txtPass.Text;
            userListModel.About = txtAbout.Text;
            if (userFileUpload.HasFile)
            {
                string imagePath = Server.MapPath("/Photos/") + userListModel.UserId + ".png";
                userFileUpload.PostedFile.SaveAs(imagePath);
                userListModel.Picture = "/Photos/" + userListModel.UserId + ".png";
            }
            else
            {
                userListModel.Picture = ViewState["pic"].ToString();
            }
            bool result = userListGateway.UpdateUser(userListModel);
            if (result)
            {
                func.Alert(Page, alert.UpdateSuccess, "s", false);
                Load();
                
            }
            else
            {
                func.Alert(Page, alert.UpdateFailed, "e", true);
            }
        }
    }
}