using JWTCore5.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTCore5.Data
{
   public static class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<AppDBContext>();
            if (context.Users.Count() == 0)
            {
                context.Users.AddRange(
                    new List<User>() {
                         new User() {Id=Guid.NewGuid(), FirstName="Ahmet", LastName="Demirel", UserName="admin",Password="123",Email="admin@gmail.com",Role="admin"},
                         new User() {Id=Guid.NewGuid(), FirstName="Mehmet", LastName="Çetin", UserName="manager",Password="123",Email="manager@gmail.com",Role="manager"},
                    });
            }
            context.SaveChanges();
        }
    }
}
