using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BitsSoftware;
using StudentMarketWebApp.DAL.Model;

namespace StudentMarketWebApp.DAL.Gateway
{
    public class BuyGateway
    {
        private static BuyGateway _instance;
        BaseClass func;
        SqlConnection con;
        SqlCommand cmd;
        private SqlDataReader reader;
        private BuyModel buyModel;

        public BuyGateway()
        {
            func = BaseClass.GetInstance();
            con = new SqlConnection(func.Connection);
            cmd = new SqlCommand("", con);
            buyModel = BuyModel.GetInstance();
        }
        public static BuyGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BuyGateway();
            }
            return _instance;
        }
        public string GenerateInvoice()
        {
            string date = DateTime.Now.ToString("yyyyMM");
            int id;
            string invoice = "";
            if (con.State != ConnectionState.Open)
                if (con.State != ConnectionState.Open) con.Open();
            cmd = new SqlCommand(@"SELECT Max(SUBSTRING(Invoice,7,9)) FROM Buy", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                string i = reader[0].ToString();

                if (i == "")
                {
                    id = 1;
                    invoice = "000" + id;
                }
                else
                {
                    id = int.Parse(i) + 1;
                }
                if (id < 10)
                {
                    invoice = "000" + id;
                }
                else if (id < 100)
                {
                    invoice = "00" + id;
                }
                else if (id < 1000)
                {
                    invoice = "0" + id;

                }
                else
                {
                    invoice = id.ToString();
                }


            }

            reader.Close();
            if (con.State != ConnectionState.Closed)
                if (con.State != ConnectionState.Closed) con.Close();
            string sl = date + invoice;
            return sl;
        }
        internal bool SaveBuy(BuyModel buyModel)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    if (con.State != ConnectionState.Open) con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO Buy(BuyId, Invoice, PostId, Price, TotalPrice, BuyerId, SellerId, DeadLine,Quantity,PaymentMethod, Status,Type, Intime)" +
                                     " VALUES(@BuyId, @Invoice, @PostId, @Price, @TotalPrice, @BuyerId, @SellerId, @DeadLine,@Quantity,@PaymentMethod, @Status,@Type, @Intime)", con);
                cmd.Parameters.AddWithValue("@PostId", buyModel.PostId);
                cmd.Parameters.AddWithValue("@BuyId", buyModel.BuyId);
                cmd.Parameters.AddWithValue("@Invoice", buyModel.Invoice);
                cmd.Parameters.AddWithValue("@Price", buyModel.Price);
                cmd.Parameters.AddWithValue("@TotalPrice", buyModel.TotalPrice);
                cmd.Parameters.AddWithValue("@BuyerId", buyModel.BuyerId);
                cmd.Parameters.AddWithValue("@SellerId", buyModel.SellerId);
                cmd.Parameters.AddWithValue("@DeadLine", buyModel.DeadLine);
                cmd.Parameters.AddWithValue("@Quantity", buyModel.Quantity);
                cmd.Parameters.AddWithValue("@PaymentMethod", buyModel.PaymentMethod);
                cmd.Parameters.AddWithValue("@Status", buyModel.Status);
                cmd.Parameters.AddWithValue("@Type", buyModel.Type);
                cmd.Parameters.AddWithValue("@Intime", buyModel.Intime);
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                result = true;
                if (con.State != ConnectionState.Closed)
                    if (con.State != ConnectionState.Closed) con.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
            return result;
        }
        internal BuyModel GetOrder(int id)
        {
            if (con.State != ConnectionState.Open)
                if (con.State != ConnectionState.Open) con.Open();
            string query = @"SELECT * FROM Buy WHERE BuyId='" + id + "'";
            cmd = new SqlCommand(query, con);
            reader = cmd.ExecuteReader();
            buyModel = null;
            while (reader.Read())
            {
                buyModel = new BuyModel();
                buyModel.BuyId = Convert.ToInt32(reader["BuyId"]);
                buyModel.BuyerId = Convert.ToInt32(reader["BuyerId"]);
                buyModel.SellerId = Convert.ToInt32(reader["SellerId"]);
                buyModel.Quantity = Convert.ToInt32(reader["Quantity"]);
                buyModel.PostId = Convert.ToInt32(reader["PostId"]);
                buyModel.Invoice = reader["Invoice"].ToString();
                buyModel.DeadLine = reader["DeadLine"].ToString();
                buyModel.Price = Convert.ToDouble(reader["Price"]);
                buyModel.TotalPrice = Convert.ToDouble(reader["TotalPrice"]);
                buyModel.PaymentMethod = reader["PaymentMethod"].ToString();
                buyModel.Type = reader["Type"].ToString();
                buyModel.Status = reader["Status"].ToString();
                buyModel.Intime = reader["Intime"].ToString();
            }
            reader.Close();
            if (con.State != ConnectionState.Closed)
                if (con.State != ConnectionState.Closed) con.Close();
            return buyModel;
        }
    }
}