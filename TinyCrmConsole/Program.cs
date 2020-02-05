using System;
using TinyCrm.Core.Model;
using TinyCrm.Core.Data;


using TinyCrm.Core.Model.Options;
using System.Linq;
using TinyCrm.Core.Services;

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

            var context = new TinyCrmDbContext() ;
           // Console.WriteLine(context.Database.CanConnect());
           context.Database.EnsureCreated();

            //var p = new Product()
            //{
            //    Id = "3455",
            //    ProductCategory = ProductCategory.Computers,
            //    Price = 99.99M,
            //    Discount = 0
            //};
            //var c1 = new Customer()
            //{
            //    Email = "saddfg@gmail.com",
            //    Firstname = "kostas",
            //    Lastname = "papadopoulos",
            //    Phone = "698965663 ",
            //    VatNumber = " RDJ234",
            //    Created = DateTimeOffset.Now
            //};


            //context.Add(c1);
            //context.SaveChanges();          

            //context.Remove(c1);
            //context.SaveChanges();


           //var y= context.Set<Customer>() //anazitisi
           //  .Where(o => o.Id == 4)
           //  .ToList();             //vazoume .tolist giati to antikeimeno pou epstrefei den einai kanoniko antikeimno
           // context.Remove(y[0]);
           // context.SaveChanges();

            //var q = context.Set<Customer>()
            //     .Where(o => o.Id == 2);
            //var customer = q.SingleOrDefault();



            var productService = new ProductService(context);
            productService.AddProduct(
                new AddProductOptions()
                {
                    Id = "12345",
                    Price = 153.33M,
                    ProductCategory =ProductCategory.Cameras,
                    Name = "Camera 1"
                });
            productService.AddProduct(
                new AddProductOptions()
                {
                    Id = "4556",
                    Price = 613.33M,
                    ProductCategory = ProductCategory.Cameras,
                    Name = "camera 2"
                });
            productService.UpdateProduct("123",
                new UpdatedProductOptions()
                {
                    Price = 22.22M
                });
           Console.WriteLine(productService.GetProductById("12345"));

        }

    }
}
