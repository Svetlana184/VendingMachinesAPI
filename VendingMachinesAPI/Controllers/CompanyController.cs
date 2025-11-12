using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using VendingMachinesAPI.Services;

namespace VendingMachinesAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IService<Company> _companyService;
        public CompanyController(IService<Company> companyService)
        {
            this._companyService = companyService;
        }
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Company>>> GetAllCalendars()
        {
            var evs = await _companyService.GetAll();
            return Ok(evs);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<IEnumerable<Company>>> GetByIdCalendars(int id)
        {
            var ev = await _companyService.GetById(id);
            if (ev == null) { return NotFound(); }
            return Ok(ev);
        }
        [HttpPost("post")]
        public async Task<ActionResult<IEnumerable<Company>>> CreateCalendar([FromBody] Company c)
        {
            await _companyService.Create(c);
            return CreatedAtAction(nameof(GetByIdCalendars), new { id = c.IdCompany }, c);
        }
        [HttpPut("update/{id}")]
        public async Task<ActionResult<IEnumerable<Company>>> UpdateCalendar(int id, [FromBody] Company ev)
        {
            if (ev.IdCompany != id)
            {
                return BadRequest();
            }
            await _companyService.Update(ev);
            return NoContent();
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteCalendar(int id)
        {
            await _companyService.Delete(id);
            return NoContent();
        }
    }
}
