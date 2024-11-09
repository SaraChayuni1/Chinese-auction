using Project.DAL;
using Project.Models;
using Project.Models.DTO;
using System;

namespace Project.BLL
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDal customerDal;
        public CustomerService(ICustomerDal customerDal)
        {
            this.customerDal = customerDal;
        }
        public async Task<Customer> CheckCustomer(CustomerDtoLogin customer)
        {
            return await customerDal.CheckCustomer(customer);
        }
        public string Generate(Customer customer)
        {
            return customerDal.Generate(customer);
        }
        public Customer Authenticate(CustomerDto customer)
        {
            return customerDal.Authenticate(customer);
        }
        public async Task<Customer> Add(Customer customer)
        {

            return await customerDal.Add(customer);
        }
        public async Task<List<Customer>> GetAllCustomer()
        {
            return await customerDal.GetAllCustomer();
        }
        public async Task<bool> DeleteCustomer(int customerId)
        {
            return await customerDal.DeleteCustomer(customerId);
        }
        public async Task<Customer> UpdateCustomer(CustomerDto newCustomer, int customerId)
        {
            return await customerDal.UpdateCustomer(newCustomer, customerId);
        }
        public async Task<Customer> FindCustomerByName(string name)
        {
            return await customerDal.FindCustomerByName(name);
        }
        public async Task<Customer> FindCustomerById(int Id)
        {
            return await customerDal.FindCustomerById(Id);
        }
    }
}

