using GenericProductAPI.Server.Services;
using GenericProductAPI.Shared;
using GenericProductAPI.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericProductAPI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("CreateMultipleProducts")]
        public async Task<ActionResult<ServiceResponse<List<CreateProductDTO>>>> CreateMultipleProducts(CreateMultipleProductsDTO productsDTO)
        {
            try
            {
                var createdProducts = new List<CreateProductDTO>();

                foreach (var productDTO in productsDTO.Products)
                {
                    var createdProduct = await _productService.CreateProduct(productDTO);
                    createdProducts.Add(createdProduct.Data);
                }

                return Ok(new ServiceResponse<List<CreateProductDTO>> { Data = createdProducts, Message = "Products created successfully", Success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new ServiceResponse<List<CreateProductDTO>> { Data = null, Message = e.Message, Success = false });
            }
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult<ServiceResponse<CreateProductDTO>>> CreateProduct(CreateProductDTO productDTO)
        {
            try
            {                
                return Ok(await _productService.CreateProduct(productDTO));
            }
            catch (Exception e)
            {
                return BadRequest(new ServiceResponse<CreateProductDTO> { Data = productDTO, Message = e.Message, Success = false});
            }
        }

        [HttpGet("ListProducts")]
        public async Task<ActionResult<ServiceResponse<List<ProductDTO>>>> ListProducts(bool isActive)
        {
            try
            {
                return Ok(await _productService.ListProductsAsync(isActive));
            }
            catch (Exception e)
            {
                return BadRequest(new ServiceResponse<ProductDTO> {  Message = e.Message, Success = false });
            }
        }

        [HttpPut("EditProduct")]
        public async Task<ActionResult<ServiceResponse<ProductDTO>>> Edit(long productId, ProductDTO productDTO)
        {
            try
            {
                if (productId != productDTO.Id)
                    return BadRequest(new ServiceResponse<ProductDTO> { Data = productDTO, Message = "Product unrecognizable!", Success = false });
                
                return Ok(await _productService.UpdateProductAsync(productId, productDTO));
            }
            catch (Exception e)
            {
                return BadRequest(new ServiceResponse<ProductDTO> { Data = productDTO, Message = e.Message, Success = false });
            }
        }

        [HttpDelete("DeleteProduct")]
        public async Task<ActionResult<ServiceResponse<ProductDTO>>> Delete(long productId, ProductDTO productDTO)
        { 
            try
            {

                if (productId != productDTO.Id)
                    return BadRequest(new ServiceResponse<ProductDTO> { Data = productDTO, Message = "Product unrecognizable!", Success = false });
                productDTO.IsActive = false;

                return Ok(await _productService.DeleteProductAsync(productId, productDTO));
            }
            catch (Exception e) 
            {
                return BadRequest(new ServiceResponse<ProductDTO> { Data = productDTO, Message = e.Message, Success = false });
            }
        }
    }
}
