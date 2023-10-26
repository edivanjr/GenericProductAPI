using GenericProductAPI.Server.Services;
using GenericProductAPI.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Product>>> CreateProduct(Product product)
        {
            try
            {                
                return Ok(await _productService.CreateProduct(product));
            }
            catch (Exception e)
            {
                return BadRequest(new ServiceResponse<Product> { Data = product, Message = e.Message, Success = false});
            }
        }        

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Product>>> Edit(Guid productId, Product product)
        {
            try
            {
                if (productId != product.Id)
                    return BadRequest(new ServiceResponse<Product> { Data = product, Message = "Product unrecognizable!", Success = false });
                
                return Ok(await _productService.UpdateProductAsync(productId, product));
            }
            catch (Exception e)
            {
                return BadRequest(new ServiceResponse<Product> { Data = product, Message = e.Message, Success = false });
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return Ok();
            }
            catch
            {
                return View();
            }
        }
    }
}
