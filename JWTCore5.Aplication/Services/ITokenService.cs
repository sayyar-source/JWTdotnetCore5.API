using JWTCore5.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTCore5.Aplication.Services
{
    public interface ITokenService
    {
       public string BuildToken(UserDto user);
    }
}
