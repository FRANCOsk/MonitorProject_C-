using Microsoft.AspNetCore.Mvc;
using WebFEB.Services;

namespace WebFEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChangeController : ControllerBase
    {
        IChangeService _ichangeService;
        public ChangeController(IChangeService changeService)
            {
            _ichangeService = changeService;

        }
            [HttpGet]
            [Route("Healtcheck")]
            public async Task<IActionResult> HealtCheck()
            {
                return Ok();
        }

        [HttpGet(Name = "GetChanges")]
        public async Task<IActionResult> GetChanges()
        {
            var changes = await _ichangeService.GetAllChangesAsync();
            return Ok(changes);
        }

        [HttpGet(Name = "GetChangeById")]
        public async Task<IActionResult> GetChangeById(int id)
        {
            var change = await _ichangeService.GetChangeByIdAsync(id);
            if (change == null)
            {
                return NotFound();
            }
            return Ok(change);
        }

    }
}
