using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentMarketWebApp.DAL.Model
{
    public class PostAdModel
    {
        private static PostAdModel _instance;
        private static List<PostAdModel> _instanceList;

        public static PostAdModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PostAdModel();
            }
            return _instance;
        }
        public static List<PostAdModel> GetInstanceList()
        {
            if (_instanceList == null)
            {
                _instanceList = new List<PostAdModel>();
            }
            return _instanceList;
        }

        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string DivisionName { get; set; }
        public string DistrictName { get; set; }
        public string Description { get; set; }
        public string PaymentMethod { get; set; }

        public double Price { get; set; }
        public int PicId { get; set; }
        public string Picture { get; set; }
        public string Intime { get; set; }

    }
}