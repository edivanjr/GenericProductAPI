using GenericProductAPI.Server.Infrastructure;
using GenericProductAPI.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GenericProductAPI.Server.Services
{
    public class ProductService : ControllerBase, IProductService
    {
        private readonly ProductContext _productContext;
        public ProductService(ProductContext productContext) 
        {
            _productContext = productContext;
        }

        public async Task<ServiceResponse<Product>> CreateProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            _ = _productContext.Products.Add(product);
            _ = await _productContext.SaveChangesAsync();
            return new ServiceResponse<Product> { Data = product };                
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(Guid id)
        {
            return new ServiceResponse<Product> { Data = await _productContext.Products.Where(x => x.Id == id).FirstOrDefaultAsync() };            
        }

        public async Task<ServiceResponse<List<Product>>> ListProductsAsync(bool active)
        {
            return new ServiceResponse<List<Product>> { Data = await _productContext.Products.Where(x => x.IsActive == active).ToListAsync() };            
        }

        public async Task<ServiceResponse<Product>> UpdateProductAsync(Guid productId, Product product)
        {
            _productContext.Entry(product).State = EntityState.Modified;
            await _productContext.SaveChangesAsync();
            return new ServiceResponse<Product> { Data = product };
        }
    }
}
