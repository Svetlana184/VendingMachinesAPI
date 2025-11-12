using Microsoft.AspNetCore.Mvc;
using VendingMachinesAPI.Services;

namespace VendingMachinesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IService<Contract> _contractService;
        public ContractController(IService<Contract> contractService)
        {
            this._contractService = contractService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Contract>>> GetAll()
        {
            var items = await _contractService.GetAll();
            return Ok(items);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<Contract>> GetById(int id)
        {
            var item = await _contractService.GetById(id);
            if (item == null) { return NotFound(); }
            return Ok(item);
        }

        [HttpPost("post")]
        public async Task<ActionResult<Contract>> Create([FromBody] Contract item)
        {
            await _contractService.Create(item);
            return CreatedAtAction(nameof(GetById), new { id = item.IdContract }, item);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Contract item)
        {
            if (item.IdContract != id)
            {
                return BadRequest();
            }
            await _contractService.Update(item);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _contractService.Delete(id);
            return NoContent();
        }
    }
}
