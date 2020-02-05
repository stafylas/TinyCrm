using TinyCrm.Core.Model.Options;
using TinyCrm.Core.Model;


namespace TinyCrm.Core.Services
{
    interface IProductService
    {
        bool AddProduct(AddProductOptions options);
        bool UpdateProduct(string productId,
            UpdatedProductOptions options);
        Product GetProductById(string id);
    }
}
