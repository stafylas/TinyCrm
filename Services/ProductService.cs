using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCrm.Model;
using TinyCrm.Model.Options;



namespace TinyCrm.Services
{
   
    public class ProductService : IProductService
    {
        private List<Product>  ProductList = new List<Product>();

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

            var product = new Product();
            product.Id = options.Id;
            product.Name = options.Name;
            product.Price = options.Price;
            product.ProductCategory = options.ProductCategory;

            ProductList.Add(product);

            return true;
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

                var product = ProductList
                    .Where(s => s.Id.Equals(id))  //pairnei ola ta stoixeia apo ti lista poy exoun id kai checkarei sth single an iparxei diplotipo
                    .SingleOrDefault();

                return product;
            }
        }
    }



