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
                cmd = new SqlCommand("INSERT INTO PostAd( PostId,UserId, CategoryId, ProductName, Description, Price,Status, Intime) VALUES(@PostId,@UserId, @CategoryId, @ProductName, @Description, @Price,@Status, @Intime)", con);
                cmd.Parameters.AddWithValue("@PostId", postAdModel.PostId);
                cmd.Parameters.AddWithValue("@UserId", postAdModel.UserId);
                cmd.Parameters.AddWithValue("@CategoryId", postAdModel.CategoryId);
                cmd.Parameters.AddWithValue("@ProductName", postAdModel.ProductName);
                cmd.Parameters.AddWithValue("@Description", postAdModel.Description);
                cmd.Parameters.AddWithValue("@Price", postAdModel.Price);
                cmd.Parameters.AddWithValue("@Status", "W");
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
        internal bool UpdatePic(PostAdModel postAdModel)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    if (con.State != ConnectionState.Open) con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("UPDATE PostPic SET Picture='" + postAdModel.Picture + "' WHERE PicId='" + postAdModel.PicId + "'", con);
                cmd.Parameters.AddWithValue("@PicId", postAdModel.PicId);
                cmd.Parameters.AddWithValue("@Picture", postAdModel.Picture);
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
        internal PostAdModel GetPost(int id,string status)
        {
            if (con.State != ConnectionState.Open)
                if (con.State != ConnectionState.Open) con.Open();
            string query = @"SELECT DISTINCT A.*,(SELECT MIN(Picture) FROM PostPic WHERE PostPic.PostId=A.PostId) AS Picture FROM (SELECT    DISTINCT    PostAd.PostId, PostAd.CategoryId,Userlist.UserId,Division.ID AS DivisionId,District.DISTRICTID AS DistrictId, PostAd.ProductName, PostAd.Description, PostAd.Price,PostAd.Status, Division.DIVISION AS DivisionName, District.DISTRICTNM As DistrictName, UserList.Name,SUBSTRING(PostAd.Intime,1,10) AS Intime,Buy.PaymentMethod
FROM            PostAd INNER JOIN
                         Category ON PostAd.CategoryId = Category.CategoryId INNER JOIN
                         PostPic ON PostAd.PostId = PostPic.PostId INNER JOIN
                         UserList ON PostAd.UserId=UserList.UserId INNER JOIN
						 Division ON UserList.Division=Division.ID  LEFT JOIN
						 Buy ON Buy.PostId=PostAd.PostId INNER JOIN
                         District ON UserList.District=District.DISTRICTID)A INNER JOIN PostPic ON A.PostId=PostPic.PostId WHERE A.PostId='" + id + "' AND A.Status='"+ status + "'";
            cmd = new SqlCommand(query, con);
            reader = cmd.ExecuteReader();
            postAdModel = null;
            while (reader.Read())
            {
                postAdModel = new PostAdModel();
                postAdModel.UserId = Convert.ToInt32(reader["UserId"]);
                postAdModel.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                postAdModel.PostId = Convert.ToInt32(reader["PostId"]);
                postAdModel.ProductName = reader["ProductName"].ToString();
                postAdModel.Description = reader["Description"].ToString();
                postAdModel.Price = Convert.ToDouble(reader["Price"]);
                postAdModel.Picture = reader["Picture"].ToString();
                postAdModel.DivisionName = reader["DivisionName"].ToString();
                postAdModel.DistrictName = reader["DistrictName"].ToString();
                postAdModel.PaymentMethod = reader["PaymentMethod"].ToString();
                postAdModel.Name = reader["Name"].ToString();
                postAdModel.Intime = reader["Intime"].ToString();
            }
            reader.Close();
            if (con.State != ConnectionState.Closed)
                if (con.State != ConnectionState.Closed) con.Close();
            return postAdModel;
        }
    }
}