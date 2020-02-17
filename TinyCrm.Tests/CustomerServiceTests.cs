﻿using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;
using TinyCrm.Core.Services;

using System.Linq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TinyCrm.Core;

namespace TinyCrm.Tests
{
    public partial class CustomerServiceTests : IClassFixture<TinyCrmFixture>
    {
        private readonly ICustomerService csvc_;
        private readonly TinyCrmDbContext context;

        public CustomerServiceTests(TinyCrmFixture fixture)
        {
            context = fixture.DbContext;
            csvc_ = new CustomerService(context);
        }
        [Fact]
        public async Task CreateCustomer_Success()
        {
            var options = new CreateCustomerOptions()
            {
                VatNumber = $"123{DateTime.UtcNow.Millisecond:D6}",
                Email = "dsadas",
                FirstName = "Alex",
                LastName = "ath",
                Phone = "344234",
               
            };

            var result =await csvc_.CreateCustomerAsync(options);

            Assert.NotNull(result);

            var customer =csvc_.SearchCustomers(
                new SearchCustomerOptions()
                {
                    VatNumber = options.VatNumber
                }).SingleOrDefault();

            Assert.NotNull(customer);
            Assert.Equal(options.Email, customer.Email);
            Assert.Equal(options.Phone, customer.Phone);
            Assert.True(customer.IsActive);

       
        }
        [Fact]

        public async Task CreateCustomer_Fail_VatNumber()
        {
            var options = new CreateCustomerOptions()
            {               
                Email = "dsadas",
                FirstName = "Alex",
                LastName = "ath",
                Phone = "344234",
            };
            var result = await csvc_.CreateCustomerAsync(options);

            Assert.Equal(StatusCode.BadRequest, result.ErrorCode);
        }


        public void Dispose()
        {
            context.Dispose();
        }
    }
}
