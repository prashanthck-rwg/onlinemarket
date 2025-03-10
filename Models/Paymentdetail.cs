using System.ComponentModel.DataAnnotations;

namespace OnlineShoping.Models
{
    public class Paymentdetail
    {
        public int pmd_int_id { get; set; }
        public int pmd_int_orderid { get; set; }
        public decimal pmd_mny_amount { get; set; }
        public string pmd_str_status { get; set; }
        public DateTime pmd_created_at { get; set; }
        public DateTime pmd_modified_at { get; set; }


        public virtual Orderdetail ordetail_int_id { get; set; }

        public virtual ICollection<Orderdetail> Orderdetails { get; set; }

    }
}
