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
    public partial class notification : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private PostAdModel postAdModel;
        private PostAdGateway postAdGateway;
        private BuyModel buyModel;
        private BuyGateway buyGateway;
        public notification()
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
                Read();
                countN.InnerText = func.SellerNotification(Convert.ToInt32(func.UserId())).ToString();
                Load();
            }
        }

        private void Load()
        {
            string query = @"SELECT        Buy.BuyId, Buy.PostId, Buy.Price, Buy.TotalPrice, Buy.BuyerId, Buy.DeadLine, Buy.Quantity, PostAd.ProductName, (SELECT Name FROM UserList WHERE UserId=Buy.BuyerId) AS Name,(SELECT MIN(Picture) FROM PostPic WHERE PostPic.PostId=Buy.PostId)  AS Picture
FROM            Buy INNER JOIN
                         PostAd ON Buy.PostId = PostAd.PostId INNER JOIN
                         UserList ON PostAd.UserId = UserList.UserId WHERE Buy.SellerId='" + func.UserId() + "' AND Buy.Status='Pending' ";
            func.LoadGrid(notificationGridView, query);
        }

        private void Read()
        {
            func.Execute($"UPDATE Buy SET SellerNoti='Readed' WHERE SellerId='{func.UserId()}'");

        }
        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }

        protected void titleLinkButton_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField HiddenField1 = (HiddenField)row.FindControl("HiddenField1");
            Response.Redirect("/Seller/view-profile.aspx?id=" + HiddenField1.Value + "");
        }

        protected void notificationGridView_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            notificationGridView.EditIndex = e.NewPageIndex;
            Load();
        }

        protected void notificationGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label titleLabel = (Label)e.Row.FindControl("titleLabel");
                titleLabel.Visible = false;
                LinkButton titleLinkButton = (LinkButton)e.Row.FindControl("titleLinkButton");
                titleLinkButton.Text = titleLabel.Text;
            }
        }

        protected void btnOrder_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField HiddenField2 = (HiddenField)row.FindControl("HiddenField2");
            bool result = func.Execute($"UPDATE Buy SET Status='Confirmed' WHERE SellerId='{func.UserId()}' AND BuyId='{HiddenField2.Value}'");
            if (result)
            {
                func.Alert(this, "Order accepted successfully", "s", false);
                Load();
            }
            else
                func.Alert(this, "Failed to accept order", "e", false);

        }

        protected void btnCart_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField HiddenField2 = (HiddenField)row.FindControl("HiddenField2");
            bool result = func.Execute($"UPDATE Buy SET Status='Rejected' WHERE SellerId='{func.UserId()}' AND BuyId='{HiddenField2.Value}'");
            if (result)
            {
                func.Alert(this, "Order removed successfully", "s", false);
                Load();
            }
            else
                func.Alert(this, "Failed to remove order", "e", false);
        }
    }
}