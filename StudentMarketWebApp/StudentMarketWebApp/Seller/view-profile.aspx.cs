using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;

namespace StudentMarketWebApp.Seller
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
                func.Type(this, "Seller");
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
            }

        }
        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }
    }
}