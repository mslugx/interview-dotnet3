using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStoreAPI.Domain.Models.BackendModels;
using GroceryStoreAPI.Repository;

namespace GroceryStoreAPI.IRepository
{
    public interface ICustomerFactory
    {
        void SetDbContext(CustomerDbContext dbContext);

        IQueryable<Customer> GetAll();
    }
}
