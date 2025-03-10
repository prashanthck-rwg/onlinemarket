using OnlineShoping.Models;

namespace OnlineShoping.ReposInterfaces
{
    public interface IOrderDetails
    {
        Task<Orderdetail> GetOrderDetailsByUserID(int ordetail_int_id , int ordetail_user_id);
        Task<Orderdetail> AddOrderDetails(Orderdetail orderdetailinfo);
        Task<Orderdetail> UpdateOrderDetails(Orderdetail orderdetailinfo);
        Task<Orderdetail> DeleteOrderDetails(int ordetail_int_id, int ordetail_user_id);
    }
}
