using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;
using StudentMarketWebApp.DAL.Gateway;
using StudentMarketWebApp.DAL.Model;

namespace StudentMarketWebApp.Admin
{
    public partial class view_ads : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private PostAdModel postAdModel;
        private PostAdGateway postAdGateway;

        public view_ads()
        {
            func = BaseClass.GetInstance();
            alert = Alert.GetInstance();
            postAdModel = PostAdModel.GetInstance();
            postAdGateway = PostAdGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                func.CheckCookies();
                func.AdminType(this, "Super Admin", "Admin");
                int id = Convert.ToInt32(Request.QueryString["id"]);
                func.LoadDataList(DataList1, "SELECT Picture FROM PostPic WHERE PostId='" + id + "'");
                Load();
            }
        }
        private void Load()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            postAdModel = postAdGateway.GetPost(id, "W");
            lblProductName.Text = postAdModel.ProductName;
            lblTime.Text = lblTime.Text + " " + postAdModel.Intime;
            lblLocation.Text = postAdModel.DistrictName + "," + postAdModel.DivisionName;
            lblPrice.Text = lblPrice.Text + " " + postAdModel.Price;
            lblUserName.Text = postAdModel.Name;
            lblDescription.Text = postAdModel.Description;
            largeImage.ImageUrl = postAdModel.Picture;
        }
        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }
        
    }
}