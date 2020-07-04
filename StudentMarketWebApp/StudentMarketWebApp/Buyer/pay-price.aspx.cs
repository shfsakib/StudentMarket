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
    public partial class pay_price : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private UserListModel userListModel;
        private UserListGateway userListGateway;
        private PayPriceModel payPriceModel;
        private PayPriceGateway payPriceGateway;
        public pay_price()
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

            }
        }
        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }

        private bool IsExist(string invoice)
        {
            bool result = false;
            string x = func.IsExist($"SELECT Price FROM PayPrice WHERE OrderInvoice={invoice}");
            if (x != "")
                result = true;
            return result;
        }
        protected void btnPay_OnClick(object sender, EventArgs e)
        {
            if (txtInvoice.Text == "")
                func.Alert(Page, "Name is required", "w", true);
            else if (txtTrxId.Text == "")
                func.Alert(Page, "Bkash TrxId is required", "w", true);
            else if (txtSearch.Text == "")
                func.Alert(Page, "Please select a user first!", "w", true);
            else if (IsExist(txtInvoice.Text))
                func.Alert(Page, "You have already paid for this invoice", "w", true);
            else
            {
                payPriceModel.PayId = Convert.ToInt32(func.GenerateId("SELECT MAX(PayId) FROM PayPrice"));
                payPriceModel.BuyerId = Convert.ToInt32(func.UserId());
                payPriceModel.SellerId = Convert.ToInt32(ViewState["sellerId"]);
                payPriceModel.OrderInvoice = txtInvoice.Text;
                payPriceModel.TrxId = txtTrxId.Text;
                payPriceModel.Price = Convert.ToDouble(txtPrice.Text);
                payPriceModel.Intime = func.Date();
                bool result = payPriceGateway.SavePrice(payPriceModel);
                if (result)
                {
                    func.Alert(Page, "Paid Successfully", "s", false);
                    Refresh();
                }
                else
                {
                    func.Alert(Page, "Paid Failed", "e", true);
                }
            }
        }

        private void Refresh()
        {
            txtSearch.Text = txtName.Text = txtEmail.Text = txtMobile.Text = txtInvoice.Text = txtTrxId.Text =txtPrice.Text= "";
            imgSeller.ImageUrl = "/DashboardFile/images/photo_dummy.png";
        }
        protected void txtSearch_OnTextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                userListModel = userListGateway.GetUser(txtSearch.Text);
                if (userListModel != null)
                {
                    imgSeller.ImageUrl = userListModel.Picture;
                    txtName.Text = userListModel.Name;
                    txtMobile.Text = userListModel.MobileNo;
                    txtEmail.Text = userListModel.Email;
                    ViewState["sellerId"] = userListModel.UserId;
                }
            }
        }

        protected void txtInvoice_OnTextChanged(object sender, EventArgs e)
        {
            if (txtInvoice.Text != "")
            {
                string price = func.IsExist($"SELECT SUM(PRICE) FROM Buy WHERE Invoice='{txtInvoice.Text}'");
                if (price != "")
                    txtPrice.Text = price;

                txtPrice.Focus();
                func.FocusTools(this,"txtPrice");
            }
        }
    }
}