using JWTCore5.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTCore5.Data
{
   public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {

        }
       public DbSet<User> Users { get; set; }
       public DbSet<Tokens> Tokens { get; set; }
    }
}
