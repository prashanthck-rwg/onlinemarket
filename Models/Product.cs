using System.ComponentModel.DataAnnotations;

namespace OnlineShoping.Models
{
    public class Product
    {
        public int Prod_int_ID { get; set; }
        public string Prod_str_Name { get; set; }   
        public decimal Prod_mny_Price { get; set; }
        public int Prod_int_DiscId { get; set; }
        public DateTime Prod_Created_at { get; set; }
        public DateTime Prod_Modified_at { get; set; }



        public virtual Discount disc_int_id { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }

        public virtual ICollection<Orderitem> Orderitems { get; set; }


    }
}
