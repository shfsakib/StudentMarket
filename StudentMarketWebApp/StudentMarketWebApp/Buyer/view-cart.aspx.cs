using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsSoftware;
using StudentMarketWebApp.DAL.Gateway;
using StudentMarketWebApp.DAL.Model;

namespace StudentMarketWebApp.Buyer
{
    public partial class view_cart : System.Web.UI.Page
    {
        private BaseClass func;
        private Alert alert;
        private PostAdModel postAdModel;
        private PostAdGateway postAdGateway;
        private BuyModel buyModel;
        private BuyGateway buyGateway;
        private DataTable dataTable;
        private DataRow dataRow;

        public view_cart()
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
                LoadGrid();
                CalculateSum();
            }
        }

        private void LoadGrid()
        {
            if (Session["dataGrid"] == null)
            {
                dataTable = new DataTable();
                dataTable.Columns.Add("PostId", typeof (int));

                dataTable.Columns.Add("SellerId", typeof (int));
                dataTable.Columns.Add("Picture", typeof (string));
                dataTable.Columns.Add("Price", typeof (string));
                dataTable.Columns.Add("ProductName", typeof (string));
                Session["dataGrid"] = dataTable;
            }
            else
            {
                FillGrid();
            }
        }

        private void FillGrid()
        {


            dataTable = new DataTable();
            dataTable = (DataTable) Session["dataGrid"];
            cartGridView.DataSource = dataTable;
            cartGridView.DataBind();

        }

        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            func.Logout();
        }

        protected void cartGridView_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            cartGridView.PageIndex = e.NewPageIndex;
            FillGrid();
        }

        protected void btnRemove_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton) sender;
            DataControlFieldCell cell = (DataControlFieldCell) linkButton.Parent;
            GridViewRow row = (GridViewRow) cell.Parent;
            int id=row.RowIndex;
            DataTable dataTable = (DataTable) Session["dataGrid"];
            int rowIndex = id;
            if (dataTable.Rows.Count >= 0)
            {
                dataTable.Rows[rowIndex].Delete();
                cartGridView.DataSource = dataTable;
                cartGridView.DataBind();
            }
        }

        private void CalculateSum()
        {
            double total = 0.0;
            foreach (GridViewRow gridViewRow in cartGridView.Rows)
            {
                string price = (gridViewRow.FindControl("priceLabel") as Label).Text;
                total = total + Convert.ToDouble(price);
            }
            if (total != 0.0)
            {
                lblTotal.Text = total.ToString();

            }
            else
            {
                lblTotal.Text = "0";
            }

        }
    }
}