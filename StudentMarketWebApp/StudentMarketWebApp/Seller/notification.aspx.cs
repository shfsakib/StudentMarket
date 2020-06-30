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
            string query = @"SELECT        Buy.BuyId, Buy.PostId, Buy.Price, Buy.TotalPrice, Buy.BuyerId, Buy.DeadLine, Buy.Quantity, PostAd.ProductName, (SELECT Name FROM UserList WHERE UserId=Buy.BuyerId) AS Name,(SELECT MIN(Picture) FROM PostPic WHERE PostPic.PostId=Buy.PostId)  AS Picture,(SELECT Email FROM UserList WHERE UserList.UserId=Buy.BuyerId) AS Email,Buy.Type
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
                Label Label1 = (Label)e.Row.FindControl("Label1");
                Label Label2 = (Label)e.Row.FindControl("Label2");
                Label Label3 = (Label)e.Row.FindControl("Label3");
                Label total = (Label)e.Row.FindControl("total");
                HiddenField HiddenField6 = (HiddenField)e.Row.FindControl("HiddenField6");
                if (HiddenField6.Value=="Hire")
                {
                    Label1.Visible = Label2.Visible = Label3.Visible = total.Visible = false;
                }

            }
        }

        protected void btnOrder_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField HiddenField2 = (HiddenField)row.FindControl("HiddenField2");
            HiddenField HiddenField3 = (HiddenField)row.FindControl("HiddenField3");
            HiddenField HiddenField4 = (HiddenField)row.FindControl("HiddenField4");
            HiddenField HiddenField5 = (HiddenField)row.FindControl("HiddenField5");
            bool result = func.Execute($"UPDATE Buy SET Status='Confirmed' WHERE SellerId='{func.UserId()}' AND BuyId='{HiddenField2.Value}'");
            if (result)
            {
                func.Alert(this, "Accepted successfully", "s", false);
                func.SendEmail("StuMarket5713@gmail.com",HiddenField3.Value,"StuMarket Product Confirmation","Hello "+HiddenField4.Value+",<br/>Your product request for "+HiddenField5.Value+" has been accepted by seller.Please check your notification and contact with seller.<br/>Thank you.","Admin4321");
                Load();
            }
            else
                func.Alert(this, "Failed to accept", "e", false);

        }

        protected void btnCart_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField HiddenField2 = (HiddenField)row.FindControl("HiddenField2");
            HiddenField HiddenField3 = (HiddenField)row.FindControl("HiddenField3");
            HiddenField HiddenField4 = (HiddenField)row.FindControl("HiddenField4");
            HiddenField HiddenField5 = (HiddenField)row.FindControl("HiddenField5");
            bool result = func.Execute($"UPDATE Buy SET Status='Rejected' WHERE SellerId='{func.UserId()}' AND BuyId='{HiddenField2.Value}'");
            if (result)
            {
                func.Alert(this, "Order removed successfully", "s", false);
                func.SendEmail("StuMarket5713@gmail.com", HiddenField3.Value, "StuMarket Product Confirmation", "Hello " + HiddenField4.Value + ",<br/>Your product request for " + HiddenField5.Value + " has been rejected by seller.We're sorry for the inconvenience,please check other products.<br/>Thank you.", "Admin4321");
                Load();
            }
            else
                func.Alert(this, "Failed to remove order", "e", false);
        }
    }
}