using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GroceryStoreAPI.Domain.Models.BackendModels;
using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Models.FrontendModels.Request;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomersController(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                return Ok(await _customerService.GetCustomers());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected Error occurred.");
            }
            
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Customer Query Data.");
            }
            try
            {
                return Ok(await _customerService.GetCustomer(id));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected Error occurred.");
            }
            
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCustomer(CustomerRequest customerInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Customer Model.");
            }

            try
            {
                var customer = _mapper.Map<Customer>(customerInfo);
                return Ok(await _customerService.AddCustomer(customer));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected Error occurred.");
            }
            
        }

        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateCustomer(CustomerRequest customerInfo, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Customer Model.");
            }
            try
            {   
                var customer = _mapper.Map<Customer>(customerInfo);
                customer.Id = id;
                return Ok(await _customerService.UpdateCustomer(customer));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected Error occurred.");
            }
            
        }
    }
}
