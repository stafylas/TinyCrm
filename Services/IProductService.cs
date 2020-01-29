using TinyCrm.Model.Options;
using TinyCrm.Model;

namespace TinyCrm.Services
{
    interface IProductService
    {
        bool AddProduct(AddProductOptions options);
        bool UpdateProduct(string productId,
            UpdatedProductOptions options);
        Product GetProductById(string id);
    }
}
