using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentMarketWebApp.DAL.Model
{
    public class UserListModel
    {
        private static UserListModel _instance;
        private static List<UserListModel> _instanceList;

        public static UserListModel GetInstance()
        {
            if (_instance==null)
            {
                _instance=new UserListModel();
            }
            return _instance;
        }
        public static List<UserListModel> GetInstanceList()
        {
            if (_instanceList == null)
            {
                _instanceList = new List<UserListModel>();
            }
            return _instanceList;
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public int Division { get; set; }
        public int District { get; set; }
        public string Address { get; set; }
        public string Picture { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }
        public string Intime { get; set; }
    }
}