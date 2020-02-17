using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TinyCrm.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly Data.TinyCrmDbContext context_;

        public CustomerService(Data.TinyCrmDbContext context)
        {
            context_ = context ??
                throw new ArgumentException(nameof(context));
        }

        public async Task <ApiResult<Customer>> CreateCustomerAsync(CreateCustomerOptions options)
        {
            if (options == null) {
                return new ApiResult<Customer>(StatusCode.BadRequest, "null options");
            }

            if (string.IsNullOrWhiteSpace(options.VatNumber) ||
              string.IsNullOrWhiteSpace(options.Email)) {
                return new ApiResult<Customer>(StatusCode.BadRequest, "mail or vat is empty");
            }

            if (options.VatNumber.Length > 9) {
                return new ApiResult<Customer>(StatusCode.BadRequest, "invalid vat");
            }

            var exists =await SearchCustomers(
                new SearchCustomerOptions()
                {
                    VatNumber = options.VatNumber
                }).AnyAsync();

            if (exists) {
                return new ApiResult<Customer>(StatusCode.Conflict,
                    $"customer with {options.VatNumber} exists");
            }

            var customer = new Customer()
            {
                VatNumber = options.VatNumber,
                Firstname = options.FirstName,
                Lastname = options.LastName,
                Email = options.Email,
                Phone = options.Phone,
                IsActive = true
                
            };

          await  context_.AddAsync(customer);
            try {
              await  context_.SaveChangesAsync();
            }catch (Exception ex) {
                return new ApiResult<Customer>(StatusCode.InternalServerError, "could not save customer");
            }

            return new ApiResult<Customer>()
            {
                Data = customer
            };
        }

        public  IQueryable<Customer> SearchCustomers(
            SearchCustomerOptions options)
        {
            if (options == null) {
                return null;
            }

            var query = context_
                .Set<Customer>()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(options.VatNumber)) {
                query = query.Where(c =>
                    c.VatNumber == options.VatNumber);
            }

            if (!string.IsNullOrWhiteSpace(options.Email)) {
                query = query.Where(c =>
                    c.Email == options.Email);
            }

            if (options.CustomerId != null) {
                query = query.Where(c =>
                    c.Id == options.CustomerId.Value);
            }

            return query.Take(500);
        }

        public bool UpdateCustomer(int id, UpdateCustomerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
