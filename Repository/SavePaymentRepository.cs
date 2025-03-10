using Microsoft.EntityFrameworkCore;
using OnlineShoping.Data;
using OnlineShoping.Models;
using OnlineShoping.RepositoryInterface;
using OnlineShoping.ServiceModels;

namespace OnlineShoping.Repository
{
    public class SavePaymentRepository : ISavePaymentDetails
    {
        private readonly DataContext _dataContext;
        private readonly ProductandUserRepository _productandUserRepository;

        public SavePaymentRepository(DataContext dataContext, ProductandUserRepository productandUserRepository)
        {
            _dataContext = dataContext;
            _productandUserRepository = productandUserRepository;
        }

        public async Task<Paymentdetail> AddPaymentDetails(OrderplaceModel orderplaceModel)
        {
            Paymentdetail SavePayment = new Paymentdetail
            {

                pmd_int_orderid = orderplaceModel.pmd_int_orderid,

                pmd_mny_amount = orderplaceModel.amount,

                pmd_str_status = "Success",

                pmd_created_at = DateTime.Now,

                pmd_modified_at = DateTime.Now,

            };
            _dataContext.Add(SavePayment);

            await _dataContext.SaveChangesAsync();

            return SavePayment;
        }

        public async Task<Orderdetail> CreateOrderDetails(OrderplaceModel orderplaceModel)
        {
            var user = _productandUserRepository.GetuserbyId(orderplaceModel.user_id);

            Orderdetail SaveOrderDetails = new Orderdetail
            {
                ordetail_user_id = orderplaceModel.user_id,

                ordetail_int_total = orderplaceModel.total,

                ordetail_int_pmdid = orderplaceModel.pmd_int_id,

                ordetail_created_at = DateTime.Now,

                ordetail_modified_at = DateTime.Now,

            };
            _dataContext.Orderdetails.Add(SaveOrderDetails);

            await _dataContext.SaveChangesAsync();
            return SaveOrderDetails;
        }

        public Task<Orderitem> CreateOrderItems(OrderplaceModel orderplaceModel)
        {
            Orderitem Saveorderitems = new Orderitem
            {
                ord_int_orderdetailid = prod.ord_int_orderdetailid,
                ord_product_id = 
                ord_created_at
                ord_modified_at

            }
        }
    }
}
