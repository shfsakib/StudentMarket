using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShabolombiAndroidApp.DLL.Model
{
    public class AdminModel
    {
        public int AdminId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string NidNo { get; set; }
        public string Gender { get; set; }
        public string DateofBirth { get; set; }
        public string ProfilePicture { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string ReferedBy { get; set; }
        public string Status { get; set; }
        public string InTime { get; set; }

    }
}