﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;
using TinyCrm.Core.Services;
using Xunit;

namespace TinyCrm.Tests
{
    public class OrderServiceTests : IClassFixture<TinyCrmFixture>
    {
        private readonly TinyCrmDbContext context_;
        private readonly ICustomerService customers_;
        private readonly IOrderService orders_;
        private readonly IProductService products_;

        public OrderServiceTests(TinyCrmFixture fixture)
        {
            context_ = fixture.DbContext;
            customers_ = fixture.Container.Resolve<ICustomerService>();
            orders_ = fixture.Container.Resolve<IOrderService>();
            products_ = fixture.Container.Resolve<IProductService>();
        }

        [Fact]
        public async Task CreateOrder_Success()

        {

            var p1 = new AddProductOptions()
            {
                Id = CodeGenerator.CreateRandom(),
                Name = "kostas",
                Price = 230.00M,
                ProductCategory = Core.Model.ProductCategory.Cameras
            };

            var p2 = new AddProductOptions()
            {
                Id = CodeGenerator.CreateRandom(),
                Name = "kossadtas",
                Price = 1230.00M,
                ProductCategory = Core.Model.ProductCategory.Cameras
            };
            Assert.True(products_.AddProduct(p1));
            Assert.True(products_.AddProduct(p2));

            var result = customers_
                .CreateCustomer(new CreateCustomerOptions()
                {
                    Email = "customer@gmail.com",
                    VatNumber = CodeGenerator.CreateRandom()
                });
            Assert.NotNull(result);

            var products = new List<string> { p1.Id, p2.Id };
            var order = orders_.CreateOrder(
                result.Id, products);

            Assert.NotNull(order);

            var dbOrder = context_.Set<Order>().Find(order.Id);
            Assert.NotNull(dbOrder);

            Assert.True(result.Id == dbOrder.Customer.Id);

            foreach (var p in products) {
                Assert.Contains(dbOrder.Products
                    .Select(prod => prod.ProductId), prod => prod.Equals(p));
            }
        }

    }  
    }

