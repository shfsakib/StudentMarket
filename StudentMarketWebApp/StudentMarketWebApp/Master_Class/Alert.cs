using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitSoftware
{
    public class Alert
    {
        private static Alert _instance;

        public static Alert GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Alert();
            }
            return _instance;
        }
        public string InsertSuccess = "Inserted Successfully";
        public string InsertFailed = "Inserted Failed";
        public string UpdateSuccess = "Updated Successfully";
        public string UpdateFailed = "Update Failed";
        public string DeleteSuccess = "Deleted Successfully";
        public string DeleteFailed = "Delete Failed";
        public string Wrong = "Something went wrong! try again.";
    }
}