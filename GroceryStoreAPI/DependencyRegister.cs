using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GroceryStoreAPI
{
    public class DependencyRegister
    {
        public static void RegisterResolve(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerDependency();
        }
    }
}
