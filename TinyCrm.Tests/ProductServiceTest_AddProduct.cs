using System;
using Xunit;
using TinyCrm.Core.Data;
using TinyCrm.Core.Services;

namespace TinyCrm.Tests
{
    public partial class ProductServiceTests
    {
        
        [Fact]
        public void AddProduct_Success()
        {

            var options = new Core.Model.Options.AddProductOptions() {
                Id = "45667",
                Name = "Laptop",
                Price = 450.00M,
                ProductCategory = Core.Model.ProductCategory.Laptops
           };
           
            var addproduct = psvc_.AddProduct(options);
            Assert.True(addproduct);// checkarei na einai true, epeidi i add product einai tipou bool

            var p= psvc_.GetProductById(options.Id);
            Assert.NotNull(p);  //prepei na checkarei na dei an to product poy epistrefei einai null
            Assert.Equal(options.Name,p.Name);
            Assert.Equal(options.Price, p.Price);
            Assert.Equal(options.ProductCategory, p.ProductCategory);
            
        }

        //public void AddProduct_Failure_Invalid_Category() 
        //{

        //    var options = new Core.Model.Options.AddProductOptions() {
        //        Id = "9903",
        //        Name = "LG",
        //        Price = 450.00M

        //    };
        //    var result = psvc_.AddProduct(options);
        //    Assert.False(result);
           
        //}
    }
}
