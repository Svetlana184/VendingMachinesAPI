using Microsoft.AspNetCore.Mvc;
using VendingMachinesAPI.Services;

namespace VendingMachinesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInMachineController : ControllerBase
    {
        private readonly IService<ProductInMachine> _productInMachineService;
        public ProductInMachineController(IService<ProductInMachine> productInMachineService)
        {
            this._productInMachineService = productInMachineService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<ProductInMachine>>> GetAll()
        {
            var items = await _productInMachineService.GetAll();
            return Ok(items);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<ProductInMachine>> GetById(int id)
        {
            var item = await _productInMachineService.GetById(id);
            if (item == null) { return NotFound(); }
            return Ok(item);
        }

        [HttpPost("post")]
        public async Task<ActionResult<ProductInMachine>> Create([FromBody] ProductInMachine item)
        {
            await _productInMachineService.Create(item);
            return CreatedAtAction(nameof(GetById), new { id = item.IdProductInMachine }, item);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ProductInMachine item)
        {
            if (item.IdProductInMachine != id)
            {
                return BadRequest();
            }
            await _productInMachineService.Update(item);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productInMachineService.Delete(id);
            return NoContent();
        }
    }
}
