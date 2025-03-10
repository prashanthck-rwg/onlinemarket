using Microsoft.AspNetCore.Mvc;
using OnlineShoping.ServiceModels;

namespace OnlineShoping.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderplaceController
    {
        public OrderplaceController()
        {
                                      
        }

        [HttpPost]
        public async IActionResult SavePayment(OrderplaceModel orderplace)
        {
            if (orderplace == null) 
            {
                return BadRequest("Invalid data");
            }
            else


        }

    }
}
