using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrickyBookStore.Services.Customers;
using TrickyBookStore.Models;

namespace TrickyBookStore.Main
{
    public class CustomerInjector
    {
        private ICustomerService _customerService;
        public CustomerInjector(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public Customer GetCustomerById(long id)
        {
            return _customerService.GetCustomerById(id);
        }
    }
}
