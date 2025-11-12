using Microsoft.AspNetCore.Mvc;
using VendingMachinesAPI.Services;

namespace VendingMachinesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly IService<Sale> _saleService;
        public SaleController(IService<Sale> saleService)
        {
            this._saleService = saleService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetAll()
        {
            var items = await _saleService.GetAll();
            return Ok(items);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<Sale>> GetById(int id)
        {
            var item = await _saleService.GetById(id);
            if (item == null) { return NotFound(); }
            return Ok(item);
        }

        [HttpPost("post")]
        public async Task<ActionResult<Sale>> Create([FromBody] Sale item)
        {
            await _saleService.Create(item);
            return CreatedAtAction(nameof(GetById), new { id = item.IdSale }, item);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Sale item)
        {
            if (item.IdSale != id)
            {
                return BadRequest();
            }
            await _saleService.Update(item);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _saleService.Delete(id);
            return NoContent();
        }
    }
}
