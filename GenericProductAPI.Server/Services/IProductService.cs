using GenericProductAPI.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericProductAPI.Server.Services
{
    public interface IProductService
    {
        Task<ServiceResponse<Product>> GetProductAsync(Guid id);
        Task<ServiceResponse<List<Product>>> ListProductsAsync(bool active);
        Task<ServiceResponse<Product>> CreateProduct(Product product);
        Task<ServiceResponse<Product>> UpdateProductAsync(Guid productId, Product product);
    }
}
