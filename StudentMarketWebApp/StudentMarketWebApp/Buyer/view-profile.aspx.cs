using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;

namespace StudentMarketWebApp.Buyer
{
    public partial class view_profile : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private UserListModel userListModel;
        private UserListGateway userListGateway;
        public view_profile()
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
                func.Type(this, "Buyer");
                countN.InnerText = func.BuyerNotification(Convert.ToInt32(func.UserId())).ToString();
                Load();
            }
        }
        private void Load()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            userListModel = userListGateway.GetUser(id);
            if (userListModel != null)
            {
                profilePictureImage.ImageUrl = userListModel.Picture;
                nameLabel.Text = userListModel.Name;
                callButton.HRef = "tel:" + userListModel.MobileNo;
                mailButton.HRef = "mailto:" + userListModel.Email;
                ViewState["mail"] = userListModel.Email;
                ViewState["mobile"] = userListModel.MobileNo;
            }

        }
        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }

        protected void btnReport_OnServerClick(object sender, EventArgs e)
        {
            bool result = func.SendEmail("StuMarket5713@gmail.com", "StuMarket5713@gmail.com", "StuMarket Profile Report", "Hello Admin,<br/>" + nameLabel.Text + " has been reported by a seller.<br/>Reported Email: " + ViewState["mail"].ToString() + "<br/>Reported Mobile No.: " + ViewState["mobile"] + "<br/>User Email : " + func.Email() + "<br/>User Mobile No. : " + func.Mobile() + "<br/>", "Admin4321");
            if (result)
            {
                func.Alert(Page, "We are very sorry you have to face this kind of problem. We will contact with you soon.", "s", true);
            }
            else
            {
                func.Alert(Page, "Failed to report", "e", true);

            }
        }
    }
}