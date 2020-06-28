using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BitsSoftware
{
    public class BaseClass
    {
        IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);
        private static BaseClass _instance;
        private SqlConnection con;
        public static BaseClass GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BaseClass();
            }
            return _instance;
        }
        public String Connection = new SqlConnectionStringBuilder
        {
            DataSource = ".\\local",
            InitialCatalog = "StuMarketDb",
            UserID = "sa",
            Password = "ShfS@kib2016",
            MultipleActiveResultSets = true,
            Pooling = true,
            MinPoolSize = 0,
            MaxPoolSize = 4000,
            ConnectTimeout = 0
        }.ToString();
        public BaseClass()
        {
            if (con == null)
            {
                con = new SqlConnection(Connection);
            }
        }
        //public string Connen = @"Data Source=.\local;Initial Catalog=cc;Integrated Security=True";
        public void BindDropDown(DropDownList ddl, string root, string query)
        {
            con = new SqlConnection(Connection);
            DataSet dataSet = new DataSet();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                ddl.DataSource = dataSet;
                ddl.DataTextField = "Name";
                ddl.DataValueField = "ID";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("--" + root.ToUpper() + "--"));
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
            catch (Exception ex)
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
        }
        public string Execute(string str)
        {
            string s = "false";
            SqlConnection Conn = new SqlConnection(Connection);
            try
            {

                if (Conn.State != ConnectionState.Open) Conn.Open();
                SqlCommand cmd = new SqlCommand(str, Conn);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                    s = "true";
                else
                    s = "null";
                if (Conn.State != ConnectionState.Closed) Conn.Close();
            }
            catch { if (Conn.State != ConnectionState.Closed) Conn.Close(); }
            return s;
        }
        public string IsExist(string str)
        {
            string result = "";
            try
            {
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader DR = cmd.ExecuteReader();
                while (DR.Read())
                    result = DR[0].ToString();
                DR.Close();
                if (con.State != ConnectionState.Closed) con.Close();
            }
            catch (Exception ex)
            {
                if (con.State != ConnectionState.Closed) con.Close();
            }
            return result;
        }
        public bool ValidDate(TextBox date)
        {
            try
            {
                if (date.Text == "" || date.Text.Length != 10)
                    return true;
                else
                    DateTime.Parse(date.Text, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            }
            catch (Exception EX)
            { return true; }

            return false;
        }
        public bool ValidDateI(HtmlInputText date)
        {
            try
            {
                if (date.Value == "" || date.Value.Length != 10)
                    return true;
                else
                    DateTime.Parse(date.Value, dateformat, System.Globalization.DateTimeStyles.AssumeLocal);
            }
            catch (Exception EX)
            { return true; }

            return false;
        }
        public string Date()
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy_hh:mm:ss");
            return date;
        }
        public DateTime Timezone(DateTime datetime)
        {
            var timezoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime printDate = TimeZoneInfo.ConvertTime(datetime, timezoneInfo);
            return printDate;
        }
        public void FocusTools(Page page, string toolName)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "script", "$('#ContentPlaceHolder1_" + toolName + "').focus()", true);
        }
        public void Alert(Page page, string msg, string type, bool confirm)
        {
            int timer = 0;
            if (type == "s")
            {
                type = "success";
            }
            else if (type == "e")
            {
                type = "error";
            }
            else if (type == "w")
            {
                type = "warning";
            }
            if (confirm)
            {
                timer = 60000;
            }
            else
            {
                timer = 1500;
            }
            string alert = @"Swal.fire({  position: 'center',  icon: '" + type + "',title: '" + msg + "',showConfirmButton:'" + confirm + "',timer:'" + timer + "'})";
            ScriptManager.RegisterStartupScript(page, page.GetType(), "Popup", alert, true);
        }
        public bool EmailValidation(string email)
        {
            try
            {
                var add = new System.Net.Mail.MailAddress(email);
                return add.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public void LoadGrid(GridView ob, string query)
        {
            DataTable table = new DataTable();
            SqlConnection con = new SqlConnection(Connection);
            try
            {
                ob.Visible = true;
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                ob.DataSource = table;
                ob.DataBind();
                if (con.State != ConnectionState.Closed) con.Close();
            }
            catch (Exception ex)
            {
                if (con.State != ConnectionState.Closed) con.Close();
            }
        }
        public void LoadRepeater(Repeater ob, string query)
        {
            DataTable table = new DataTable();
            SqlConnection con = new SqlConnection(Connection);
            try
            {
                ob.Visible = true;
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                ob.DataSource = table;
                ob.DataBind();
                if (con.State != ConnectionState.Closed) con.Close();
            }
            catch (Exception ex)
            {
                if (con.State != ConnectionState.Closed) con.Close();
            }
        }
        public bool MobileNoValidation(string mobileNo)
        {
            try
            {
                if (mobileNo == "" || mobileNo.Length < 11 || !mobileNo.StartsWith("0"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }
        public bool SendEmail(string fromMail, string toMail, string subject, string body, string fromPass)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(fromMail);
                message.To.Add(new MailAddress(toMail));
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = body;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromMail, fromPass);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string CheckPassword(string pass)
        {
            if (pass.Length < 6 || pass.Length > 15)
            {
                return "Password must be between 6-15 character";
            }
            else if (pass.Contains(" "))
            {
                return "Remove space from your password";
            }
            else if (!pass.Any(char.IsUpper))
            {
                return "Password must have at least one capital latter";
            }
            else if (!pass.Any(char.IsLower))
            {
                return "Password must have at least one small latter";
            }
            else if (!pass.Any(char.IsDigit))
            {
                return "Password must be a combination of alphanumeric characters";
            }
            else
            {
                return "Strong password";
            }
        }
        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public void CheckCookies()
        {
            HttpCookie cookies = HttpContext.Current.Request.Cookies["Stu"];
            if (cookies == null)
            {
                HttpContext.Current.Response.Redirect("/Web/login.aspx", true);
            }
        }

        public void Logout()
        {
            HttpCookie cookies = HttpContext.Current.Request.Cookies["Stu"];
            cookies.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(cookies);
            HttpContext.Current.Response.Redirect("/Web/login.aspx");
        }
        public string UserId()
        {
            HttpCookie cookie = new HttpCookie("Stu");
            HttpCookie cookies = HttpContext.Current.Request.Cookies["Stu"];
            return cookies["UserId"];
        }
        public string Name()
        {
            HttpCookie cookie = new HttpCookie("Stu");
            HttpCookie cookies = HttpContext.Current.Request.Cookies["Stu"];
            return cookies["Name"];
        }
        public string Mobile()
        {
            HttpCookie cookie = new HttpCookie("Stu");
            HttpCookie cookies = HttpContext.Current.Request.Cookies["Stu"];
            return cookies["Mobile"];
        }
        public string Email()
        {
            HttpCookie cookie = new HttpCookie("Stu");
            HttpCookie cookies = HttpContext.Current.Request.Cookies["Stu"];
            return cookies["Email"];
        }

        public void Type(Page page, string type)
        {
            HttpCookie cookie = new HttpCookie("Stu");
            HttpCookie cookies = HttpContext.Current.Request.Cookies["Stu"];
            if (cookies["Type"] != type)
            {
                HttpContext.Current.Response.Redirect("/Web/login.aspx");
            }
        }
        public string SchoolId()
        {
            HttpCookie cookie = new HttpCookie("Stu");
            HttpCookie cookies = HttpContext.Current.Request.Cookies["Stu"];
            return cookies["SchoolId"];

        }
        public string GenerateId(string query)
        {
            string id = "";
            try
            {
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    id = reader[0].ToString();
                    if (id == "")
                        id = "1001";
                    else
                    {
                        id = (int.Parse(id) + 1).ToString();
                    }

                }
                reader.Close();
                if (con.State != ConnectionState.Closed) con.Close();
            }
            catch
            {
            }
            return id;
        }

        public bool CheckNegative(string value)
        {
            int intValue = Convert.ToInt32(value);
            if (intValue < 0)
                return true;
            else
                return false;
        }
    }
}