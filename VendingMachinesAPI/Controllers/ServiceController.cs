using Microsoft.AspNetCore.Mvc;
using VendingMachinesAPI.Services;

namespace VendingMachinesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IService<Service> _serviceService;
        public ServiceController(IService<Service> serviceService)
        {
            this._serviceService = serviceService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Service>>> GetAll()
        {
            var items = await _serviceService.GetAll();
            return Ok(items);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<Service>> GetById(int id)
        {
            var item = await _serviceService.GetById(id);
            if (item == null) { return NotFound(); }
            return Ok(item);
        }

        [HttpPost("post")]
        public async Task<ActionResult<Service>> Create([FromBody] Service item)
        {
            await _serviceService.Create(item);
            return CreatedAtAction(nameof(GetById), new { id = item.IdService }, item);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Service item)
        {
            if (item.IdService != id)
            {
                return BadRequest();
            }
            await _serviceService.Update(item);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _serviceService.Delete(id);
            return NoContent();
        }
    }
}
