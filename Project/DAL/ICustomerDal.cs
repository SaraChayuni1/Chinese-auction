using Project.Models;
using Project.Models.DTO;

namespace Project.DAL
{
    public interface ICustomerDal
    {
        public Task<Customer> CheckCustomer(CustomerDtoLogin customer);
        public string Generate(Customer customer);
        public Customer Authenticate(CustomerDto customer);
        public Task<Customer> Add(Customer customer);
        public Task<List<Customer>> GetAllCustomer();
        public Task<bool> DeleteCustomer(int customerId);
        public Task<Customer> UpdateCustomer(CustomerDto newCustomer, int customerId);
        public Task<Customer> FindCustomerByName(string name);
        public Task<Customer> FindCustomerById(int Id);
    }
}
