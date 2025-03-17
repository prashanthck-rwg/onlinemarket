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
        public async Task<IActionResult> Addcart([FromBody] Cart cart)
        {
            if(cart == null)
            {
                return BadRequest("Invalid Data");
            }

           var result = await _addCartandRemoveCart.AddtoCart(cart);

            if( result == null)

                return BadRequest("Failed to add cart.");

            return Ok("Cart added successfully");     
        }

        [HttpPost("Get")]

        public async Task<IActionResult> GetCartbyUsrid(int usr_int_id)
        {
            if(usr_int_id <= 0)
            {
                return BadRequest("Invalid Data");
            }
            var cartdata =  await _addCartandRemoveCart.GetCartByUserId(usr_int_id);
            if(cartdata == null) 
            { 
                return NotFound("Cart not found.");
            }

            return Ok(cartdata);
        }

        [HttpDelete("RemoveCart")]
        public async Task<IActionResult> RemoveCart(int usr_int_id)
        {
            if (usr_int_id <= 0)
            {
                return BadRequest("Invalid User ID.");
            }

            var isRemoved = await _addCartandRemoveCart.RemovefromCart(usr_int_id);

            if (!isRemoved)
            {
                return NotFound("Cart not found or already removed.");
            }

            return Ok("Cart removed successfully.");
        }
    }
}
