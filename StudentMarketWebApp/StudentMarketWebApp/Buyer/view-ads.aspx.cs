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
    public partial class view_ads : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private PostAdModel postAdModel;
        private PostAdGateway postAdGateway;

        public view_ads()
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
                func.BindDropDown(ddlCategory, "Select Category", "SELECT CategoryName Name,CategoryId ID FROM Category ORDER BY CategoryName ASC");
                func.BindDropDown(ddlDivision, "select", "SELECT Division Name,ID FROM Division ORDER BY Division ASC");
                LoadGrid();
            }
        }
        private void LoadGrid()
        {
            string query =
                @"SELECT DISTINCT A.*,(SELECT MIN(Picture) FROM PostPic WHERE PostPic.PostId=A.PostId) AS Picture FROM (SELECT    DISTINCT    PostAd.PostId, PostAd.CategoryId,Userlist.UserId,Division.ID AS DivisionId,District.DISTRICTID AS DistrictId, PostAd.ProductName, PostAd.Description, PostAd.Price, Division.DIVISION AS DivisionName, District.DISTRICTNM As DistrictName, UserList.Name
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
            Response.Redirect("/Buyer/order-product.aspx?id=" + id + "&userid=" + userId + "");
        }
    }
}