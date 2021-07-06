using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryStoreAPI.Domain.Models.BackendModels;

namespace GroceryStoreAPI.Interfaces
{
    public interface ICustomerService
    {
        public Task<IEnumerable<Customer>> GetCustomers();

        public Task<Customer> GetCustomer(int id);

        public Task<Customer> AddCustomer(Customer customer);

        public Task<Customer> UpdateCustomer(Customer customer);
    }
}