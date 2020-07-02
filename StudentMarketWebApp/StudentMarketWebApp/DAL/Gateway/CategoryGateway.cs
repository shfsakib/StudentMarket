using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BitsSoftware
{
    public class CategoryGateway
    {
        private BaseClass func;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        public CategoryGateway()
        {
            func = BaseClass.GetInstance();
            connection = new SqlConnection(func.Connection);
        }

        public int GenerateId()
        {
            string id = "";

            connection.Open();
            command = new SqlCommand(@"SELECT Max(CategoryId) FROM Category", connection);
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
        public int Save(CategoryModel categoryModel)
        {
            string query = @"INSERT INTO Category(CategoryId, CategoryName, InTime) 
VALUES(@CategoryId, @CategoryName,  @InTime)";
            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@CategoryId", categoryModel.CategoryId);
            command.Parameters.AddWithValue("@CategoryName", categoryModel.CategoryName);
            command.Parameters.AddWithValue("@InTime", categoryModel.InTime);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
        public bool IsCategoryExist(string name)
        {


            string query = @"SELECT      * FROM            Category WHERE CategoryName='" + name + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();
            return isExist;

        }
        public List<CategoryModel> GetAllCategory()
        {

            string query = "SELECT * FROM Category ORDER BY CategoryName ASC";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<CategoryModel> CategoryList = new List<CategoryModel>();
            while (reader.Read())
            {
                CategoryModel catagoryModel = new CategoryModel();
                catagoryModel.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                catagoryModel.CategoryName = reader["CategoryName"].ToString();
                catagoryModel.InTime = reader["InTime"].ToString();

                CategoryList.Add(catagoryModel);
            }
            reader.Close();
            connection.Close();
            return CategoryList;
        }
        public List<CategoryModel> NullCategory()
        {


            List<CategoryModel> CategoryList = new List<CategoryModel>();

            CategoryModel catagoryModel = new CategoryModel();
            catagoryModel.CategoryId = 0;
            catagoryModel.CategoryName = "Add a category";
            catagoryModel.InTime = "Not added yet";

            CategoryList.Add(catagoryModel);

            return CategoryList;
        }
        public int updateAllCategory(CategoryModel categoryModel)
        {
            string query = "UPDATE Category SET CategoryName='" + categoryModel.CategoryName + "' WHERE CategoryId='" + categoryModel.CategoryId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
    }
}