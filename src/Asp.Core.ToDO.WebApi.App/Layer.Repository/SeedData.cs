using Asp.Core.ToDO.WebApi.App.Layer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Core.ToDO.WebApi.App.Layer.Repository
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Look for any movies.
                if (context.People.Any())
                {
                    return;   // DB has been seeded
                }

                context.People.AddRange(
                     new Person
                     {
                         Name = "Riste",
                         Age = 21,
                         Picture = "default.jpg"                
                     },

                    new Person
                    {
                        Name = "Marko",
                        Age = 20,
                        Picture = "default.jpg"
                    },

                   new Person
                   {
                       Name = "Igor",
                       Age = 21,
                       Picture = "default.jpg"
                   },

                   new Person
                   {
                       Name = "Marija",
                       Age = 21,
                       Picture = "default.jpg"
                   }
                );
                
                context.SaveChanges();
            }
        }
    }
}
