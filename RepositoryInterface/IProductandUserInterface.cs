using OnlineShoping.Models;

namespace OnlineShoping.RepositoryInterface

{
    public interface IProductandUserInterface
    {

        Task<User> Createnewuser(User usr);

        Task<User> UserLogin(string usr_username, string usr_password);

        Task<Product> CreateProduct(Product prod);

        Task<Discount> AddDiscount(Discount disc);

        Task<User> GetuserbyId(int usr_int_id);

    }
}
