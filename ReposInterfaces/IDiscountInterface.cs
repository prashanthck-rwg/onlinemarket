using OnlineShoping.Models;

namespace OnlineShoping.ReposInterfaces
{
    public interface IDiscountInterface
    {
        Task<Discount> GetallDiscount();
        Task<Discount> AddDiscount(Discount discountInfo);
        Task<Discount> RemoveDiscount(int disc_int_id);
    }
}
