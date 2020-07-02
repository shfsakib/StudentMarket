using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BitsSoftware;

namespace StudentMarketWebApp.Admin
{
    public partial class add_category : System.Web.UI.Page
    {
        private CategoryGateway categoryGateway;
        private BaseClass func;
        private Alert alert;

        public add_category()
        {
            categoryGateway = new CategoryGateway();
            func = BaseClass.GetInstance();
            alert = Alert.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                func.CheckCookies();
                func.AdminType(this, "Super Admin","Admin");
                LoadCategory();
            }
        }
        private void LoadCategory()
        {
            func.LoadGrid(categoryGridView, "SELECT * FROM Category ORDER BY CategoryId DESC");
        }
        protected void categoryGridView_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            categoryGridView.PageIndex = e.NewPageIndex;
            LoadCategory();
        }

        protected void categoryGridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                if ((categoryGridView.HeaderRow.FindControl("categoryFooterTextBox") as HtmlInputText).Value.Trim() == "")
                    func.Alert(this, "Category Name Required", "w", true);
                else if (categoryGateway.IsCategoryExist((categoryGridView.HeaderRow.FindControl("categoryFooterTextBox") as HtmlInputText).Value.Trim()))
                    func.Alert(this, "Category Name Already Exist", "w", true);
                else
                {
                    CategoryModel categoryModel = new CategoryModel();
                    categoryModel.CategoryId = categoryGateway.GenerateId();
                    categoryModel.CategoryName =
                        (categoryGridView.HeaderRow.FindControl("categoryFooterTextBox") as HtmlInputText).Value.Trim();
                    categoryModel.InTime = func.Date();
                    int a = categoryGateway.Save(categoryModel);
                    if (a > 0)
                    {
                        LoadCategory();
                        func.Alert(this, alert.InsertSuccess, "s", false);
                    }
                    else
                    {
                        func.Alert(this, alert.InsertFailed, "s", false);
                    }
                }
            }
        }

        protected void categoryGridView_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            categoryGridView.EditIndex = e.NewEditIndex;
            LoadCategory();
        }

        protected void categoryGridView_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if ((categoryGridView.Rows[e.RowIndex].FindControl("categoryTextBox") as HtmlInputText).Value.Trim() == "")
                func.Alert(this, "Category Name Required", "w", true);
            else if (
                categoryGateway.IsCategoryExist(
                    (categoryGridView.Rows[e.RowIndex].FindControl("categoryTextBox") as HtmlInputText).Value.Trim()))
                func.Alert(this, "Category Name Already Exist", "w", true);
            else
            {
                var id = (HiddenField)categoryGridView.Rows[e.RowIndex].FindControl("idHiddenField");
                CategoryModel categoryModel = new CategoryModel();
                categoryModel.CategoryName =
                    (categoryGridView.Rows[e.RowIndex].FindControl("categoryTextBox") as HtmlInputText).Value.Trim();
                categoryModel.CategoryId = Convert.ToInt32(id.Value);
                int a = categoryGateway.updateAllCategory(categoryModel);
                if (a > 0)
                {
                    func.Alert(this, alert.UpdateSuccess, "s", false);
                    categoryGridView.EditIndex = -1;
                    LoadCategory();
                }
                else
                {
                    func.Alert(this, alert.UpdateFailed, "s", false);
                }
            }
        }

        protected void categoryGridView_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            categoryGridView.EditIndex = -1;
            LoadCategory();
        }

        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }
    }
}