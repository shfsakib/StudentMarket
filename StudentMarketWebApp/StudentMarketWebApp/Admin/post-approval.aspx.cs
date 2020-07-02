using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;
using StudentMarketWebApp.DAL.Gateway;
using StudentMarketWebApp.DAL.Model;

namespace StudentMarketWebApp.Admin
{
    public partial class post_approval : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private PostAdModel postAdModel;
        private PostAdGateway postAdGateway;

        public post_approval()
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
                func.AdminType(this, "Super Admin", "Admin");
                LoadGrid();
            }
        }
        private void LoadGrid()
        {
            string query =
                @"SELECT DISTINCT A.*,(SELECT MIN(Picture) FROM PostPic WHERE PostPic.PostId=A.PostId) AS Picture FROM (SELECT    DISTINCT    PostAd.PostId, PostAd.CategoryId,Userlist.UserId,Division.ID AS DivisionId,District.DISTRICTID AS DistrictId, PostAd.ProductName, PostAd.Description, PostAd.Price, Division.DIVISION AS DivisionName, District.DISTRICTNM As DistrictName, UserList.Name,Category.CategoryName,PostAd.Status
FROM            PostAd INNER JOIN
                         Category ON PostAd.CategoryId = Category.CategoryId INNER JOIN
                         PostPic ON PostAd.PostId = PostPic.PostId INNER JOIN
                         UserList ON PostAd.UserId=UserList.UserId INNER JOIN
						 Division ON UserList.Division=Division.ID  INNER JOIN
                         District ON UserList.District=District.DISTRICTID)A INNER JOIN PostPic ON A.PostId=PostPic.PostId WHERE A.Status='W' ORDER BY A.PostId DESC";
            func.LoadGrid(adsGridView, query);

        }
        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
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
            Response.Redirect("/Admin/view-ads.aspx?id=" + id + "&userid=" + userId + "");
        }

        protected void btnAccept_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField id = (HiddenField)row.FindControl("idHiddenField");
            bool result = func.Execute($"UPDATE PostAd SET Status='A' WHERE PostId='{id.Value}'");
            if (result)
            {
                func.Alert(Page, "Post Approved successfully", "s", true);
                LoadGrid();
            }
            else
            {
                func.Alert(Page, "Post Approved Failed", "e", true);
            }

        }

        protected void btnRemove_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField id = (HiddenField)row.FindControl("idHiddenField");
            bool result = func.Execute($"DELETE FROM PostAd WHERE PostId='{id.Value}'");
            if (result)
            {
                bool result1 = func.Execute($"DELETE FROM PostPic WHERE PostId='{id.Value}'");
                if (result1)
                {
                    func.Alert(Page, "Post Removed Successfully", "s", false);
                    LoadGrid();
                }
                else
                {
                    func.Alert(Page, "Post Removed Failed", "e", false);
                }
            }
            else
            {
                func.Alert(Page, "Post Removed Failed", "e", false);
            }
        }
    }
}