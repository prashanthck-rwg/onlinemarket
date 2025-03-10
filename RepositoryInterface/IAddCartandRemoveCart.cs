using OnlineShoping.Models;

namespace OnlineShoping.RepositoryInterface
{
    public interface IAddCartandRemoveCart
    {
        Task<Cart> GetCartByUserId(int crt_int_usrid);
        Task<Cart> AddtoCart(Cart cartInfo);
        Task<Cart> RemovefromCart(int crt_int_usrid);

    }
}
