using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BitSoftware;
using StudentMarketWebApp.DAL.Model;

namespace StudentMarketWebApp.DAL.Gateway
{
    public class UserListGateway
    {
        private static UserListGateway _instance;
        BaseClass func;
        SqlConnection con;
        SqlCommand cmd;

        public UserListGateway()
        {
            func = BaseClass.GetInstance();
            con = new SqlConnection(func.Connection);
            cmd = new SqlCommand("", con);
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
                cmd = new SqlCommand("INSERT INTO UserList(UserId, Name, Email, MobileNo, DOB, Gender, Division, District, Address, Picture,Password,Type,Status, Intime) VALUES(@UserId, @Name, @Email, @MobileNo, @DOB, @Gender, @Division, @District, @Address, @Picture,@Password,@Type,@Status, @Intime)", con);
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
                cmd.Parameters.AddWithValue("@Password", userListModel.Password);
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
    }
}