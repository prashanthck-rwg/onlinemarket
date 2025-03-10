using System.ComponentModel.DataAnnotations;

namespace OnlineShoping.Models
{
    public class Orderitem
    {
        public int ord_int_id { get; set; }
        public int ord_int_orderdetailid { get; set; }
        public int ord_product_id { get; set; }
        public DateTime ord_created_at { get; set; }
        public DateTime ord_modified_at {  get; set; }



        public virtual Orderdetail ordetail_int_id { get; set; }

        public virtual Product Prod_int_ID { get; set; }
    }
}
