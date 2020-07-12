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
    public partial class payment_history : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private PostAdModel postAdModel;
        private PostAdGateway postAdGateway;
        private BuyModel buyModel;
        private BuyGateway buyGateway;
        public payment_history()
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
            string query = @"SELECT        PayPrice.PayId, PayPrice.BuyerId, PayPrice.SellerId, PayPrice.OrderInvoice, PayPrice.TrxId, PayPrice.Price, PayPrice.Intime, (SELECT Name FROM UserList WHERE USERList.UserId=PayPrice.BuyerId) AS Name,(SELECT Picture FROM UserList WHERE USERList.UserId=PayPrice.SellerId) AS Picture
FROM            PayPrice INNER JOIN
                         UserList ON UserList.UserId=PayPrice.BuyerId WHERE PayPrice.SellerId='" + func.UserId() + "' ORDER By PayPrice.PayId DESC";
            func.LoadGrid(paymentGridView, query);
        }
        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }

        protected void txtSearch_OnTextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                string query = @"SELECT        PayPrice.PayId, PayPrice.BuyerId, PayPrice.SellerId, PayPrice.OrderInvoice, PayPrice.TrxId, PayPrice.Price, PayPrice.Intime, (SELECT Name FROM UserList WHERE USERList.UserId=PayPrice.BuyerId) AS Name,(SELECT Picture FROM UserList WHERE USERList.UserId=PayPrice.SellerId) AS Picture
FROM            PayPrice INNER JOIN
                         UserList ON UserList.UserId=PayPrice.BuyerId WHERE PayPrice.OrderInvoice='" + txtSearch.Text + "' AND PayPrice.Seller='" + func.UserId() + "' ORDER By PayPrice.PayId DESC";
                func.LoadGrid(paymentGridView, query);
            }
            else
            {
                Load();
            }
        }

        protected void paymentGridView_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            paymentGridView.PageIndex = e.NewPageIndex;
            Load();
        }
    }
}