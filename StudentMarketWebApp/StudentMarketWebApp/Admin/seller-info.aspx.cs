using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;

namespace StudentMarketWebApp.Admin
{
    public partial class seller_info : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private UserListGateway userListGateway;

        public seller_info()
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
                //func.Type(this, "Buyer");
                Load();
            }
        }
        private void Load()
        {
            string query =
                @"SELECT        UserList.*, Division.DIVISION AS DivisionName, District.DISTRICTNM AS DistrictName
FROM            UserList INNER JOIN
                         Division ON UserList.Division=Division.ID INNER JOIN
                         District ON UserList.District=District.DISTRICTID  WHERE UserList.Status='" + ddlStatus.SelectedValue + "' AND UserList.Type='Seller' ORDER BY UserList.UserId ASC";
            func.LoadGrid(profileGridView, query);
        }
        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }

        protected void ddlStatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Load();
        }

        protected void txtSearch_OnTextChanged(object sender, EventArgs e)
        {
            string query = @"SELECT        UserList.*, Division.DIVISION AS DivisionName, District.DISTRICTNM AS DistrictName
FROM            UserList INNER JOIN
                         Division ON UserList.Division=Division.ID INNER JOIN
                         District ON UserList.District=District.DISTRICTID  WHERE UserList.Status='" + ddlStatus.SelectedValue + "' AND UserList.Type='Seller' AND UserList.NAME LIKE '%" + txtSearch.Text + "%'  ORDER BY UserList.UserId ASC";
            func.LoadGrid(profileGridView, query);
        }

        protected void profileGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField status = (HiddenField)e.Row.FindControl("HiddenField1");
                LinkButton statusButton = (LinkButton)e.Row.FindControl("statusButton");
                if (status.Value == "A")
                {
                    statusButton.CssClass = "btn btn-danger";
                    statusButton.Text = "<i class=\"fas fa-backspace\" style=\"color: white;\"></i>&nbsp;&nbsp;Inactive";
                }
                else if (status.Value == "I")
                {
                    statusButton.CssClass = "btn btn-primary";
                    statusButton.Text = "<i class=\"fas fa-check\" style=\"color: white;\"></i>&nbsp;&nbsp;Active";
                }
                else if (status.Value == "W")
                {
                    statusButton.CssClass = "btn btn-success";
                    statusButton.Text = "<i class=\"fas fa-check\" style=\"color: white;\"></i>&nbsp;&nbsp;Approve";
                }
            }
        }

        protected void statusButton_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField id = (HiddenField)row.FindControl("idHiddenField");
            LinkButton statusButton = (LinkButton)row.FindControl("statusButton");
            if (statusButton.Text == "<i class=\"fas fa-backspace\" style=\"color: white;\"></i>&nbsp;&nbsp;Inactive")
            {
                bool result = func.Execute($"UPDATE UserList SET Status='I' WHERE UserId='{id.Value}'");
                if (result)
                {
                    func.Alert(Page, "Inactivate successfully", "s", true);
                    Load();
                }
                else
                {
                    func.Alert(Page, "Inactivate Failed", "e", true);
                }
            }
            else if (statusButton.Text == "<i class=\"fas fa-check\" style=\"color: white;\"></i>&nbsp;&nbsp;Active")
            {
                bool result = func.Execute($"UPDATE UserList SET Status='A' WHERE UserId='{id.Value}'");
                if (result)
                {
                    func.Alert(Page, "Activate successfully", "s", true);
                    Load();
                }
                else
                {
                    func.Alert(Page, "Activate Failed", "e", true);
                }
            }
            else if (statusButton.Text == "<i class=\"fas fa-check\" style=\"color: white;\"></i>&nbsp;&nbsp;Approve")
            {
                bool result = func.Execute($"UPDATE UserList SET Status='A' WHERE UserId='{id.Value}'");
                if (result)
                {
                    func.Alert(Page, "Approved successfully", "s", true);
                    Load();
                }
                else
                {
                    func.Alert(Page, "Approved Failed", "e", true);
                }
            }
        }

        protected void profileGridView_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            profileGridView.EditIndex = e.NewPageIndex;
            Load();
        }
    }
}