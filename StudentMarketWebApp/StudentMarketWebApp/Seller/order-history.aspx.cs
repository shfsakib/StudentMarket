using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;
using StudentMarketWebApp.DAL.Gateway;
using StudentMarketWebApp.DAL.Model;

namespace StudentMarketWebApp.Seller
{
    public partial class order_history : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private PostAdModel postAdModel;
        private PostAdGateway postAdGateway;
        private BuyModel buyModel;
        private BuyGateway buyGateway;
        public order_history()
        {
            func = BaseClass.GetInstance();
            alert = Alert.GetInstance();
            postAdModel = PostAdModel.GetInstance();
            postAdGateway = PostAdGateway.GetInstance();
            buyModel = BuyModel.GetInstance();
            buyGateway = BuyGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                func.CheckCookies();
                func.Type(this, "Seller");
                countN.InnerText = func.BuyerNotification(Convert.ToInt32(func.UserId())).ToString();
                Load();
            }
        }
        private void Load()
        {
            string query = @"SELECT        Buy.BuyId, Buy.PostId, Buy.Price, Buy.TotalPrice, Buy.BuyerId, Buy.DeadLine,Buy.Status,Buy.PaymentMethod,Buy.Invoice, Buy.Quantity, PostAd.ProductName, (SELECT Name FROM UserList WHERE UserId=Buy.BuyerId) AS Name,(SELECT MIN(Picture) FROM PostPic WHERE PostPic.PostId=Buy.PostId)  AS Picture
FROM            Buy INNER JOIN
                         PostAd ON Buy.PostId = PostAd.PostId INNER JOIN
                         UserList ON PostAd.UserId = UserList.UserId WHERE Buy.SellerId='" + func.UserId() + "' AND Buy.Status!='Pending' ORDER BY BuyId DESC ";
            func.LoadGrid(historyGridView, query);
        }
        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }

        protected void historyGridView_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            historyGridView.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void historyGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label titleLabel = (Label)e.Row.FindControl("titleLabel");
                titleLabel.Visible = false;
                LinkButton titleLinkButton = (LinkButton)e.Row.FindControl("titleLinkButton");
                titleLinkButton.Text = titleLabel.Text;
            }
        }

        protected void titleLinkButton_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField HiddenField1 = (HiddenField)row.FindControl("HiddenField1");
            Response.Redirect("/Seller/view-profile.aspx?id=" + HiddenField1.Value + "");
        }
    }
}