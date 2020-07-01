using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;

namespace StudentMarketWebApp.Seller
{
    public partial class search_profile : System.Web.UI.Page
    {

        private BaseClass func;
        private Alert alert;
        private UserListGateway userListGateway;
        public search_profile()
        {
            func = BaseClass.GetInstance();
            alert = Alert.GetInstance();
            userListGateway = UserListGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                func.CheckCookies();
                func.Type(this, "Seller");
                countN.InnerText = func.SellerNotification(Convert.ToInt32(func.UserId())).ToString();
                Load();
            }
        }

        private void Load()
        {
            string query =
                @"SELECT        UserList.*, Division.DIVISION AS DivisionName, District.DISTRICTNM AS DistrictName
FROM            UserList INNER JOIN
                         Division ON UserList.Division=Division.ID INNER JOIN
                         District ON UserList.District=District.DISTRICTID  
						 EXCEPT 
						 SELECT        UserList.*, Division.DIVISION AS DivisionName, District.DISTRICTNM AS DistrictName
FROM            UserList INNER JOIN
                         Division ON UserList.Division=Division.ID INNER JOIN
                         District ON UserList.District=District.DISTRICTID WHERE UserList.UserId='"+func.UserId()+ "' ORDER BY UserList.UserId ASC";
            func.LoadGrid(profileGridView,query);

        }
        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }

        protected void profileGridView_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            profileGridView.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void NameLinkButton_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField hidden = (HiddenField)row.FindControl("idHiddenField");
            int id = Convert.ToInt32(hidden.Value);
            Response.Redirect("/Seller/view-profile.aspx?id="+id+"");
        }

        protected void profileGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label empNameLabel = (Label)e.Row.FindControl("NameLabel");
                empNameLabel.Visible = false;
                LinkButton empNameLinkButton = (LinkButton)e.Row.FindControl("NameLinkButton");
                empNameLinkButton.Text = empNameLabel.Text;
            }
        }

        protected void txtSearch_OnTextChanged(object sender, EventArgs e)
        {
            string query =
              @"SELECT        UserList.*, Division.DIVISION AS DivisionName, District.DISTRICTNM AS DistrictName
FROM            UserList INNER JOIN
                         Division ON UserList.Division=Division.ID INNER JOIN
                         District ON UserList.District=District.DISTRICTID   WHERE UserList.NAME LIKE '%" + txtSearch.Text + "%' " +
                         " EXCEPT " +
                         @"SELECT        UserList.*, Division.DIVISION AS DivisionName, District.DISTRICTNM AS DistrictName
FROM            UserList INNER JOIN
                         Division ON UserList.Division=Division.ID INNER JOIN
                         District ON UserList.District=District.DISTRICTID WHERE UserList.UserId='" + func.UserId() + "'  ORDER BY UserList.UserId ASC";
            func.LoadGrid(profileGridView, query);
        }
    }
}