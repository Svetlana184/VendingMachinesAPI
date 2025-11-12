using Microsoft.AspNetCore.Mvc;
using VendingMachinesAPI.Services;

namespace VendingMachinesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService<User> _userService;
        public UserController(IService<User> userService)
        {
            this._userService = userService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var items = await _userService.GetAll();
            return Ok(items);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var item = await _userService.GetById(id);
            if (item == null) { return NotFound(); }
            return Ok(item);
        }

        [HttpPost("post")]
        public async Task<ActionResult<User>> Create([FromBody] User item)
        {
            await _userService.Create(item);
            return CreatedAtAction(nameof(GetById), new { id = item.IdUser }, item);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] User item)
        {
            if (item.IdUser != id)
            {
                return BadRequest();
            }
            await _userService.Update(item);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return NoContent();
        }
    }
}
