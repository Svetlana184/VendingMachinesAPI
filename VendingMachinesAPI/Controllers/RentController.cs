using Microsoft.AspNetCore.Mvc;
using VendingMachinesAPI.Services;

namespace VendingMachinesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IService<Rent> _rentService;
        public RentController(IService<Rent> rentService)
        {
            this._rentService = rentService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Rent>>> GetAll()
        {
            var items = await _rentService.GetAll();
            return Ok(items);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<Rent>> GetById(int id)
        {
            var item = await _rentService.GetById(id);
            if (item == null) { return NotFound(); }
            return Ok(item);
        }

        [HttpPost("post")]
        public async Task<ActionResult<Rent>> Create([FromBody] Rent item)
        {
            await _rentService.Create(item);
            return CreatedAtAction(nameof(GetById), new { id = item.IdRent }, item);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Rent item)
        {
            if (item.IdRent != id)
            {
                return BadRequest();
            }
            await _rentService.Update(item);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _rentService.Delete(id);
            return NoContent();
        }
    }
}
