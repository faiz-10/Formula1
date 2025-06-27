using F1.API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace F1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        // GET: api/drivers
        [HttpGet]
        public async Task<IActionResult> GetDriversAsyn()
        {
            return Ok("");
        }

        // GET: api/drivers/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetDriverById([FromRoute] Guid id)
        {
            return Ok("");
        }

        // POST: api/drivers
        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] AddDriverDto addDriverDto)
        {
            return Ok("");
        }

        // PUT: api/drivers/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateDriver([FromRoute] Guid id, [FromBody] UpdateDriverDto updateDriverDto)
        {
            return Ok("");
        }

        // DELETE: api/drivers/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeletePlayer([FromRoute] Guid id)
        {
            return Ok("");
        }
    }
}
