using OnlineShoping.Models;

namespace OnlineShoping.ReposInterfaces
{
    public interface IProductInterface
    {
        Task<Product> Getallproduct();
        Task<Product> Addproduct(Product productinfo);
        Task<Product> Updateproduct(Product productinfo);
        Task<Product> Removeproduct(int Prod_int_ID);
    }
}
