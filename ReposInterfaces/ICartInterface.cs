using OnlineShoping.Models;

namespace OnlineShoping.ReposInterfaces
{
    public interface ICartInterface
    {
        Task<Cart> GetCartByUserId(int crt_int_usrid);
        Task<Cart> AddtoCart(Cart cartInfo);
        Task<Cart> UpdateCart(Cart cartInfo);
        Task<Cart> RemovefromCart(Cart cartInfo);


    }
}
