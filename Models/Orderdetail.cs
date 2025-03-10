using System.ComponentModel.DataAnnotations;

namespace OnlineShoping.Models
{
    public class Orderdetail
    {
        public int ordetail_int_id { get; set; }
        public int ordetail_user_id { get; set; }
        public Decimal ordetail_int_total { get; set; }
        public int ordetail_int_pmdid { get; set; }
        public DateTime ordetail_created_at { get; set; }
        public DateTime ordetail_modified_at { get; set; }



        public virtual User usr_int_id { get; set; }

        public virtual Paymentdetail pmd_int_id { get; set; }

        public virtual ICollection<Orderitem> Orderitems { get; set; }

        public virtual ICollection<Paymentdetail> Paymentdetails { get; set; }


    }
}
