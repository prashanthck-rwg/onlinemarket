using System.ComponentModel.DataAnnotations;

namespace OnlineShoping.Models
{
    public class User
    {
      public int usr_int_id {  get; set; }
      public string usr_str_name { get; set; }
      public string usr_str_pwd { get; set; }
      public string usr_username { get; set; }
      public string usr_password { get; set;}
      public int usr_phnumber_id { get; set; }
      public DateTime usr_create_at { get; set; }



      public virtual ICollection<Cart> Carts { get; set; }

      public virtual ICollection<Orderdetail> Orderdetails { get; set; }

    }
}
