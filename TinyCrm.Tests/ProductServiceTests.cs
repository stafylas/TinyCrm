using System;
using Xunit;

using TinyCrm.Core.Data;
using Autofac;
using TinyCrm.Core.Services;
using System.Threading.Tasks;
using TinyCrm.Core;

namespace TinyCrm.Tests
{
    public partial class ProductServiceTests : IClassFixture<TinyCrmFixture>
    {
        private readonly Core.Services.IProductService psvc_;

        public ProductServiceTests(TinyCrmFixture fixture)
        {
            psvc_ = fixture.Container.Resolve<IProductService>();

        }

        [Fact]
        public async Task GetProductById_Success()
        {
            var product =await psvc_.GetProductByIdAsync("1112955");

            Assert.Equal(StatusCode.Ok, product.ErrorCode);
        }

        [Fact]
        public void GetProductById_Failure_Null_ProductId()
        {
            var product = psvc_.GetProductById("     ");
            Assert.Null(product);

            product = psvc_.GetProductById(null);
            Assert.Null(product);
        }
    }
}
