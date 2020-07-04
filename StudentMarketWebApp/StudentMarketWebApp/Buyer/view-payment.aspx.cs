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
    public partial class view_payment : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private UserListModel userListModel;
        private UserListGateway userListGateway;
        private PayPriceModel payPriceModel;
        private PayPriceGateway payPriceGateway;
        public view_payment()
        {
            func = BaseClass.GetInstance();
            alert = Alert.GetInstance();
            userListModel = UserListModel.GetInstance();
            userListGateway = UserListGateway.GetInstance();
            payPriceModel = PayPriceModel.GetInstance();
            payPriceGateway = PayPriceGateway.GetInstance();
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

        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }

        private void Load()
        {
            string query = @"SELECT        PayPrice.PayId, PayPrice.BuyerId, PayPrice.SellerId, PayPrice.OrderInvoice, PayPrice.TrxId, PayPrice.Price, PayPrice.Intime, (SELECT Name FROM UserList WHERE USERList.UserId=PayPrice.SellerId) AS Name,(SELECT Picture FROM UserList WHERE USERList.UserId=PayPrice.SellerId) AS Picture
FROM            PayPrice INNER JOIN
                         UserList ON UserList.UserId=PayPrice.BuyerId WHERE PayPrice.BuyerId='" + func.UserId() + "' ORDER By PayPrice.PayId DESC";
            func.LoadGrid(paymentGridView, query);
        }
        protected void paymentGridView_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            paymentGridView.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void btnRemove_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField HiddenField2 = (HiddenField)row.FindControl("HiddenField2");
            int id = Convert.ToInt32(HiddenField2.Value);
            bool result = func.Execute($"DELETE FROM PayPrice WHere PayId={id}");
            if (result)
            {
                func.Alert(Page, "Removed Successfully", "s", false);
                Load();
            }
            else
            {
                func.Alert(Page, "Removed Failed", "e", true);
            }
        }

        protected void txtSearch_OnTextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                string query = @"SELECT        PayPrice.PayId, PayPrice.BuyerId, PayPrice.SellerId, PayPrice.OrderInvoice, PayPrice.TrxId, PayPrice.Price, PayPrice.Intime, (SELECT Name FROM UserList WHERE USERList.UserId=PayPrice.SellerId) AS Name,(SELECT Picture FROM UserList WHERE USERList.UserId=PayPrice.SellerId) AS Picture
FROM            PayPrice INNER JOIN
                         UserList ON UserList.UserId=PayPrice.BuyerId WHERE PayPrice.OrderInvoice='" + txtSearch.Text + "' AND PayPrice.BuyerId='" + func.UserId() + "' ORDER By PayPrice.PayId DESC";
                func.LoadGrid(paymentGridView, query);
            }
            else
            {
                Load();
            }
        }
    }
}