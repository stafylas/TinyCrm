using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;
using TinyCrm.Core.Data;



namespace TinyCrm.Core.Services
{
   
    public class ProductService : IProductService
    {
        private List<Product>  ProductList = new List<Product>();

        private readonly TinyCrmDbContext context;

        public ProductService(TinyCrmDbContext ctx)  //na tin perasw pantoy
        {
            context = ctx??
                throw new ArgumentNullException(nameof(ctx));
        }
         

        
        public bool AddProduct(AddProductOptions options)
        {
            if (options == null) {
                return false;
            }

            if (string.IsNullOrWhiteSpace(options.Id)) {
                return false;
            }

            var product = GetProductById(options.Id);

            if (product != null) {
                return false;
            }

            if (string.IsNullOrWhiteSpace(options.Name)) {
                return false;
            }

            if (options.Price <= 0) {
                return false;
            }
            
            if(options.ProductCategory == 
                ProductCategory.Invalid) {
                return false;
            }

            var newproduct = new Product();
            newproduct.Id = options.Id;
            newproduct.Name = options.Name;
            newproduct.Price = options.Price;
            newproduct.ProductCategory = options.ProductCategory;

            context.Add(newproduct);
            var success = false;
            try {
                success=context.SaveChanges()>0;
            }catch(Exception) { }
            return success;
        }


        public bool UpdateProduct(string productId,UpdatedProductOptions options) 
        {
            var product = GetProductById(productId);

            if (product != null) {
                return false;
            }

            if (options == null) {
                return false;
            }

            if (string.IsNullOrWhiteSpace(options.Name)) {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(options.Description)) {
                product.Description = options.Description;
            }

            if (options.Price !=null && options.Price <= 0) {
                return false;
            }

            if (options.Price != null) {
                if (options.Price <= 0) {
                    return false;
                } else {
                    product.Price = options.Price.Value;
                }
            }

            if (options.ProductCategory != null && options.ProductCategory ==
                ProductCategory.Invalid) {
                return false;
            }

            if (options.Discount != null && options.Discount < 0) {
                return false;
            }

            return true;
        }

        public Product GetProductById(string id)
        {

            if (string.IsNullOrWhiteSpace(id)) {
                return null;
            }
            var search = searchProduct(id);
            var product = context.Set<Product>()
                .Where(b => b.Id.Equals(search)); 
                
                
            return product.SingleOrDefault();
            
        }
        public bool readFile(string path)
        {
            string line;

            System.IO.StreamReader file =
                new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null) {
                var words = line.Split(';');
                var p = new Product();
                p.Id = words[0];
                p.Name = words[1];
                p.Price = RandomPrice();
                p.ProductCategory =(ProductCategory) RandomCategory();

                context.Add(p);
                context.SaveChanges();
            }
            return true;
        }
        public static decimal RandomPrice()
        {
            var num = (new Random().NextDouble() * (new Random()).Next(1000)).ToString("0.00");
            var number = System.Convert.ToDecimal(num);
            return number;
        }
        public static decimal RandomCategory()
        {
            var num=new Random().Next(5)+1;           
            return num;
        }
      public  bool searchProduct(string productid) 
        {

            var searchproduct = context.Set<Product>()
                .Where(s => s.Id == productid)  
                .SingleOrDefault();

            return true;
        }
    }
    }


