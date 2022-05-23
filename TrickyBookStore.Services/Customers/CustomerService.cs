using System;
using TrickyBookStore.Models;
using TrickyBookStore.Repositories.Customers;

namespace TrickyBookStore.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository CustomerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            CustomerRepository = customerRepository;
        }

        public Customer GetCustomerById(long id)
        {
            return CustomerRepository.GetCustomerById(id);
            throw new NotImplementedException();
        }
    }
}
