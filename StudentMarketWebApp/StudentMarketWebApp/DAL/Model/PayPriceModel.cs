using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentMarketWebApp.DAL.Model
{
    public class PayPriceModel
    {
        private static PayPriceModel _instance;
        private static List<PayPriceModel> _instanceList;

        public static PayPriceModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PayPriceModel();
            }
            return _instance;
        }
        public static List<PayPriceModel> GetInstanceList()
        {
            if (_instanceList == null)
            {
                _instanceList = new List<PayPriceModel>();
            }
            return _instanceList;
        }

        public int PayId { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public string OrderInvoice { get; set; }
        public double Price { get; set; }
        public string TrxId { get; set; }
        public string Intime { get; set; }
    }
}