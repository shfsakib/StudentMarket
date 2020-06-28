using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BitsSoftware
{
    public class UserListGateway
    {
        private static UserListGateway _instance;
        BaseClass func;
        SqlConnection con;
        SqlCommand cmd;
        private SqlDataReader reader;
        private UserListModel userListModel;
        public UserListGateway()
        {
            func = BaseClass.GetInstance();
            con = new SqlConnection(func.Connection);
            cmd = new SqlCommand("", con);
            userListModel = UserListModel.GetInstance();
        }
        public static UserListGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserListGateway();
            }
            return _instance;
        }
        internal bool SaveUser(UserListModel userListModel)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    if (con.State != ConnectionState.Open) con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO UserList(UserId, Name, Email, MobileNo, DOB, Gender, Division, District, Address,GNidNo,BCertNo,NidNo, Picture,Password,About,Type,Status, Intime) VALUES(@UserId, @Name, @Email, @MobileNo, @DOB, @Gender, @Division, @District, @Address,@GNidNo,@BCertNo,@NidNo, @Picture,@Password,@About,@Type,@Status, @Intime)", con);
                cmd.Parameters.AddWithValue("@UserId", userListModel.UserId);
                cmd.Parameters.AddWithValue("@Name", userListModel.Name);
                cmd.Parameters.AddWithValue("@Email", userListModel.Email);
                cmd.Parameters.AddWithValue("@MobileNo", userListModel.MobileNo);
                cmd.Parameters.AddWithValue("@DOB", userListModel.DOB);
                cmd.Parameters.AddWithValue("@Gender", userListModel.Gender);
                cmd.Parameters.AddWithValue("@Division", userListModel.Division);
                cmd.Parameters.AddWithValue("@District", userListModel.District);
                cmd.Parameters.AddWithValue("@Address", userListModel.Address);
                cmd.Parameters.AddWithValue("@Picture", userListModel.Picture);
                cmd.Parameters.AddWithValue("@GNidNo", userListModel.GNidNo);
                cmd.Parameters.AddWithValue("@BCertNo", userListModel.BCertNo);
                cmd.Parameters.AddWithValue("@NidNo", userListModel.NidNo);
                cmd.Parameters.AddWithValue("@Password", userListModel.Password);
                cmd.Parameters.AddWithValue("@About", userListModel.About);
                cmd.Parameters.AddWithValue("@Type", userListModel.Type);
                cmd.Parameters.AddWithValue("@Status", userListModel.Status);
                cmd.Parameters.AddWithValue("@Intime", userListModel.Intime);
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
        internal bool UpdateUser(UserListModel userListModel)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    if (con.State != ConnectionState.Open) con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("UPDATE UserList SET  Name=@Name,  MobileNo=@MobileNo, DOB=@DOB, Gender=@Gender, GNidNo=@GNidNo,BCertNo=@BCertNo,NidNo=@NidNo, Picture=@Picture,Password=@Password,About=@About WHERE  UserId=@UserId", con);
                cmd.Parameters.AddWithValue("@UserId", userListModel.UserId);
                cmd.Parameters.AddWithValue("@Name", userListModel.Name);
                cmd.Parameters.AddWithValue("@MobileNo", userListModel.MobileNo);
                cmd.Parameters.AddWithValue("@DOB", userListModel.DOB);
                cmd.Parameters.AddWithValue("@Gender", userListModel.Gender);
                cmd.Parameters.AddWithValue("@Picture", userListModel.Picture);
                cmd.Parameters.AddWithValue("@GNidNo", userListModel.GNidNo);
                cmd.Parameters.AddWithValue("@BCertNo", userListModel.BCertNo);
                cmd.Parameters.AddWithValue("@NidNo", userListModel.NidNo);
                cmd.Parameters.AddWithValue("@Password", userListModel.Password);
                cmd.Parameters.AddWithValue("@About", userListModel.About);
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
        internal UserListModel GetUser(int id)
        {
          if (con.State != ConnectionState.Open)
                    if (con.State != ConnectionState.Open) con.Open();
            string query = @"SELECT        UserList.*, Division.DIVISION AS DivisionName, District.DISTRICTNM AS DistrictName
FROM            UserList INNER JOIN
                         Division ON UserList.Division=Division.ID INNER JOIN
                         District ON UserList.District=District.DISTRICTID WHERE UserList.UserId='"+id+"'";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();
                userListModel = null;
                while (reader.Read())
                {
                    userListModel = new UserListModel();
                    userListModel.UserId = Convert.ToInt32(reader["UserId"]);
                    userListModel.Division = Convert.ToInt32(reader["Division"]);
                    userListModel.District = Convert.ToInt32(reader["District"]);
                    userListModel.Name = reader["Name"].ToString();
                    userListModel.Email = reader["Email"].ToString();
                    userListModel.MobileNo = reader["MobileNo"].ToString();
                    userListModel.Picture = reader["Picture"].ToString();
                    userListModel.DOB = reader["DOB"].ToString();
                    userListModel.Gender = reader["Gender"].ToString();
                    userListModel.DivisionName = reader["DivisionName"].ToString();
                    userListModel.DistrictName = reader["DistrictName"].ToString();
                    userListModel.Address = reader["Address"].ToString();
                    userListModel.GNidNo = reader["GNidNo"].ToString();
                    userListModel.BCertNo = reader["BCertNo"].ToString();
                    userListModel.NidNo = reader["NidNo"].ToString();
                    userListModel.About = reader["About"].ToString();
                    userListModel.Type = reader["Type"].ToString();
                    userListModel.Password = reader["Password"].ToString();
                }
                reader.Close();
                if (con.State != ConnectionState.Closed)
                    if (con.State != ConnectionState.Closed) con.Close();
            return userListModel;
        }
    }
}