using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GroceryStoreAPI.Domain.Models.BackendModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GroceryStoreAPI.Repository
{
    public class PopulateDb
    {
        public static async void Populate(IServiceProvider serviceProvider)
        {
            using (var context = new CustomerDbContext(serviceProvider.GetRequiredService<DbContextOptions<CustomerDbContext>>()))
            {
                if (context.Customers.Any())
                {
                    return;
                }

                context.Customers.Add(new Customer {Id = 1, Name = "Bob"});
                context.Customers.Add(new Customer {Id = 2, Name = "Mary" });
                context.Customers.Add(new Customer {Id = 3, Name = "Jacob" });

                await context.SaveChangesAsync();
            }
        }
    }
}
