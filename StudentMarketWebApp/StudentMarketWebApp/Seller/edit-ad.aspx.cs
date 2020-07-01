using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;
using StudentMarketWebApp.DAL.Gateway;
using StudentMarketWebApp.DAL.Model;

namespace StudentMarketWebApp.Seller
{
    public partial class edit_ad : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private PostAdModel postAdModel;
        private PostAdGateway postAdGateway;

        public edit_ad()
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
                func.BindDropDown(ddlCategory, "Select Category", "SELECT CategoryName Name,CategoryId ID FROM Category ORDER BY CategoryName ASC");
                Load();
            }
        }

        private void LoadGrid()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            func.LoadGrid(adGridView, "SELECT * FROM PostPic WHERE PostId = '" + id + "'");
        }
        private void Load()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            postAdModel = postAdGateway.GetPost(id, "A");
            ddlCategory.SelectedValue = postAdModel.CategoryId.ToString();
            txtProductName.Text = postAdModel.ProductName;
            txtDescription.Text = postAdModel.Description;
            txtPrice.Text = postAdModel.Price.ToString();

        }
        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }

        protected void categoryGridView_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            adGridView.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void adGridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                FileUpload file = (adGridView.HeaderRow.FindControl("FileUpload") as FileUpload);
                if (file.HasFile && adGridView.Rows.Count < 6)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    postAdModel.PicId = Convert.ToInt32(func.GenerateId("SELECT MAX(PicId) FROM PostPic"));
                    postAdModel.PostId = id;
                    string fileName = Path.GetFileName(file.FileName);
                    string imagePath = Server.MapPath("/Photos/Post/") + fileName;
                    file.SaveAs(imagePath);
                    postAdModel.Picture = "/Photos/Post/" + fileName;
                    postAdModel.Intime = func.Date();
                    bool result = postAdGateway.SavePic(postAdModel);
                    if (result)
                    {
                        func.Alert(Page, alert.InsertSuccess, "s", true);
                        LoadGrid();
                    }
                    else
                    {
                        func.Alert(Page, alert.InsertFailed, "e", true);
                    }
                }

            }
        }

        protected void adGridView_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            adGridView.EditIndex = e.NewEditIndex;
            LoadGrid();
        }

        protected void adGridView_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            FileUpload file = (adGridView.Rows[e.RowIndex].FindControl("editFileUpload") as FileUpload);
            string id = (adGridView.Rows[e.RowIndex].FindControl("HiddenField2") as HiddenField).Value;
            postAdModel.PicId = Convert.ToInt32(id);
            if (file.HasFile)
            {
                string fileName = Path.GetFileName(file.FileName);
                string imagePath = Server.MapPath("/Photos/Post/") + fileName;
                file.SaveAs(imagePath);
                postAdModel.Picture = "/Photos/Post/" + fileName;
                bool result = postAdGateway.UpdatePic(postAdModel);
                if (result)
                {
                    func.Alert(Page, alert.UpdateSuccess, "s", true);
                    adGridView.EditIndex = -1;
                    LoadGrid();
                }
                else
                {
                    func.Alert(Page, alert.UpdateFailed, "e", true);
                }
            }

        }

        protected void adGridView_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            adGridView.EditIndex = -1;
            LoadGrid();
        }

        protected void adGridView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HiddenField id = (HiddenField)adGridView.Rows[e.RowIndex].FindControl("HiddenField1");
            bool result = func.Execute("DELETE FROM PostPic WHERE PicId='" + id.Value + "'");
            if (result)
            {
                func.Alert(Page, alert.DeleteSuccess, "s", true);
                LoadGrid();
            }
            else
            {
                func.Alert(Page, alert.DeleteFailed, "e", true);
            }
        }

        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            bool result = func.Execute($"UPDATE PostAd SET CategoryId='{ddlCategory.SelectedValue}',ProductName='{txtProductName.Text}',Description='{txtDescription.Text}',Price='{txtPrice.Text}' WHERE PostId='{id}'");
            if (result)
            {
                func.Alert(Page, alert.UpdateSuccess, "s", true);
                Load();
            }
            else
            {
                func.Alert(Page, alert.UpdateFailed, "e", true);
            }
        }
    }
}
