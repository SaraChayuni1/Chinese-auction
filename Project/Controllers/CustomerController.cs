using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL;
using Project.DAL;
using Project.Models;
using Project.Models.DTO;
using System.Data;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService customerService;
        private readonly IMapper mapper;


        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;

        }

        [AllowAnonymous]
        [HttpPost("/Customer/LoginCustomer")]
        public async Task<IActionResult> LoginCustomer([FromBody] CustomerDtoLogin customer)
        {
            try
            {
                var user = await customerService.CheckCustomer(customer);
                //Authenticate(customer);
                if (user != null)
                {
                    var token = customerService.Generate(user);
                    return Ok(token);
                }
                return Ok("user not found");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("/Customer/Add")]
        public async Task<Customer> Add(CustomerDto customer)
        {
            var c = mapper.Map<Customer>(customer);
            c.Role = 2;
            await customerService.Add(c);
            //Authorize(Roles = "Manager") = "Customer";

            return c;
        }
        [HttpGet("/Customer/GetAllCustomers")]
        public async Task<List<Customer>> GetAllCustomer()
        {
            return await customerService.GetAllCustomer();


        }
        [HttpDelete("/Customer/{customerId}")]
        public async Task<bool> DeleteCustomer(int customerId)
        {
            return await customerService.DeleteCustomer(customerId);
        }
        [HttpPut("/Customer/{customerId}")]
        public async Task<Customer> UpdateCustomer(CustomerDto newCustomer, int customerId)
        {
            return await customerService.UpdateCustomer(newCustomer, customerId);
        }
        [HttpGet("/Customer/{FindCustomerByName}")]
        public async Task<Customer> FindCustomerByName(string FindCustomerByName)
        {
            return await customerService.FindCustomerByName(FindCustomerByName);
        }
        [HttpGet("/Customer/FindCustomerById/{FindCustomerById}")]
        public async Task<Customer> FindCustomerById(int FindCustomerById)
        {
            return await customerService.FindCustomerById(FindCustomerById);
        }
    }
}

