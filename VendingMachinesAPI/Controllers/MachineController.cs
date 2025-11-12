using Microsoft.AspNetCore.Mvc;
using VendingMachinesAPI.Services;

namespace VendingMachinesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly IService<Machine> _machineService;
        public MachineController(IService<Machine> machineService)
        {
            this._machineService = machineService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Machine>>> GetAll()
        {
            var items = await _machineService.GetAll();
            return Ok(items);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<Machine>> GetById(int id)
        {
            var item = await _machineService.GetById(id);
            if (item == null) { return NotFound(); }
            return Ok(item);
        }

        [HttpPost("post")]
        public async Task<ActionResult<Machine>> Create([FromBody] Machine item)
        {
            await _machineService.Create(item);
            return CreatedAtAction(nameof(GetById), new { id = item.IdMachine }, item);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Machine item)
        {
            if (item.IdMachine != id)
            {
                return BadRequest();
            }
            await _machineService.Update(item);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _machineService.Delete(id);
            return NoContent();
        }
    }
}
