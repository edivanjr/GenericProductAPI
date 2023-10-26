using GenericProductAPI.Shared;
using GenericProductAPI.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericProductAPI.Server.Services
{
    public interface IProductService
    {
        Task<ServiceResponse<ProductDTO>> GetProductAsync(long id);
        Task<ServiceResponse<List<ProductDTO>>> ListProductsAsync(bool active);
        Task<ServiceResponse<CreateProductDTO>> CreateProduct(CreateProductDTO productDTO);
        Task<ServiceResponse<ProductDTO>> UpdateProductAsync(long productId, ProductDTO productDTO);
        Task<ServiceResponse<ProductDTO>> DeleteProductAsync(long productId, ProductDTO productDTO);
    }
}
