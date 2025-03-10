using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OnlineShoping.Data;
using OnlineShoping.Models;
using OnlineShoping.RepositoryInterface;

namespace OnlineShoping.Repository
{
    public class AddRemoveCart : IAddCartandRemoveCart
    {
        private readonly DataContext _dbcontext;

        public AddRemoveCart(DataContext dbContext) 
        {
            _dbcontext = dbContext;
        }
        public async Task<Cart> AddtoCart(Cart cartInfo)
        {
            var carttotal = await _dbcontext.Products.Select(p => new { Amount = p.Prod_mny_Price - p.Prod_int_DiscId }).ToList();

            var carttotal = await(from prd in _dbcontext.Products where prd.Prod_int_ID = cartInfo.crt_int_prod_id  Select(p => new { Amount = p.Prod_mny_Price - p.Prod_int_DiscId }).ToList();

            Cart NewCart = new Cart
            {
                crt_int_usrid = cartInfo.crt_int_usrid,
                crt_int_prod_id = cartInfo.crt_int_prod_id,
                crt_int_quanty = cartInfo.crt_int_quanty,
                crt_total = carttotal,
                crt_create_at = DateTime.UtcNow,

            };

      
            _dbcontext.Add(NewCart);

            await _dbcontext.SaveChangesAsync();

            return NewCart;
        }

        public async Task<Cart> GetCartByUserId(int crt_int_usrid)
        {
            var user =  _dbcontext.Carts.Any(p => p.crt_int_Id == crt_int_usrid);

            if (user == null)
            {
                return null;
            }

           return await _dbcontext.Carts.Where(p => p.crt_int_usrid == crt_int_usrid).FirstOrDefaultAsync();

            
        }

        public async Task<Cart> RemovefromCart(int crt_int_Id)
        {
            var cart = await _dbcontext.Carts.FirstOrDefaultAsync(c => c.crt_int_Id == crt_int_Id);


            if (cart == null)
            {
                return null;

            }

            _dbcontext.Carts.Remove(cart);
            await _dbcontext.SaveChangesAsync();
            return cart;
        }
    }
}
