using DemoAPI_List.Models;
using DemoAPI_List.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DemoAPI_List.Controllers
{
    // Controllers/ProductsController.cs
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("[action]")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(Guid id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Product>> AddProduct([FromBody] Product product)
        {
            var newProduct = await _productService.AddProduct(product);
            return Ok(new {data= newProduct });
            //return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(Guid id, [FromBody] Product product)
        {
            /*var existingProduct = await _productService.GetProductById(id);
            if (existingProduct == null)
                return NotFound();*/

            var updatedProduct = await _productService.UpdateProduct(id,product);
            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var result = await _productService.DeleteProduct(id);
            if (result.IsNullOrEmpty())
                    return NotFound();

            return Ok(new { result });
        }
    }

}
