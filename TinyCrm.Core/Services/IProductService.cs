using TinyCrm.Core.Model.Options;
using TinyCrm.Core.Model;


namespace TinyCrm.Core.Services
{
 public interface IProductService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
   public bool AddProduct(AddProductOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
   public bool UpdateProduct(string productId,
        UpdatedProductOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
   public Product GetProductById(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
    public bool readFile(string path);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
    public bool searchProduct(string productid);
       
    }
}
