using Microsoft.EntityFrameworkCore;
using OnlineShoping.Data;
using OnlineShoping.Models;
using OnlineShoping.RepositoryInterface;

namespace OnlineShoping.Repository
{
    public class ProductandUserRepository : IProductandUserInterface
    {
        private readonly DataContext _dbcontext;

        public ProductandUserRepository(DataContext dbcontext) 
        {
            _dbcontext = dbcontext;
        }

        public async Task<User> Createnewuser(User usr)
        {
            User Newuser = new User
            {
                usr_int_id = usr.usr_int_id,
                usr_str_name = usr.usr_str_name,
                usr_str_pwd = usr.usr_str_pwd,
                usr_username = usr.usr_username,
                usr_password = usr.usr_password,
                usr_phnumber_id = usr.usr_phnumber_id,

            };
            _dbcontext.Add(Newuser);

            await _dbcontext.SaveChangesAsync();

            return Newuser;
        }

        public async Task<User> UserLogin(string usr_username, string usr_password)
        {
            var user = await _dbcontext.Users.FirstOrDefaultAsync(u => u.usr_username == usr_username && u.usr_password == usr_password);
            if (user == null) 
            {   
                return null;
            }
            return user;
        }

        public async Task<Product> CreateProduct(Product prod)
        {
            Product Newprod = new Product
            {
                Prod_str_Name = prod.Prod_str_Name,
                Prod_mny_Price = prod.Prod_mny_Price,
                Prod_int_DiscId = prod.Prod_int_DiscId,
                Prod_Created_at = DateTime.UtcNow,
                Prod_Modified_at = DateTime.UtcNow,
            };
            _dbcontext.Add(Newprod);

            await _dbcontext.SaveChangesAsync();

            return Newprod;
        }

        public async Task<Discount> AddDiscount(Discount disc)
        {
            Discount Newdisc = new Discount
            {
                disc_str_name = disc.disc_str_name,
                disc_mny_price = disc.disc_mny_price,
                disc_created_at = DateTime.UtcNow,
            };
            _dbcontext.Add(Newdisc);

            await _dbcontext.SaveChangesAsync();

            return Newdisc;

        }

        public async Task<User> GetuserbyId(int usr_int_id)
        {
            return await _dbcontext.Users.FindAsync(usr_int_id);
        }
    }

}
