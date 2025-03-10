using OnlineShoping.Models;

namespace OnlineShoping.ReposInterfaces
{
    public interface IPaymentDetails
    {
        Task<Paymentdetail> CreatePaymentDetails(Paymentdetail paymentdetailInfo);

        Task<Paymentdetail> PaymentReverseDetails(Paymentdetail paymentdetailInfo);
    }
}
