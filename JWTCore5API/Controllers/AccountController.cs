using JWTCore5.Aplication.Services;
using JWTCore5.Data.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTCore5.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;
  
     
        public AccountController(ITokenService tokenService)
        {
            _tokenService = tokenService;
           
        }
        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public ActionResult Login(UserDto userModel)
        {
            if (string.IsNullOrEmpty(userModel.UserName) || string.IsNullOrEmpty(userModel.Password))
            {
                return RedirectToAction("Error");
            }

            IActionResult response = Unauthorized();
      
                var generatedToken = _tokenService.BuildToken(userModel);
               // HttpContext.Session.SetString("JWToken", generatedToken);
            return Ok(new
                {
                    token = generatedToken,
                    user = userModel.UserName
                });
        }
       
        [HttpGet]
        [Route("get")]
        public ActionResult<IEnumerable<string>> Get()
        {

            var currentUser = HttpContext.User;
            DateTime TokenDate = new DateTime();

            if (currentUser.HasClaim(c => c.Type == "Date"))
            {
                TokenDate = DateTime.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Date").Value);

            }

            return Ok("Custom Claims(date): " + TokenDate);

        }
    }
}
