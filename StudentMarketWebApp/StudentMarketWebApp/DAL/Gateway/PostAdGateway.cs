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
    public class PostAdGateway
    {
        private static PostAdGateway _instance;
        BaseClass func;
        SqlConnection con;
        SqlCommand cmd;
        private SqlDataReader reader;
        private PostAdModel postAdModel;
        public PostAdGateway()
        {
            func = BaseClass.GetInstance();
            con = new SqlConnection(func.Connection);
            cmd = new SqlCommand("", con);
            postAdModel = PostAdModel.GetInstance();
        }
        public static PostAdGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PostAdGateway();
            }
            return _instance;
        }
        internal bool SavePost(PostAdModel postAdModel)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    if (con.State != ConnectionState.Open) con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO PostAd( PostId,UserId, CategoryId, ProductName, Description, Price, Intime) VALUES(@PostId,@UserId, @CategoryId, @ProductName, @Description, @Price, @Intime)", con);
                cmd.Parameters.AddWithValue("@PostId", postAdModel.PostId);
                cmd.Parameters.AddWithValue("@UserId", postAdModel.UserId);
                cmd.Parameters.AddWithValue("@CategoryId", postAdModel.CategoryId);
                cmd.Parameters.AddWithValue("@ProductName", postAdModel.ProductName);
                cmd.Parameters.AddWithValue("@Description", postAdModel.Description);
                cmd.Parameters.AddWithValue("@Price", postAdModel.Price);
                cmd.Parameters.AddWithValue("@Intime", postAdModel.Intime);
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
        internal bool SavePic(PostAdModel postAdModel)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    if (con.State != ConnectionState.Open) con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO PostPic( PicId, PostId, Picture, Intime) VALUES(@PicId, @PostId, @Picture, @Intime)", con);
                cmd.Parameters.AddWithValue("@PostId", postAdModel.PostId);
                cmd.Parameters.AddWithValue("@PicId", postAdModel.PicId);
                cmd.Parameters.AddWithValue("@Picture", postAdModel.Picture);
                cmd.Parameters.AddWithValue("@Intime", postAdModel.Intime);
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