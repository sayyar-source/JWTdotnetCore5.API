using JWTCore5.Data;
using JWTCore5.Data.Dtos;
using JWTCore5.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace JWTCore5.Aplication.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly AppDBContext _db;
        public TokenService(IConfiguration config, AppDBContext db)
        {
            _config = config;
            _db = db;
        }
        public string BuildToken(UserDto user)
        {
            try
            {
                var currentUser = Authenticate(user);
                if (currentUser == null)
                {
                    return null;
                }
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier, currentUser.UserName),
                new Claim(ClaimTypes.Email, currentUser.Email),
                new Claim(ClaimTypes.GivenName, currentUser.FirstName),
                new Claim(ClaimTypes.Surname, currentUser.LastName),
                new Claim(ClaimTypes.Role, currentUser.Role)
            };

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Audience"],
                  claims,
                  expires: DateTime.Now.AddMinutes(15),
                  signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {


                Console.WriteLine("{0} In TokenService/BuildToken.", ex);
                return null;
            }
           
        }
        private User Authenticate(UserDto userLogin)
        {
            try
            {
                var currentUser = _db.Users.FirstOrDefault(o => o.UserName.ToLower() == userLogin.UserName.ToLower() && o.Password == userLogin.Password);

                if (currentUser != null)
                {
                    return currentUser;
                }
                return null;
            }
            catch (Exception ex)
            {

                Console.WriteLine("{0} In TokenService/Authenticate.", ex);
                return null;
            }
         
        }
    }
}
