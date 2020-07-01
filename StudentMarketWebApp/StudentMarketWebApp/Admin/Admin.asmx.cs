using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using BitsSoftware;

namespace StudentMarketWebApp.Admin
{
    /// <summary>
    /// Summary description for Admin
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Admin : System.Web.Services.WebService
    {
        SqlConnection conn;
        SqlCommand cmd;
        BaseClass func;

        public Admin()
        {
            func = BaseClass.GetInstance();
            conn = new SqlConnection(func.Connection);
            cmd = new SqlCommand("", conn);
        }
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public List<string> GetBuyers(string txt)
        {
            List<string> result = new List<string>();
            try
            {

                string query = @"SELECT NAME txt FROM UserList WHERE NAME+' | '+ MobileNo LIKE '%" + txt + "%' AND Type='Buyer'";
                using (cmd = new SqlCommand(query, conn))
                {
                    if (conn.State != System.Data.ConnectionState.Open) conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(reader["txt"].ToString().TrimEnd());
                    }
                }
            }
            catch (Exception ex) { }
            return result;
        }
        [WebMethod]
        public List<string> GetSellers(string txt)
        {
            List<string> result = new List<string>();
            try
            {

                string query = @"SELECT NAME txt FROM UserList WHERE NAME+' | '+ MobileNo LIKE '%" + txt + "%' AND Type='Seller'";
                using (cmd = new SqlCommand(query, conn))
                {
                    if (conn.State != System.Data.ConnectionState.Open) conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(reader["txt"].ToString().TrimEnd());
                    }
                }
            }
            catch (Exception ex) { }
            return result;
        }
    }

}
