using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoping.Models
{
    public class Discount
    {
       public int disc_int_id { get; set; }
       public string disc_str_name { get; set; }
       public decimal disc_mny_price { get; set; }
       public DateTime disc_created_at { get; set; }


       public virtual ICollection<Product> Products { get; set; }
    }
}
