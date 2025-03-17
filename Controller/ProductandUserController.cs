using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OnlineShoping.Models;
using OnlineShoping.ReposInterfaces;
using OnlineShoping.RepositoryInterface;
using OnlineShoping.Service;

namespace OnlineShoping.Controller
{

    //comment

    [Route("api/[controller]")]
    [ApiController]
    public class ProductandUserController : ControllerBase
    {
      
        private readonly IProductandUserInterface _productandUserInterface;
        private readonly Productanduser _productanduser;

        public ProductandUserController(IProductandUserInterface productandUserInterface, Productanduser productanduser)
        {
            
            _productandUserInterface = productandUserInterface;
            _productanduser = productanduser;
        }

        [HttpPost("Register")]

        public async Task<IActionResult> UserCreation([FromBody] User userobject)
        {
            if (userobject == null || string.IsNullOrEmpty(userobject.usr_username))
            {
               return  BadRequest("Invalid data");
            }

            await _productandUserInterface.Createnewuser(userobject).ConfigureAwait(false); 

            return Ok(new {message="User registered successfully"});

        }

        [HttpPost("Login")] 
        public async Task<IActionResult> UserLogins(string usr_username, string usr_password)
        {
            if (string.IsNullOrEmpty(usr_username) || string.IsNullOrEmpty(usr_password))
            {
                return BadRequest("Invalid data");
            }
           var result = await _productanduser.Logincheck(usr_username, usr_password);

            if (result == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });         
            }
            return Ok(new { message = "Logged in successfully" });
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProducts([FromBody]Product prod)
        {
            if (prod == null) 
            {
                return BadRequest("Invalid Data");
            }
            await _productandUserInterface.CreateProduct(prod).ConfigureAwait(false);

            return Ok(new {message = "Product added"});
        }

        [HttpPost("AddDiscount")]

        public async Task<IActionResult> CreateDiscount(Discount disc)
        {
            if(disc == null)
            {
                return BadRequest("Invalid Data");
            }
            await _productandUserInterface.AddDiscount(disc).ConfigureAwait(false);

            return Ok(new { message = "Discount added" });
        }

    }
}
