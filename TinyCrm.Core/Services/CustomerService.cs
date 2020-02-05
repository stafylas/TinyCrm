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
        private readonly TinyCrmDbContext context;

        public CustomerService(TinyCrmDbContext ctx)  //na tin perasw pantoy
        {
            context = ctx ??
                throw new ArgumentNullException(nameof(ctx));
        }
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


            var customer = new Customer();
            customer.VatNumber = options.VatNumber;
            options.CustomerId = randId;
            customer.Id = options.CustomerId;
            customer.IsActive = options.IsActive;
           
            context.Add(customer);
            var success = false;
            try {
                success = context.SaveChanges() > 0;
            } catch (Exception) { }
            return success;

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
            if (options != null) {
                Console.WriteLine(" selecte option");
                Console.WriteLine("1: search by vatnumber");
                Console.WriteLine("2: search by email");
                Console.WriteLine("3: search by ");
                Console.WriteLine("4: search by email");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1) {
                    var searchcustomer = context.Set<Customer>()
                        .Where(s => s.VatNumber == options.VatNumber)
                        .ToList();
                    return searchcustomer;
                } else if (choice == 2) {
                    var searchcustomer = context.Set<Customer>()
                  .Where(s => s.Email == options.Email)
                  .ToList();
                    return searchcustomer;
                } else if (choice == 3) {
                    var searchcustomer = context.Set<Customer>()
                  .Where(s => s.Created == options.CreatedFrom)
                  .ToList();
                    return searchcustomer;
                } else if (choice == 4) {
                    var searchcustomer = context.Set<Customer>()
                  .Where(s => s.Created == options.CreatedFrom)
                  .ToList();
                    return searchcustomer;
                }
            }
            return null;       
        }
    }

}

    

