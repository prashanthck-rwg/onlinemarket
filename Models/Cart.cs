using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace OnlineShoping.Models
{
    public class Cart
    {
        public int crt_int_Id {  get; set; }
        public int crt_int_usrid { get; set; }
        public int crt_int_prod_id { get; set; }
        public int crt_int_quanty { get; set; }
        public decimal crt_total { get; set; }    
        public DateTime crt_create_at { get; set; }


        public virtual Product Prod_int_ID { get; set; }
        public virtual User usr_int_id { get; set;}

    }
}
