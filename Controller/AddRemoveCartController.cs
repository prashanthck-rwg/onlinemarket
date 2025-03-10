using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using OnlineShoping.Models;
using OnlineShoping.Repository;
using OnlineShoping.RepositoryInterface;

namespace OnlineShoping.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddRemoveCartController : ControllerBase
    {
        private readonly IAddCartandRemoveCart _addCartandRemoveCart;

        public AddRemoveCartController(IAddCartandRemoveCart addCartandRemoveCart)
        {
            _addCartandRemoveCart = addCartandRemoveCart;
        }

        [HttpPost("Addcart")]
        public async IActionResult Addcart([FromBody] Cart cart)
        {
            if(cart == null)
            {
                return BadRequest("Invalid Data");
            }

           var result = await _addCartandRemoveCart.AddtoCart(cart);

            if( result != null)
            
              return Ok("Cart added");     
        }

        [HttpPost("Get")]

        public async IActionResult GetCartbyUsrid(int usr_int_id)
        {
            if(usr_int_id == null)
            {
                return BadRequest("Invalid Data");
            }
            await _addCartandRemoveCart.GetCartByUserId(usr_int_id);

            return Ok();
        }

        [HttpDelete("RemoveCart")]

        public async IActionResult RemoveCart(int usr_int_id)
        {
            if (usr_int_id == null)
            {
                return BadRequest("Invalid Data");
            }
            await _addCartandRemoveCart.RemovefromCart(usr_int_id);

            return Ok();

        }
    }
}
