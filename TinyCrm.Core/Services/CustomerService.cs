using System;
using System.Collections.Generic;
using System.Text;
using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;

namespace TinyCrm.Core.Services
{
    class CustomerService :ICustomerService
    {
        public void createCustomer()
        {
            List<Customer> customerList = new List<Customer>();
            Random random = new Random();
            var CustomerId = random.Next(10000);
            Customer customer = new Customer();
            var vatNumber = customer.VatNumber;
           

        }
    }
}
