using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStoreAPI.Domain.Models.BackendModels;
using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace GroceryStoreAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerDbContext _customerDbContext;

        public CustomerService(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _customerDbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _customerDbContext.Customers.FirstOrDefaultAsync(op => op.Id == id);
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            try
            {
                _customerDbContext.Customers.Add(customer);
                await _customerDbContext.SaveChangesAsync();
                return customer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            try
            {
                var retrieveCustomer =await (_customerDbContext.Customers.FirstOrDefaultAsync(op => op.Id == customer.Id));

                if (retrieveCustomer == null)
                {
                    return null;    // there is no customer with that id.
                }

                retrieveCustomer.Name = customer.Name;
                await _customerDbContext.SaveChangesAsync();
                return retrieveCustomer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
