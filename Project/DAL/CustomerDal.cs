using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project.Models;
using Project.Models.DTO;
using System;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace Project.DAL
{
    public class CustomerDal : ICustomerDal
    {
        private readonly OrdersContext ordersContext;
        private readonly IConfiguration _Config;

        public CustomerDal(OrdersContext ordersContext, IConfiguration config)
        {
            this.ordersContext = ordersContext;
            _Config = config;
        }
        public async Task<Customer> CheckCustomer(CustomerDtoLogin customer)
        {
            try
            {
                var user = ordersContext.Customer.FirstOrDefault(c => c.UserName.ToLower() == customer.UserName.ToLower() && c.Password == customer.Password);
                await Task.Delay(100);
                if (user != null)
                {
                    // throw new Exception($"manager {ManName} not found");
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public string Generate(Customer customer)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                    new Claim("Id",customer.Id.ToString()),
                    new Claim("userName",customer.UserName.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, customer.UserName),
                    new Claim(ClaimTypes.Email, customer.Mail),
                    new Claim(ClaimTypes.OtherPhone, customer.Phone),
                     new Claim("Roles", customer.Role.ToString()),//אם יש טעויות זה כאן
                       new Claim("Password", customer.Password)
            };
            var token = new JwtSecurityToken(_Config["Jwt:Issuer"],
                _Config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public Customer Authenticate(CustomerDto customer)
        {
            var currentUser = ordersContext.Customer.FirstOrDefault(b => b.UserName.ToLower() == customer.UserName.ToLower() && b.Password == customer.Password);
            if (currentUser != null) { return currentUser; }
            return null;
        }
        public async Task<Customer> Add(Customer customer)
        {
            //if (customer.Phone.Length != 10)
            //{
            //    throw new InvalidOperationException("Phone must contain 10 number exactly");
            //}
            //if (customer.Mail == "")
            //{
            //    throw new InvalidOperationException("Phone must contain 10 number exactly");
            //}
         
         
            try
            {
                await ordersContext.Customer.AddAsync(customer);
                await ordersContext.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Customer>> GetAllCustomer()
        {
            try
            {
                return await ordersContext.Customer.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> DeleteCustomer(int customerId)
        {
            try
            {
                List<Customer> customers = await ordersContext.Customer.ToListAsync();
                Customer deleteCustomer = customers.FirstOrDefault(p => p.Id == customerId);
                if (deleteCustomer == null)
                {
                    return false;
                }
                else
                {
                    ordersContext.Customer.Remove(deleteCustomer);
                    await ordersContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Customer> UpdateCustomer(CustomerDto newCustomer, int customerId)
        {
            try
            {
                Customer customerToUpdate = await ordersContext.Customer.FirstOrDefaultAsync(p => p.Id == customerId);
                if (customerToUpdate == null)
                {
                    return null;
                }
                else
                {
                    customerToUpdate.UserName=newCustomer.UserName;
                    customerToUpdate.Mail=newCustomer.Mail;
                    customerToUpdate.Password=newCustomer.Password;
                    customerToUpdate.Phone=newCustomer.Phone;
                    //List<PresentToCartDto> CartDto = customerToUpdate.Present.ToList();
                    //List<PresentToCartDto> CartDto = newCustomer.Present.ToList();
                    //for (int i=0;i< CartDto.Capacity;i++)
                    //{
                    //    CartDto.ElementAt(i)= newCustomer.Present.
                    //}
                    ordersContext.Customer.Update(customerToUpdate);
                    await ordersContext.SaveChangesAsync();
                    return customerToUpdate;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Update Present failed");
            }
        }
        public async Task<Customer> FindCustomerByName(string name)
        {
            try
            {
                List<Customer> customers = await ordersContext.Customer.ToListAsync();
                Customer customer = customers.FirstOrDefault(p => p.UserName == name);
                if (customer == null)
                {
                    return null;
                }
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception("FindPresentByName failed");
            }
        }
        public async Task<Customer> FindCustomerById(int Id)
        {
            try
            {
                List<Customer> customers = await ordersContext.Customer.ToListAsync();
                Customer customer = customers.FirstOrDefault(p => p.Id == Id);
                if (customer == null)
                {
                    return null;
                }
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception("FindPresentByName failed");
            }
        }
    }
}
