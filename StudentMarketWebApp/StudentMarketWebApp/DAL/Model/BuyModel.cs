using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentMarketWebApp.DAL.Model
{
    public class BuyModel
    {
        private static BuyModel _instance;
        private static List<BuyModel> _instanceList;

        public static BuyModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BuyModel();
            }
            return _instance;
        }
        public static List<BuyModel> GetInstanceList()
        {
            if (_instanceList == null)
            {
                _instanceList = new List<BuyModel>();
            }
            return _instanceList;
        }

        public int BuyId { get; set; }
        public string Invoice { get; set; }
        public int PostId { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public string DeadLine { get; set; }
        public int Quantity { get; set; }
        public string PaymentMethod { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Intime { get; set; }

    }
}