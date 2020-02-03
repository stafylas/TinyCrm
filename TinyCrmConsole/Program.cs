using System;
using TinyCrm.Core.Model;

using TinyCrm.Core.Model.Options;

namespace TinyCrmConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Log.Logger = new LoggerConfiguration()
            //    .WriteTo.Console()
            //    .WriteTo.File($@"{System.IO.Directory.GetCurrentDirectory()}\logs\{DateTime.Now:yyyy-MM-dd}\log-.txt",
            //        rollingInterval: RollingInterval.Day)
            //    .CreateLogger();
            //Log.Error("this is an error");
            //Console.ReadKey();



            var productService = new TinyCrm.Core.Services.ProductService();
            productService.AddProduct(
                new AddProductOptions()
                {
                    Id = "123",
                    Price = 13.33M,
                    ProductCategory =ProductCategory.Cameras,
                    Name = "Camera 1"
                });
            productService.AddProduct(
                new AddProductOptions()
                {
                    Id = "456",
                    Price = 13.33M,
                    ProductCategory = ProductCategory.Cameras,
                    Name = "camera 2"
                });
            productService.UpdateProduct("123",
                new UpdatedProductOptions()
                {
                    Price = 22.22M
                });

        }

    }
}
