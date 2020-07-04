using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;
using StudentMarketWebApp.DAL.Gateway;
using StudentMarketWebApp.DAL.Model;

namespace StudentMarketWebApp.Buyer
{
    public partial class view_ads : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private PostAdModel postAdModel;
        private PostAdGateway postAdGateway;
        private BuyModel buyModel;
        private BuyGateway buyGateway;
        private DataTable dataTable;
        private DataRow dataRow;
        public view_ads()
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
                func.BindDropDown(ddlCategory, "Select Category", "SELECT CategoryName Name,CategoryId ID FROM Category ORDER BY CategoryName ASC");
                func.BindDropDown(ddlDivision, "select", "SELECT Division Name,ID FROM Division ORDER BY Division ASC");
                countN.InnerText = func.BuyerNotification(Convert.ToInt32(func.UserId())).ToString();
                LoadGrid();
            }
        }
        private void LoadGrid()
        {
            string query =
                @"SELECT DISTINCT A.*,(SELECT MIN(Picture) FROM PostPic WHERE PostPic.PostId=A.PostId) AS Picture FROM (SELECT    DISTINCT    PostAd.PostId, PostAd.CategoryId,Userlist.UserId,Division.ID AS DivisionId,District.DISTRICTID AS DistrictId, PostAd.ProductName, PostAd.Description, PostAd.Price, Division.DIVISION AS DivisionName, District.DISTRICTNM As DistrictName, UserList.Name,Category.CategoryName
FROM            PostAd INNER JOIN
                         Category ON PostAd.CategoryId = Category.CategoryId INNER JOIN
                         PostPic ON PostAd.PostId = PostPic.PostId INNER JOIN
                         UserList ON PostAd.UserId=UserList.UserId INNER JOIN
						 Division ON UserList.Division=Division.ID  INNER JOIN
                         District ON UserList.District=District.DISTRICTID)A INNER JOIN PostPic ON A.PostId=PostPic.PostId ORDER BY A.PostId DESC";
            func.LoadGrid(adsGridView, query);

        }
        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }

        protected void ddlDivision_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDivision.Text != "--SELECT--")
            {
                func.BindDropDown(ddlDistrict, "select", "SELECT DistrictNM Name,DistrictId ID FROM District WHERE DivisionId='" + Convert.ToInt32(ddlDivision.SelectedValue) + "'");
            }
        }

        protected void adsGridView_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            adsGridView.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void adsGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label titleLabel = (Label)e.Row.FindControl("titleLabel");
                titleLabel.Visible = false;
                LinkButton titleLinkButton = (LinkButton)e.Row.FindControl("titleLinkButton");
                titleLinkButton.Text = titleLabel.Text;
                HiddenField categoryName = (HiddenField)e.Row.FindControl("HiddenField2");
                string category = categoryName.Value;
                if (category == "Developer" || category == "Artist" || category == "Designer" || category == "Event")
                {
                    LinkButton btnOrder = (LinkButton)e.Row.FindControl("btnOrder");
                    LinkButton btnCart = (LinkButton)e.Row.FindControl("btnCart");
                    btnOrder.Text = "<i class=\"fas fa-money-bill\" style=\"color: white;\"></i>&nbsp;&nbsp;Hire";
                }
            }
        }

        protected void titleLinkButton_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField empIdHiddenField = (HiddenField)row.FindControl("idHiddenField");
            HiddenField HiddenField1 = (HiddenField)row.FindControl("HiddenField1");
            int id = Convert.ToInt32(empIdHiddenField.Value);
            int userId = Convert.ToInt32(HiddenField1.Value);
            Response.Redirect("/Buyer/ad-details.aspx?id=" + id + "&userid=" + userId + "");
        }

        protected void btnSearch_OnServerClick(object sender, EventArgs e)
        {
            if (ddlDivision.Text != "--SELECT--" && ddlDistrict.Text != "--SELECT--" && ddlCategory.Text != "--SELECT CATEGORY--")
            {
                string query =
               @"SELECT DISTINCT A.*,(SELECT MIN(Picture) FROM PostPic WHERE PostPic.PostId=A.PostId) AS Picture FROM (SELECT    DISTINCT    PostAd.PostId, PostAd.CategoryId,Userlist.UserId,Division.ID AS DivisionId,District.DISTRICTID AS DistrictId, PostAd.ProductName, PostAd.Description, PostAd.Price, Division.DIVISION AS DivisionName, District.DISTRICTNM As DistrictName, UserList.Name
FROM            PostAd INNER JOIN
                         Category ON PostAd.CategoryId = Category.CategoryId INNER JOIN
                         PostPic ON PostAd.PostId = PostPic.PostId INNER JOIN
                         UserList ON PostAd.UserId=UserList.UserId INNER JOIN
						 Division ON UserList.Division=Division.ID  INNER JOIN
                         District ON UserList.District=District.DISTRICTID)A INNER JOIN PostPic ON A.PostId=PostPic.PostId WHERE A.DivisionId='" + ddlDivision.SelectedValue + "' AND A.DistrictId='" + ddlDistrict.SelectedValue + "' AND A.CategoryId='" + ddlCategory.SelectedValue + "' ORDER BY A.PostId DESC";
                func.LoadGrid(adsGridView, query);
            }
            else if (ddlDivision.Text != "--SELECT--" && ddlDistrict.Text != "--SELECT--")
            {
                string query =
               @"SELECT DISTINCT A.*,(SELECT MIN(Picture) FROM PostPic WHERE PostPic.PostId=A.PostId) AS Picture FROM (SELECT    DISTINCT    PostAd.PostId, PostAd.CategoryId,Userlist.UserId,Division.ID AS DivisionId,District.DISTRICTID AS DistrictId, PostAd.ProductName, PostAd.Description, PostAd.Price, Division.DIVISION AS DivisionName, District.DISTRICTNM As DistrictName, UserList.Name
FROM            PostAd INNER JOIN
                         Category ON PostAd.CategoryId = Category.CategoryId INNER JOIN
                         PostPic ON PostAd.PostId = PostPic.PostId INNER JOIN
                         UserList ON PostAd.UserId=UserList.UserId INNER JOIN
						 Division ON UserList.Division=Division.ID  INNER JOIN
                         District ON UserList.District=District.DISTRICTID)A INNER JOIN PostPic ON A.PostId=PostPic.PostId WHERE A.DivisionId='" + ddlDivision.SelectedValue + "' AND A.DistrictId='" + ddlDistrict.SelectedValue + "' ORDER BY A.PostId DESC";
                func.LoadGrid(adsGridView, query);
            }
            else if (ddlDivision.Text != "--SELECT--")
            {
                string query =
               @"SELECT DISTINCT A.*,(SELECT MIN(Picture) FROM PostPic WHERE PostPic.PostId=A.PostId) AS Picture FROM (SELECT    DISTINCT    PostAd.PostId, PostAd.CategoryId,Userlist.UserId,Division.ID AS DivisionId,District.DISTRICTID AS DistrictId, PostAd.ProductName, PostAd.Description, PostAd.Price, Division.DIVISION AS DivisionName, District.DISTRICTNM As DistrictName, UserList.Name
FROM            PostAd INNER JOIN
                         Category ON PostAd.CategoryId = Category.CategoryId INNER JOIN
                         PostPic ON PostAd.PostId = PostPic.PostId INNER JOIN
                         UserList ON PostAd.UserId=UserList.UserId INNER JOIN
						 Division ON UserList.Division=Division.ID  INNER JOIN
                         District ON UserList.District=District.DISTRICTID)A INNER JOIN PostPic ON A.PostId=PostPic.PostId WHERE A.DivisionId='" + ddlDivision.SelectedValue + "' ORDER BY A.PostId DESC";
                func.LoadGrid(adsGridView, query);
            }
            else if (ddlCategory.Text != "--SELECT CATEGORY--")
            {
                string query =
               @"SELECT DISTINCT A.*,(SELECT MIN(Picture) FROM PostPic WHERE PostPic.PostId=A.PostId) AS Picture FROM (SELECT    DISTINCT    PostAd.PostId, PostAd.CategoryId,Userlist.UserId,Division.ID AS DivisionId,District.DISTRICTID AS DistrictId, PostAd.ProductName, PostAd.Description, PostAd.Price, Division.DIVISION AS DivisionName, District.DISTRICTNM As DistrictName, UserList.Name
FROM            PostAd INNER JOIN
                         Category ON PostAd.CategoryId = Category.CategoryId INNER JOIN
                         PostPic ON PostAd.PostId = PostPic.PostId INNER JOIN
                         UserList ON PostAd.UserId=UserList.UserId INNER JOIN
						 Division ON UserList.Division=Division.ID  INNER JOIN
                         District ON UserList.District=District.DISTRICTID)A INNER JOIN PostPic ON A.PostId=PostPic.PostId WHERE A.CategoryId='" + ddlCategory.SelectedValue + "' ORDER BY A.PostId DESC";
                func.LoadGrid(adsGridView, query);
            }
            else
            {
                LoadGrid();
            }
        }

        protected void btnOrder_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField postId = (HiddenField)row.FindControl("idHiddenField");
            HiddenField HiddenField1 = (HiddenField)row.FindControl("HiddenField1");
            int id = Convert.ToInt32(postId.Value);
            int userId = Convert.ToInt32(HiddenField1.Value);
            CheckBox chkCash = (CheckBox)row.FindControl("chkCash");
            CheckBox chkPay = (CheckBox)row.FindControl("chkPay");
            if (linkButton.Text == "<i class=\"fas fa-shopping-basket\" style=\"color: white;\"></i>&nbsp;&nbsp;Order")
            {
                Response.Redirect("/Buyer/order-product.aspx?id=" + id + "&userid=" + userId + "");
            }
            else if (linkButton.Text == "<i class=\"fas fa-money-bill\" style=\"color: white;\"></i>&nbsp;&nbsp;Hire")
            {
                buyModel.BuyId = Convert.ToInt32(func.GenerateId("SELECT MAX(BuyId) FROM Buy"));
                buyModel.Invoice = buyGateway.GenerateInvoice();
                buyModel.PostId = id;
                buyModel.Price = 0;
                buyModel.TotalPrice = 0;
                buyModel.BuyerId = Convert.ToInt32(func.UserId());
                buyModel.SellerId = Convert.ToInt32(userId);
                buyModel.DeadLine = "";
                buyModel.Quantity = 0;
                if (chkPay.Checked)
                {
                    buyModel.PaymentMethod = "Pay Online";
                }
                else if (chkCash.Checked)
                {
                    buyModel.PaymentMethod = "Cash on delivery";
                }
                buyModel.Type = "Hire";
                buyModel.Status = "Pending";
                buyModel.Intime = func.Date();
                if (IsExecute(buyModel.PostId))
                {
                    func.Alert(Page, "You have already sent hire request", "w", true);
                }
                else
                {
                    bool result = buyGateway.SaveBuy(buyModel);
                    if (result)
                    {
                        func.Alert(Page, "Hire request sent successfully,wait for seller confirmation.", "s", true);
                    }
                    else
                    {
                        func.Alert(Page, "Hire request Failed", "e", true);
                    }
                }
            }
        }

        private bool IsExecute(int postId)
        {
            bool result = false;
            string has = func.IsExist($"SELECT Invoice FROM Buy WHERE BuyerId='{func.UserId()}' AND  PostId='{postId}' AND Status='Pending'");
            if (has != "")
            {
                result = true;
            }
            return result;
        }

        protected void btnCart_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField idHiddenField = (HiddenField)row.FindControl("idHiddenField");
            HiddenField HiddenField1 = (HiddenField)row.FindControl("HiddenField1");
            HiddenField HiddenField3 = (HiddenField)row.FindControl("HiddenField3");
            CheckBox chkCash = (CheckBox)row.FindControl("chkCash");
            CheckBox chkPay = (CheckBox)row.FindControl("chkPay");
            Image profileImage = (Image)row.FindControl("profileImage");
            int postId = Convert.ToInt32(idHiddenField.Value);
            int userId = Convert.ToInt32(HiddenField1.Value);
            LoadCart();
            dataTable = new DataTable();
            dataTable = (DataTable)Session["dataGrid"];
            dataRow = dataTable.NewRow();
            dataRow["PostId"] = postId;
            dataRow["SellerId"] = userId;
            dataRow["Picture"] = func.IsExist($"SELECT MIN(Picture) FROM PostPic WHERE PostId='{postId}'");
            dataRow["ProductName"] = func.IsExist($"SELECT ProductName FROM PostAd WHERE PostId='{postId}'");
            dataRow["Price"] = HiddenField3.Value;
            if (chkPay.Checked)
            {
                dataRow["PaymentMethod"] = "Pay Online";
            }
            else if (chkCash.Checked)
            {
                dataRow["PaymentMethod"] = "Cash on delivery";
            }
            dataTable.Rows.Add(dataRow);
            Session["dataGrid"] = dataTable;
            func.Alert(this, "Product added to cart successfully", "s", false);
        }
        private void LoadCart()
        {
            if (Session["dataGrid"] == null)
            {
                dataTable = new DataTable();
                dataTable.Columns.Add("PostId", typeof(int));
                dataTable.Columns.Add("SellerId", typeof(int));
                dataTable.Columns.Add("Picture", typeof(string));
                dataTable.Columns.Add("Price", typeof(string));
                dataTable.Columns.Add("ProductName", typeof(string));
                dataTable.Columns.Add("PaymentMethod", typeof(string));
                Session["dataGrid"] = dataTable;
            }
        }

        protected void chkPay_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            DataControlFieldCell cell = (DataControlFieldCell)checkBox.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            CheckBox chkCash = (CheckBox)row.FindControl("chkCash");
            if (checkBox.Checked)
            {
                chkCash.Checked = false;
                checkBox.Checked = true;
            }
        }

        protected void chkCash_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            DataControlFieldCell cell = (DataControlFieldCell)checkBox.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            CheckBox chkPay = (CheckBox)row.FindControl("chkPay");
            if (checkBox.Checked)
            {
                chkPay.Checked = false;
                checkBox.Checked = true;

            }
        }
    }
}