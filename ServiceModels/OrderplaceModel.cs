using OnlineShoping.Models;

namespace OnlineShoping.ServiceModels
{
    public class OrderplaceModel
    {
        //public Paymentdetail paymentdetails {  get; set; }
        //public Orderitem orditem { get; set; }
        //public Orderdetail orddetails { get; set; }
        public int pmd_int_id { get; set; }

        public int pmd_int_orderid { get; set; }
        public int user_id { get; set; }
        public decimal amount { get; set; }
        public decimal total { get; set; }
        public int prod_id { get; set; }

    }
}
