using System;
using System.Collections.Generic;
using System.Text;
using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;
using TinyCrm.Core.Services;
using System.Linq;
using TinyCrm.Core.Data;

namespace TinyCrm.Core.Services
{
    public class CustomerService : ICustomerService
    {
        public bool CreateCustomer(Model.Options.CreateCustomerOptions options)
        {
            if (options == null) {
                return false;
            }
            if (!string.IsNullOrWhiteSpace(options.VatNumber)) {
                return false;
            }

            Random random = new Random();
            var randId = random.Next(10000);
            if (randId == 0) {
                return false;
            }
            if (!string.IsNullOrWhiteSpace(options.Email)) {
                return false;
            }
            if (options.IsActive == false) {
                return false;
            }


            List<Customer> customerList = new List<Customer>();

            Customer customer = new Customer();
            customer.VatNumber = options.VatNumber;
            options.CustomerId = randId;
            customer.Id = options.CustomerId;
            customer.IsActive = options.IsActive;
            customerList.Add(customer);


            return false;


        }
        public bool UpdateCustomer(string CustomerId, UpdateCustomerOptions options)
        {

            Customer customer = new Customer();
            if (CustomerId != null) {
                return false;
            }

            if (options == null) {
                return false;
            }

            if (string.IsNullOrWhiteSpace(options.Email)) {
                return false;
            }

            if (string.IsNullOrWhiteSpace(options.VatNumber)) {
                return false;
            }

            customer.Email = options.Email;
            customer.VatNumber = options.VatNumber;
            

            

            return true;
        }
       public ICollection<Model.Customer> SearchCustomer(SearchCustomerOptions options) {
            List<Customer> c1 = new List<Customer>();
            return c1;
        }
    }

}

    

