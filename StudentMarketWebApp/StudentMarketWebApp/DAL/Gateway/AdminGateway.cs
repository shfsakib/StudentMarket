using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BitsSoftware;
using ShabolombiAndroidApp.DLL.Gateway;
using ShabolombiAndroidApp.DLL.Model;

namespace ShabolombiAndroidApp.DLL.Gateway
{
    public class AdminGateway
    {
        private BaseClass func;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        public AdminGateway()
        {
            func = BaseClass.GetInstance();
            connection = new SqlConnection(func.Connection);
        }
        public int GenerateId()
        {
            string id = "";

            connection.Open();
            command = new SqlCommand(@"SELECT Max(AdminId) FROM Admin", connection);
            reader = command.ExecuteReader();
            if (reader.Read())
            {

                id = reader[0].ToString();
                if (id == "")
                {
                    id = "1";
                }
                else
                {
                    id = (int.Parse(id) + 1).ToString();
                }


            }

            reader.Close();
            connection.Close();
            int sl = Convert.ToInt32(id);
            return sl;
        }
        public int Save(AdminModel adminModel)
        {
            string query = @"INSERT INTO Admin(AdminId, Name, Email, MobileNumber, NidNo, Gender, DateofBirth, ProfilePicture, Password, Type, ReferedBy, Status, InTime) VALUES(@AdminId, @Name, @Email, @MobileNumber, @NidNo, @Gender, @DateofBirth, @ProfilePicture, @Password, @Type, @ReferedBy, @Status,  @InTime)";
            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@AdminId", adminModel.AdminId);
            command.Parameters.AddWithValue("@Name", adminModel.Name);
            command.Parameters.AddWithValue("@Email", adminModel.Email);
            command.Parameters.AddWithValue("@MobileNumber", adminModel.MobileNumber);
            command.Parameters.AddWithValue("@NidNo", adminModel.NidNo);
            command.Parameters.AddWithValue("@Gender", adminModel.Gender);
            command.Parameters.AddWithValue("@DateofBirth", adminModel.DateofBirth);
            command.Parameters.AddWithValue("@ProfilePicture", adminModel.ProfilePicture);
            command.Parameters.AddWithValue("@Password", adminModel.Password);
            command.Parameters.AddWithValue("@Type", adminModel.Type);
            command.Parameters.AddWithValue("@ReferedBy", adminModel.ReferedBy);
            command.Parameters.AddWithValue("@Status", adminModel.Status);
            command.Parameters.AddWithValue("@InTime", adminModel.InTime);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
        public bool IsEmailExist(string email)
        {


            string query = "SELECT * FROM Admin WHERE Email='" + email + "' AND Status!='Inactive'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();
            return isExist;

        }
        public bool IsMobileNumberExist(string mobileNumber)
        {


            string query = "SELECT * FROM Admin WHERE MobileNumber='" + mobileNumber + "' AND Status!='Inactive'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();
            return isExist;

        }
        public bool IsNidExist(string nid)
        {


            string query = "SELECT * FROM Admin WHERE NidNo='" + nid + "'  AND Status!='Inactive'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();
            return isExist;

        }
        public bool Login(string email, string password)
        {


            string query = "SELECT * FROM Admin WHERE Email='" + email + "' AND Password='" + password + "' AND Status='Active' COLLATE Latin1_General_CS_AI";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();
            return isExist;

        }
        public List<AdminModel> GetAllAdmin()
        {


            string query = "SELECT * FROM Admin WHERE Status='Active'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<AdminModel> adminModelList=new List<AdminModel>();
            AdminModel adminModel = null;
            while (reader.Read())
            {
                adminModel=new AdminModel();
                adminModel.AdminId = Convert.ToInt32(reader["AdminId"]);
                adminModel.Name = reader["Name"].ToString();
                adminModel.Email = reader["Email"].ToString();
                adminModel.MobileNumber = reader["MobileNumber"].ToString();
                adminModel.NidNo = reader["NidNo"].ToString();
                adminModel.Gender = reader["Gender"].ToString();
                adminModel.DateofBirth = reader["DateofBirth"].ToString();
                adminModel.ProfilePicture = reader["ProfilePicture"].ToString();
                adminModel.Password = reader["Password"].ToString();

                adminModel.Type = reader["Type"].ToString();
                adminModel.ReferedBy = reader["ReferedBy"].ToString();
                adminModel.Status = reader["Status"].ToString();
                adminModel.InTime = reader["InTime"].ToString();

                adminModelList.Add(adminModel);

            }
            connection.Close();
            return adminModelList;

        }
        public List<AdminModel> GetAdminByData(string email)
        {


            string query = "SELECT * FROM Admin WHERE Status='Active' AND NAME+' | '+ MobileNumber LIKE '%" + email + "%'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<AdminModel> adminModelList = new List<AdminModel>();
            AdminModel adminModel = null;
            while (reader.Read())
            {
                adminModel=new AdminModel();
                adminModel.AdminId = Convert.ToInt32(reader["AdminId"]);
                adminModel.Name = reader["Name"].ToString();
                adminModel.Email = reader["Email"].ToString();
                adminModel.MobileNumber = reader["MobileNumber"].ToString();
                adminModel.NidNo = reader["NidNo"].ToString();
                adminModel.Gender = reader["Gender"].ToString();
                adminModel.DateofBirth = reader["DateofBirth"].ToString();
                adminModel.ProfilePicture = reader["ProfilePicture"].ToString();
                adminModel.Password = reader["Password"].ToString();

                adminModel.Type = reader["Type"].ToString();
                adminModel.ReferedBy = reader["ReferedBy"].ToString();
                adminModel.Status = reader["Status"].ToString();
                adminModel.InTime = reader["InTime"].ToString();
                adminModelList.Add(adminModel);
            }
            connection.Close();
            return adminModelList;

        }
        public int UpdateData(AdminModel adminModel)
        {

            string query = @"UPDATE Admin SET Status='" + adminModel.Status + "' WHERE AdminId='" + adminModel.AdminId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
        public List<AdminModel> GetAllRestrictAdmin()
        {


            string query = "SELECT * FROM Admin WHERE Status='Restrict'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<AdminModel> adminModelList = new List<AdminModel>();
            AdminModel adminModel = null;
            while (reader.Read())
            {
                adminModel = new AdminModel();
                adminModel.AdminId = Convert.ToInt32(reader["AdminId"]);
                adminModel.Name = reader["Name"].ToString();
                adminModel.Email = reader["Email"].ToString();
                adminModel.MobileNumber = reader["MobileNumber"].ToString();
                adminModel.NidNo = reader["NidNo"].ToString();
                adminModel.Gender = reader["Gender"].ToString();
                adminModel.DateofBirth = reader["DateofBirth"].ToString();
                adminModel.ProfilePicture = reader["ProfilePicture"].ToString();
                adminModel.Password = reader["Password"].ToString();

                adminModel.Type = reader["Type"].ToString();
                adminModel.ReferedBy = reader["ReferedBy"].ToString();
                adminModel.Status = reader["Status"].ToString();
                adminModel.InTime = reader["InTime"].ToString();

                adminModelList.Add(adminModel);

            }
            connection.Close();
            return adminModelList;

        }
        public List<AdminModel> GetRestrictAdminByData(string email)
        {


            string query = "SELECT * FROM Admin WHERE Status='Restrict' AND NAME+' | '+ MobileNumber LIKE '%" + email + "%'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<AdminModel> adminModelList = new List<AdminModel>();
            AdminModel adminModel = null;
            while (reader.Read())
            {
                adminModel = new AdminModel();
                adminModel.AdminId = Convert.ToInt32(reader["AdminId"]);
                adminModel.Name = reader["Name"].ToString();
                adminModel.Email = reader["Email"].ToString();
                adminModel.MobileNumber = reader["MobileNumber"].ToString();
                adminModel.NidNo = reader["NidNo"].ToString();
                adminModel.Gender = reader["Gender"].ToString();
                adminModel.DateofBirth = reader["DateofBirth"].ToString();
                adminModel.ProfilePicture = reader["ProfilePicture"].ToString();
                adminModel.Password = reader["Password"].ToString();

                adminModel.Type = reader["Type"].ToString();
                adminModel.ReferedBy = reader["ReferedBy"].ToString();
                adminModel.Status = reader["Status"].ToString();
                adminModel.InTime = reader["InTime"].ToString();
                adminModelList.Add(adminModel);
            }
            connection.Close();
            return adminModelList;

        }
        public AdminModel GetData(AdminModel adminModel)
        {


            string query = "SELECT * FROM Admin WHERE Email='" + adminModel.Email + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                adminModel.Name = reader["Name"].ToString();
                adminModel.Type = reader["Type"].ToString();
                adminModel.ProfilePicture = reader["ProfilePicture"].ToString();
                adminModel.Email = reader["Email"].ToString();


                adminModel.AdminId = Convert.ToInt32(reader["AdminId"]);

            }
            connection.Close();
            return adminModel;

        }
        public AdminModel GetAllAdminById(int userId)
        {


            string query = "SELECT * FROM Admin WHERE Status='Active' AND AdminId='"+userId+"'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            
            AdminModel adminModel = null;
            while (reader.Read())
            {
                adminModel = new AdminModel();
                adminModel.AdminId = Convert.ToInt32(reader["AdminId"]);
                adminModel.Name = reader["Name"].ToString();
                adminModel.Email = reader["Email"].ToString();
                adminModel.MobileNumber = reader["MobileNumber"].ToString();
                adminModel.NidNo = reader["NidNo"].ToString();
                adminModel.Gender = reader["Gender"].ToString();
                adminModel.DateofBirth = reader["DateofBirth"].ToString();
                adminModel.ProfilePicture = reader["ProfilePicture"].ToString();
                adminModel.Password = reader["Password"].ToString();

                adminModel.Type = reader["Type"].ToString();
                adminModel.ReferedBy = reader["ReferedBy"].ToString();
                adminModel.Status = reader["Status"].ToString();
                adminModel.InTime = reader["InTime"].ToString();

                

            }
            connection.Close();
            return adminModel;

        }
        public int UpdateAdminData(AdminModel adminModel)
        {

            string query = @"UPDATE Admin SET  Name='"+adminModel.Name+"', Email='"+adminModel.Email+"', MobileNumber='"+adminModel.MobileNumber+"', NidNo='"+adminModel.NidNo+"', Gender='"+adminModel.Gender+"', DateofBirth='"+adminModel.DateofBirth+
                "', ProfilePicture='"+adminModel.ProfilePicture+"', Password='"+adminModel.Password+"' WHERE AdminId='" + adminModel.AdminId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
    }
}