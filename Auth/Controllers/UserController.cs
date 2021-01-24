using Auth.jWTAuthenticationManager;
using Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;

        public UserController(IJWTAuthenticationManager jWTAuthenticationManager)
        {
            this.jWTAuthenticationManager = jWTAuthenticationManager;
        }
       
        [HttpPost]
          public IActionResult Authenticate([FromBody] UserCred userCred)
       
        {
            
            var token = jWTAuthenticationManager.Authenticate(userCred.Username, userCred.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
            
         
        }
        [Authorize(Policy = "NamePolicy")]
        [HttpGet]
        public IActionResult Test()
        {

            //  var ss = customAuthenticationHandler.HandleAuthenticateAsync();
            return Ok("mosi");
        }
    }
}
