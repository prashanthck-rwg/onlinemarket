﻿using Microsoft.AspNetCore.Http.HttpResults;
using OnlineShoping.Models;
using OnlineShoping.Repository;

namespace OnlineShoping.Service
{
    public class Productanduser
    {
        private readonly ProductandUserRepository _productandUserRepository;

        public Productanduser(ProductandUserRepository productandUserRepository)
        {
            _productandUserRepository = productandUserRepository;
        }

        public async Task<User> Logincheck(string usr_username, string usr_password)
        {
          var result = await _productandUserRepository.UserLogin(usr_username, usr_password);

            if (result.usr_username! = usr_username || result.usr_password! = usr_password)


            {
                return BadRequest("Username or Pwd is wrong");
            }

            return result;  


        }
    }
}
