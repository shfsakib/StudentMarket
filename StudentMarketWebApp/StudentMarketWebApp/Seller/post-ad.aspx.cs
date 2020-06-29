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
    public partial class post_ad : System.Web.UI.Page
    {

        private BaseClass func;
        private Alert alert;
        private PostAdModel postAdModel;
        private PostAdGateway postAdGateway;
        public post_ad()
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
                func.BindDropDown(ddlCategory, "Select Category", "SELECT CategoryName Name,CategoryId ID FROM Category ORDER BY CategoryName ASC");
            }
        }

        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }

        protected void btnPost_OnClick(object sender, EventArgs e)
        {
            if (ddlCategory.Text == "--SELECT CATEGORY--")
                func.Alert(Page, "Category is required", "w", true);
            else if (txtProductName.Text == "")
                func.Alert(Page, "Product name is required", "w", true);
            else if (txtDescription.Text == "")
                func.Alert(Page, "Description is required", "w", true);
            else if (txtPrice.Text == "")
                func.Alert(Page, "Product price is required", "w", true);
            else
            {
                ViewState["postId"] = func.GenerateId("SELECT MAX(PostId) FROM PostAd");
                postAdModel.PostId = Convert.ToInt32(ViewState["postId"]);
                postAdModel.UserId = Convert.ToInt32(func.UserId());
                postAdModel.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
                postAdModel.ProductName = txtProductName.Text;
                postAdModel.Description = txtDescription.Text;
                postAdModel.Price = Convert.ToDouble(txtPrice.Text);
                postAdModel.Intime = func.Date();
                bool result = postAdGateway.SavePost(postAdModel);
                if (result)
                {
                    if (files.PostedFile != null)
                    {
                        foreach (HttpPostedFile file in files.PostedFiles)
                        {
                            postAdModel.PicId = Convert.ToInt32(func.GenerateId("SELECT MAX(PicId) FROM PostPic"));
                            postAdModel.PostId = Convert.ToInt32(ViewState["postId"]);
                            string fileName = Path.GetFileName(file.FileName);
                            string imagePath = Server.MapPath("/Photos/Post/") + fileName;
                            file.SaveAs(imagePath);
                            postAdModel.Picture = "/Photos/Post/" + fileName;
                            postAdModel.Intime = func.Date();
                            bool result1 = postAdGateway.SavePic(postAdModel);
                        }
                            
                       
                    }
                    func.Alert(Page, "Posted Successfully", "s", true);
                    Refresh();
                }
                else
                {
                func.Alert(Page, "Failed to posts", "e", true);
                }
            }
        }

        private void Refresh()
        {
            txtProductName.Text = txtDescription.Text = txtPrice.Text = "";
            ddlCategory.SelectedIndex = -1;
        }
    }
}