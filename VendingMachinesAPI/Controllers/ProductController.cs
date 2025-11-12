using Microsoft.AspNetCore.Mvc;
using VendingMachinesAPI.Services;

namespace VendingMachinesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IService<Product> _productService;
        public ProductController(IService<Product> productService)
        {
            this._productService = productService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var items = await _productService.GetAll();
            return Ok(items);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var item = await _productService.GetById(id);
            if (item == null) { return NotFound(); }
            return Ok(item);
        }

        [HttpPost("post")]
        public async Task<ActionResult<Product>> Create([FromBody] Product item)
        {
            await _productService.Create(item);
            return CreatedAtAction(nameof(GetById), new { id = item.IdProduct }, item);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Product item)
        {
            if (item.IdProduct != id)
            {
                return BadRequest();
            }
            await _productService.Update(item);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productService.Delete(id);
            return NoContent();
        }
    }
}
