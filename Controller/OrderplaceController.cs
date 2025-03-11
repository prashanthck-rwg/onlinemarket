using Microsoft.AspNetCore.Mvc;
using OnlineShoping.Service;
using OnlineShoping.ServiceModels;

namespace OnlineShoping.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderplaceController : ControllerBase
    {
        private readonly SavePaymentdetails _savePaymentdetails;

        public OrderplaceController(SavePaymentdetails savePaymentdetails)
        {
            this._savePaymentdetails = savePaymentdetails;
        }

        [HttpPost]
        public async Task<IActionResult> SavePayment(OrderplaceModel orderplace)
        {
            if (orderplace == null) 
            {
                return BadRequest("Invalid data");
            }
            
            var savepayments = await _savePaymentdetails.AddPaymentDetails(orderplace);

            if (savepayments == null)
            {
                return NotFound("Payment processing failed.");
            }
            return Ok();

        }

    }
}
