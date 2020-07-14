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
    public partial class pending_orders : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private PostAdModel postAdModel;
        private PostAdGateway postAdGateway;
        private BuyModel buyModel;
        private BuyGateway buyGateway;

        public pending_orders()
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
            }
        }

        private void Load()
        {
            string query =
                @"SELECT DISTINCT A.*,(SELECT MIN(Picture) FROM PostPic WHERE PostPic.PostId=A.PostId) AS Picture FROM (SELECT    DISTINCT    PostAd.PostId, PostAd.CategoryId,Userlist.UserId,Division.ID AS DivisionId,
District.DISTRICTID AS DistrictId, PostAd.ProductName, PostAd.Description, PostAd.Price, Division.DIVISION AS DivisionName, District.DISTRICTNM As DistrictName, UserList.Name,
Buy.BuyId,Buy.Quantity,Buy.DeadLine,Buy.BuyerId,Buy.SellerId,Buy.TotalPrice,Buy.Status,Buy.Type
FROM            PostAd INNER JOIN
Buy ON Buy.PostId=PostAd.PostId INNER JOIN
                         Category ON PostAd.CategoryId = Category.CategoryId INNER JOIN
                         PostPic ON PostAd.PostId = PostPic.PostId INNER JOIN
                         UserList ON PostAd.UserId=UserList.UserId INNER JOIN
						 Division ON UserList.Division=Division.ID  INNER JOIN
                         District ON UserList.District=District.DISTRICTID)A INNER JOIN PostPic ON A.PostId=PostPic.PostId WHERE A.BuyerId='" + func.UserId() + "' AND A.Status='Pending' ORDER BY A.PostId DESC";
            func.LoadGrid(adsGridView, query);
        }
        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }

        protected void adsGridView_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            adsGridView.EditIndex = e.NewPageIndex;
            Load();
        }

        protected void btnEdit_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField buyId = (HiddenField)row.FindControl("HiddenField2");
            HiddenField postId = (HiddenField)row.FindControl("idHiddenField");
            Response.Redirect("/Buyer/order-product.aspx?id=" + postId.Value + "&buyId=" + buyId.Value + "&allow=yes");
        }

        protected void btnRemove_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField HiddenField2 = (HiddenField)row.FindControl("HiddenField2");
            bool result = func.Execute($"DELETE FROM BUY WHERE BuyId='{HiddenField2.Value}'");
            if (result)
            {
                func.Alert(Page, alert.DeleteSuccess, "s", false);
                Load();
            }
            else
            {
                func.Alert(Page, alert.DeleteFailed, "e", true);
            }
        }
    }
}