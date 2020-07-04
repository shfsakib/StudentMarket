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
    public class PayPriceGateway
    {
        BaseClass func;
        SqlConnection con;
        SqlCommand cmd;
        private SqlDataReader reader;
        private PayPriceModel payPriceModel;
        public PayPriceGateway()
        {
            func = BaseClass.GetInstance();
            con = new SqlConnection(func.Connection);
            cmd = new SqlCommand("", con);
            payPriceModel = PayPriceModel.GetInstance();
        }
        private static PayPriceGateway _instance;

        public static PayPriceGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PayPriceGateway();
            }
            return _instance;
        }
        internal bool SavePrice(PayPriceModel payPriceModel)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    if (con.State != ConnectionState.Open) con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO PayPrice(PayId, BuyerId, SellerId, OrderInvoice, Price,TrxId, Intime) VALUES(@PayId, @BuyerId, @SellerId, @OrderInvoice,@Price, @TrxId, @Intime)", con);
                cmd.Parameters.AddWithValue("@PayId", payPriceModel.PayId);
                cmd.Parameters.AddWithValue("@BuyerId", payPriceModel.BuyerId);
                cmd.Parameters.AddWithValue("@SellerId", payPriceModel.SellerId);
                cmd.Parameters.AddWithValue("@OrderInvoice", payPriceModel.OrderInvoice);
                cmd.Parameters.AddWithValue("@Price", payPriceModel.Price);
                cmd.Parameters.AddWithValue("@TrxId", payPriceModel.TrxId);
                cmd.Parameters.AddWithValue("@Intime", payPriceModel.Intime);
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
    }
}