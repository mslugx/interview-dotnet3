using GroceryStoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using GroceryStoreAPI.Domain.Models.BackendModels;
using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GroceryStoreAPI.UnitTest
{
    public class BaseUnitTest
    {
        internal static CustomerDbContext _context;
        internal static IContainer _serviceContainer;

        public void InitializeBaseUnitTest()
        {
            BuildContainer();
        }

        private static void BuildContainer()
        {
          
            var builder = new ContainerBuilder();
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            var options = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseInMemoryDatabase(databaseName: "CustomerDetail").Options;
            _context = new CustomerDbContext(options);
            builder.Register(c => _context);
            _serviceContainer = builder.Build();
             
        }

        public static async void PopulateDb()
        {
            if (_context == null)
            {
                var options = new DbContextOptionsBuilder<CustomerDbContext>()
                    .UseInMemoryDatabase(databaseName: "CustomerDetail").Options;
                _context = new CustomerDbContext(options);
            }
            
            if (_context.Customers.Any())
            {
                return;
            }

            _context.Customers.Add(new Customer { Id = 1, Name = "Bob" });
            _context.Customers.Add(new Customer { Id = 2, Name = "Mary" });
            _context.Customers.Add(new Customer { Id = 3, Name = "Jacob" });

            await _context.SaveChangesAsync();
            
        }
    }
}
