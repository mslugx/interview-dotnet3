using System;
using System.Linq;
using System.Threading.Tasks;
using GroceryStoreAPI.Domain.Models.BackendModels;
using GroceryStoreAPI.IRepository;
using GroceryStoreAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace GroceryStoreAPI.Factory
{
    public class CustomerFactory : ICustomerFactory
    {

        private CustomerDbContext _customerContext;
        public void SetDbContext(CustomerDbContext dbContext)
        {
            _customerContext = dbContext;
        }

        public IQueryable<Customer> GetAll()
        {
            return _customerContext.Customers;
        }
    }
}
