using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GroceryStoreAPI.Domain.Models.BackendModels;
using GroceryStoreAPI.Models.FrontendModels.Request;
using GroceryStoreAPI.Models.FrontendModels.Response;

namespace GroceryStoreAPI
{
    public class AutoMapperConfiguration :Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<CustomerRequest, Customer>().ReverseMap();

            CreateMap<Customer,CustomerResponse>().ReverseMap();
        }

    }
}
