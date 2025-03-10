using OnlineShoping.Models;
using OnlineShoping.ServiceModels;

namespace OnlineShoping.RepositoryInterface
{
    public interface ISavePaymentDetails
    {
        Task<Paymentdetail> AddPaymentDetails(OrderplaceModel orderplaceModel);
        Task<Orderdetail> CreateOrderDetails(OrderplaceModel orderplaceModel);
        Task<Orderitem> CreateOrderItems(OrderplaceModel orderplaceModel);

    }
}
