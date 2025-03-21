﻿using Microsoft.EntityFrameworkCore;
using OnlineShoping.Data;
using OnlineShoping.Models;
using OnlineShoping.Repository;
using OnlineShoping.ServiceModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoping.Service
{
    public class SavePaymentdetails
    {
        private readonly SavePaymentRepository _savePaymentRepository;
        private readonly DataContext _dataContext;

        public SavePaymentdetails(SavePaymentRepository savePaymentRepository, DataContext dataContext)
        {
            _savePaymentRepository = savePaymentRepository;
            _dataContext = dataContext;
        }

        public async Task<Paymentdetail?> AddPaymentDetails(OrderplaceModel orderplace)
        {
            var paymentResult = await _savePaymentRepository.AddPaymentDetails(orderplace);

            if (paymentResult == null)
            {
                return null;
            }

            // Fetch the payment details based on the orderplace ID
            var paymentDetail = await _dataContext.Paymentdetails
                .FirstOrDefaultAsync(p => p.pmd_int_id == orderplace.pmd_int_id);

            if (paymentDetail == null || paymentDetail.pmd_str_status != "Success")
            {
                return null;
            }

            // Create order details
            var orderDetails = await _savePaymentRepository.CreateOrderDetails(orderplace);
            if (orderDetails == null)
            {
                return null;
            }

            // Fetch cart products for the user
            var cartProducts = await (from crt in _dataContext.Carts
                                      join prd in _dataContext.Products on crt.crt_int_prod_id equals prd.Prod_int_ID
                                      join usr in _dataContext.Users on crt.crt_int_usrid equals usr.usr_int_id
                                      where crt.crt_int_prod_id == orderplace.prod_id && crt.crt_int_usrid == orderplace.user_id
                                      select crt).ToListAsync();

            if (!cartProducts.Any())
            {
                return null;
            }

            // Fetch order detail for the user
            var orderDetail = await _dataContext.Orderdetails
                .FirstOrDefaultAsync(p => p.ordetail_user_id == orderplace.user_id);

            if (orderDetail == null)
            {
                return null;
            }

            // Save order items
            foreach (var cartItem in cartProducts)
            {
                var orderItem = new Orderitem
                {
                    ord_int_orderdetailid = orderDetail.ordetail_int_id,
                    ord_product_id = cartItem.crt_int_prod_id,
                    ord_created_at = DateTime.UtcNow,
                    ord_modified_at = DateTime.UtcNow,
                };

                _dataContext.Orderitems.Add(orderItem);
            }

            await _dataContext.SaveChangesAsync();

            return paymentDetail;
        }
    }
}










//using Microsoft.EntityFrameworkCore;
//using Microsoft.Identity.Client;
//using OnlineShoping.Data;
//using OnlineShoping.Models;
//using OnlineShoping.Repository;
//using OnlineShoping.ServiceModels;

//namespace OnlineShoping.Service
//{
//    public class SavePaymentdetails
//    {
//        private readonly SavePaymentRepository _savePaymentRepository;
//        private readonly DataContext _dataContext;

//        public SavePaymentdetails(SavePaymentRepository savePaymentRepository, DataContext dataContext)
//        {
//            _savePaymentRepository = savePaymentRepository;
//            _dataContext = dataContext;
//        }
//        public async Task<Paymentdetail> AddPaymentDetails(OrderplaceModel orderplace)
//        {
//           var result =  _savePaymentRepository.AddPaymentDetails(orderplace);

//           var order = _dataContext.Paymentdetails.Where(p => p.pmd_int_id == orderplace.pmd_int_id);

//            var status = await _dataContext.Paymentdetails.Where(p => p.pmd_int_id == orderplace.pmd_int_id)
//            .Select(p => p.pmd_str_status).ToListAsync().ConfigureAwait(false);


//             if (result != null && order != null && status.Contains("Success"))
//             {
//                   var orderdetails = _savePaymentRepository.CreateOrderDetails(orderplace);

//                if (orderdetails != null) 
//                {

//                    var product = await (from crt in _dataContext.Carts
//                                         join prd in _dataContext.Products on crt.crt_int_prod_id equals prd.Prod_int_ID
//                                         join usr in _dataContext.Users on crt.crt_int_usrid equals usr.usr_int_id
//                                         where crt.crt_int_prod_id == orderplace.prod_id && crt.crt_int_usrid == orderplace.user_id
//                                         select crt).ToListAsync().ConfigureAwait(false);

//                    var orderdetailid = await _dataContext.Orderdetails.Where(p => p.ordetail_user_id == orderplace.user_id).FirstOrDefaultAsync();


//                    if (orderdetailid != null && product != null) 
//                    {
//                        foreach (var prod in product)
//                        {
//                            Orderitem Saveorderitems = new Orderitem
//                            {
//                                ord_int_orderdetailid = orderdetailid.ordetail_int_id, 
//                                ord_product_id = prod.crt_int_prod_id,  
//                                ord_created_at = DateTime.Now,
//                                ord_modified_at = DateTime.Now,
//                            };

//                            _dataContext.Orderitems.Add(Saveorderitems);
//                        }
//                        await _dataContext.SaveChangesAsync();
//                    }



//                }

//             }



//            return orderplace;
//        }
//    }
//}
