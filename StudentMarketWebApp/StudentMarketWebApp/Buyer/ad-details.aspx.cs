using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;
using StudentMarketWebApp.DAL.Gateway;
using StudentMarketWebApp.DAL.Model;

namespace StudentMarketWebApp.Buyer
{
    public partial class ad_details : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private PostAdModel postAdModel;
        private PostAdGateway postAdGateway;

        public ad_details()
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
                func.Type(this, "Buyer");
                int id = Convert.ToInt32(Request.QueryString["id"]);
                func.LoadDataList(DataList1, "SELECT Picture FROM PostPic WHERE PostId='" + id + "'");
                countN.InnerText = func.BuyerNotification(Convert.ToInt32(func.UserId())).ToString();
                Load();
            }
        }
        private void Load()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            postAdModel = postAdGateway.GetPost(id,"A");
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

        protected void lblUserName_OnClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["userid"]);
            Response.Redirect("/Buyer/view-profile.aspx?id=" + id + "");
        }
    }
}