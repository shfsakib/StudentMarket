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
    public partial class order_product : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private PostAdModel postAdModel;
        private PostAdGateway postAdGateway;
        private BuyModel buyModel;
        private BuyGateway buyGateway;
        public order_product()
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
                func.Type(this, "Buyer");
                countN.InnerText = func.BuyerNotification(Convert.ToInt32(func.UserId())).ToString();
                Load();
                LoadEdit();
            }
        }
        private void Load()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            postAdModel = postAdGateway.GetPost(id);
            lblProductName.Text = postAdModel.ProductName;
            lblTime.Text = lblTime.Text + " " + postAdModel.Intime;
            lblLocation.Text = postAdModel.DistrictName + "," + postAdModel.DivisionName;
            lblPrice1.Text = postAdModel.Price.ToString();
            lblUserName.Text = postAdModel.Name;
            lblDescription.Text = postAdModel.Description;
            productImage.ImageUrl = postAdModel.Picture;
        }

        private void LoadEdit()
        {
            string allow = Request.QueryString["allow"];
            int buyId = Convert.ToInt32(Request.QueryString["buyId"]);

            if (allow == "yes")
            {
                buyModel = buyGateway.GetOrder(buyId);
                txtQuantity.Text = buyModel.Quantity.ToString();
                txtDeadLine.Text = buyModel.DeadLine;
                btnOrder.Text =
                    "<i class=\"fas fa-shopping-basket\" style=\"color: white;\"></i>&nbsp;&nbsp;Update Order";
            }
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

        private bool IsExist()
        {
            bool result = false;
            int postId = Convert.ToInt32(Request.QueryString["id"]);
            int userId = Convert.ToInt32(Request.QueryString["userid"]);
            string ans = func.IsExist($"SELECT * FROM Buy WHERE PostId='{postId}' AND BuyerId={func.UserId()} AND (Status!='Rejected' OR Status!='Confirmed')");
            if (ans!="")
            {
                result = true;
            }
            return result;
        }
        protected void btnOrder_OnClick(object sender, EventArgs e)
        {
            if (btnOrder.Text == "<i class=\"fas fa-shopping-basket\" style=\"color: white;\"></i>&nbsp;&nbsp;Order")
            {

                if (txtQuantity.Text == "")
                    func.Alert(Page, "Quantity is required", "w", true);
                else if (func.ValidDate(txtDeadLine))
                    func.Alert(Page, "Enter valid deadline", "w", true);
                else if (IsExist())
                    func.Alert(Page, "You have already ordered this product.please check your pending order to update.", "w", true);
                else
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    int userId = Convert.ToInt32(Request.QueryString["userid"]);

                    buyModel.BuyId = Convert.ToInt32(func.GenerateId("SELECT MAX(BuyId) FROM Buy"));
                    buyModel.Invoice = buyGateway.GenerateInvoice();
                    buyModel.PostId = id;
                    buyModel.Price = Convert.ToDouble(lblPrice1.Text);
                    buyModel.TotalPrice = Convert.ToDouble(lblPrice1.Text) * Convert.ToInt32(txtQuantity.Text);
                    buyModel.BuyerId = Convert.ToInt32(func.UserId());
                    buyModel.SellerId = Convert.ToInt32(userId);
                    buyModel.DeadLine = txtDeadLine.Text;
                    buyModel.Quantity = Convert.ToInt32(txtQuantity.Text);
                    buyModel.Type = "Order";
                    buyModel.Status = "Pending";
                    buyModel.Intime = func.Date();
                    bool result = buyGateway.SaveBuy(buyModel);
                    if (result)
                    {
                        func.Alert(Page, "Ordered successfully,wait for seller confirmation.", "s", true);
                        txtQuantity.Text = txtDeadLine.Text = "";
                    }
                    else
                    {
                        func.Alert(Page, "Order Failed", "e", true);
                    }
                }
            }
            else if (btnOrder.Text == "<i class=\"fas fa-shopping-basket\" style=\"color: white;\"></i>&nbsp;&nbsp;Update Order")
            {
                if (txtQuantity.Text == "")
                    func.Alert(Page, "Quantity is required", "w", true);
                else if (func.ValidDate(txtDeadLine))
                    func.Alert(Page, "Enter valid deadline", "w", true);
                else
                {
                    int buyId = Convert.ToInt32(Request.QueryString["buyId"]);
                    bool result = func.Execute($"UPDATE Buy SET Quantity='{txtQuantity.Text}',DeadLine='{txtDeadLine.Text}',TotalPrice='{Convert.ToInt32(lblPrice1.Text) * Convert.ToInt32(txtQuantity.Text)}' WHERE BuyId='{buyId}'");
                    if (result)
                    {
                        func.Alert(Page, "Order updated successfully", "s", true);
                        txtQuantity.Text = txtDeadLine.Text = "";
                    }
                    else
                    {
                        func.Alert(Page, "Order Failed", "e", true);
                    }
                }
            }
        }
    }
}