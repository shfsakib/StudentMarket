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
    public partial class pending_ads : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private PostAdModel postAdModel;
        private PostAdGateway postAdGateway;

        public pending_ads()
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
                func.Type(this, "Seller");
                countN.InnerText = func.SellerNotification(Convert.ToInt32(func.UserId())).ToString();
                   LoadGrid();
            }
        }
        private void LoadGrid()
        {
            string query =
                @"SELECT DISTINCT A.*,(SELECT MIN(Picture) FROM PostPic WHERE PostPic.PostId=A.PostId) AS Picture FROM (SELECT    DISTINCT    PostAd.PostId, PostAd.CategoryId,Userlist.UserId,Division.ID AS DivisionId,District.DISTRICTID AS DistrictId, PostAd.ProductName, PostAd.Description, PostAd.Price,PostAd.Status, Division.DIVISION AS DivisionName, District.DISTRICTNM As DistrictName, UserList.Name,SUBSTRING(PostAd.Intime,1,10) AS Intime
FROM            PostAd INNER JOIN
                         Category ON PostAd.CategoryId = Category.CategoryId INNER JOIN
                         PostPic ON PostAd.PostId = PostPic.PostId INNER JOIN
                         UserList ON PostAd.UserId=UserList.UserId INNER JOIN
						 Division ON UserList.Division=Division.ID  INNER JOIN
                         District ON UserList.District=District.DISTRICTID)A INNER JOIN PostPic ON A.PostId=PostPic.PostId WHERE A.Status='W' AND A.UserId='" + func.UserId()+"' ORDER BY A.PostId DESC";
            func.LoadGrid(adsGridView, query);

        }
        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }

        protected void adsGridView_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            adsGridView.EditIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void btnRemove_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField idHiddenField = (HiddenField)row.FindControl("idHiddenField");
            bool result = func.Execute($"DELETE FROM PostAd WHERE PostId='{idHiddenField.Value}'");
            if (result)
            {
                bool result1 = func.Execute($"DELETE FROM PostPic WHERE PostId='{idHiddenField.Value}'");
                if (result1)
                {
                    func.Alert(Page, alert.DeleteSuccess, "s", false);
                    LoadGrid();
                }
                else
                {
                    func.Alert(Page, alert.DeleteFailed, "e", false);
                }
            }
            else
            {
                func.Alert(Page, alert.DeleteFailed, "e", false);
            }
        }
    }
}