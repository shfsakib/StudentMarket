using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;

namespace StudentMarketWebApp.Admin
{
    public partial class pending_seller : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private UserListGateway userListGateway;

        public pending_seller()
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
                func.AdminType(this, "Super Admin", "Admin");
                Load();
            }
        }
        private void Load()
        {
            string query =
                @"SELECT        UserList.*, Division.DIVISION AS DivisionName, District.DISTRICTNM AS DistrictName
FROM            UserList INNER JOIN
                         Division ON UserList.Division=Division.ID INNER JOIN
                         District ON UserList.District=District.DISTRICTID  WHERE UserList.Status='W' AND UserList.Type='Seller' ORDER BY UserList.UserId ASC";
            func.LoadGrid(profileGridView, query);
        }
        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }

        protected void txtSearch_OnTextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                string query = @"SELECT        UserList.*, Division.DIVISION AS DivisionName, District.DISTRICTNM AS DistrictName
FROM            UserList INNER JOIN
                         Division ON UserList.Division=Division.ID INNER JOIN
                         District ON UserList.District=District.DISTRICTID  WHERE UserList.Status='W' AND UserList.Type='Seller' AND UserList.NAME LIKE '%" +
                               txtSearch.Text + "%'  ORDER BY UserList.UserId ASC";
                func.LoadGrid(profileGridView, query);
            }
            else
            {
                Load();
            }
        }

        protected void profileGridView_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            profileGridView.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void lnkApprove_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField id = (HiddenField)row.FindControl("idHiddenField");
            LinkButton statusButton = (LinkButton)row.FindControl("statusButton");
            bool result = func.Execute($"UPDATE UserList SET Status='A' WHERE UserId='{id.Value}'");
            if (result)
            {
                func.Alert(Page, "Approved successfully", "s", true);
                Load();
            }
            else
            {
                func.Alert(Page, "Approve Failed", "e", true);
            }
        }

        protected void lnkReject_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField id = (HiddenField)row.FindControl("idHiddenField");
            LinkButton statusButton = (LinkButton)row.FindControl("statusButton");
            bool result = func.Execute($"DELETE FROM UserList WHERE UserId='{id.Value}'");
            if (result)
            {
                func.Alert(Page, "Rejected successfully", "s", true);
                Load();
            }
            else
            {
                func.Alert(Page, "Failed to reject", "e", true);
            }
        }
    }
}