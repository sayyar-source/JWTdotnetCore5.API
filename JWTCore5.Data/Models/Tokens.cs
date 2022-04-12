using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTCore5.Data.Models
{
   public class Tokens
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
