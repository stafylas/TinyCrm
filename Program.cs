namespace TinyCrm
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



            var productService = new Services.ProductService();
            productService.AddProduct(
                new Model.Options.AddProductOptions()
                {
                    Id = "123",
                    Price = 13.33M,
                    ProductCategory = Model.ProductCategory.Cameras,
                    Name = "Camera 1"
                });
            productService.AddProduct(
                new Model.Options.AddProductOptions()
                {
                    Id = "456",
                    Price = 13.33M,
                    ProductCategory = Model.ProductCategory.Cameras,
                    Name = "camera 2"
                });
            productService.UpdateProduct("123",
                new Model.Options.UpdatedProductOptions()
                {
                    Price = 22.22M
                });

        }

    }
}