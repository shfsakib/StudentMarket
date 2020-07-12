using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using BitsSoftware;

namespace StudentMarketWebApp.Seller
{
    /// <summary>
    /// Summary description for Seller
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
   [System.Web.Script.Services.ScriptService]
    public class Seller : System.Web.Services.WebService
    {
        SqlConnection conn;
        SqlCommand cmd;
        BaseClass func;

        public Seller()
        {
            func = BaseClass.GetInstance();
            conn = new SqlConnection(func.Connection);
            cmd = new SqlCommand("", conn);
        }
        [WebMethod]
        public string HelloWorld(string txt)
        {
            return "Hello World";
        }
        [WebMethod]
        public List<string> GetUsers(string txt)
        {
            List<string> result = new List<string>();
            try
            {

                string query = @"SELECT NAME txt FROM UserList WHERE NAME+' | '+ MobileNo LIKE '%" + txt + "%'" +
                               "EXCEPT SELECT NAME txt FROM UserList WHERE NAME+' | ' + MobileNo ='" + func.Name() + " | " + func.Mobile() + "' AND Status='A'";
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
        public List<string> GetBuyers(string txt)
        {
            List<string> result = new List<string>();
            try
            {

                string query = @"SELECT NAME txt FROM UserList WHERE NAME+' | '+ MobileNo LIKE '%" + txt + "%' AND Type='Buyer'" +
                               "EXCEPT SELECT NAME FROM UserList WHERE NAME+' | ' + MobileNo ='" + func.Name() + " | " + func.Mobile() + "' AND Type='Buyer'";
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
        public List<string> GetPayInvoice(string txt)
        {
            List<string> result = new List<string>();
            try
            {

                string query = @"SELECT PayPrice.OrderInvoice txt FROM PayPrice INNER JOIN UserList ON UserList.UserId=PayPrice.BuyerId  WHERE PayPrice.OrderInvoice+' | '+UserList.Email+' | '+UserList.MobileNo LIKE '%" + txt + "%' AND PayPrice.SellerId='" + func.UserId() + "'";
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
