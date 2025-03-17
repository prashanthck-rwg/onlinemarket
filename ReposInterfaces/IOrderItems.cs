using OnlineShoping.Models;

namespace OnlineShoping.ReposInterfaces
{
    public interface IOrderItems
    {
        Task<Orderitem> CreateItems(Orderitem orderitemsInfo);
    }
}
