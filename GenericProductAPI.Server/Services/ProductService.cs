using AutoMapper;
using GenericProductAPI.Server.Infrastructure;
using GenericProductAPI.Shared;
using GenericProductAPI.Shared.DTOs;
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
        private readonly IMapper _mapper;
        public ProductService(ProductContext productContext, IMapper mapper) 
        {
            _productContext = productContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CreateProductDTO>> CreateProduct(CreateProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO); 
            _productContext.Products.Add(product);
            await _productContext.SaveChangesAsync();

            var responseDTO = _mapper.Map<CreateProductDTO>(product); 

            return new ServiceResponse<CreateProductDTO> { Data = responseDTO };              
        }

        public async Task<ServiceResponse<ProductDTO>> DeleteProductAsync(long productId, ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _productContext.Entry(product).State = EntityState.Modified;
            await _productContext.SaveChangesAsync();

            var responseDTO = _mapper.Map<ProductDTO>(product);
            return new ServiceResponse<ProductDTO> { Data = responseDTO };
        }

        public async Task<ServiceResponse<ProductDTO>> GetProductAsync(long id)
        {
            var product = await _productContext.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (product == null)
            {
                return new ServiceResponse<ProductDTO> { Success = false, Message = "Product not found." };
            }

            var productDTO = _mapper.Map<ProductDTO>(product);

            return new ServiceResponse<ProductDTO> { Data = productDTO };
        }

        public async Task<ServiceResponse<List<ProductDTO>>> ListProductsAsync(bool active)
        {
            var products = await _productContext.Products.Where(x => x.IsActive == active).ToListAsync();

            var productDTOs = _mapper.Map<List<ProductDTO>>(products);

            return new ServiceResponse<List<ProductDTO>> { Data = productDTOs };
        }

        public async Task<ServiceResponse<ProductDTO>> UpdateProductAsync(long productId, ProductDTO productDTO)
        {
            var product = await _productContext.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();

            if (product == null)
            {
                return new ServiceResponse<ProductDTO> { Success = false, Message = "Product not found." };
            }

            _mapper.Map(productDTO, product); 

            _productContext.Entry(product).State = EntityState.Modified;
            await _productContext.SaveChangesAsync();

            return new ServiceResponse<ProductDTO> { Data = _mapper.Map<ProductDTO>(product) };
        }
    }
}
