using AutoMapper;
using F1.API.Models.Domains;
using F1.API.Models.DTOs;
using F1.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace F1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IDriversRepository repository;
        private readonly IMapper mapper;

        public DriversController(IDriversRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        // GET: api/drivers
        [HttpGet]
        public async Task<IActionResult> GetDriversAsyn()
        {
            var drivers = await repository.GetDriversAsync();

            var driverDto = mapper.Map<List<DriverDto>>(drivers);

            return Ok(driverDto);
        }

        // GET: api/drivers/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetDriverById([FromRoute] Guid id)
        {
            var driver = await repository.GetDriverByIdAsync(id);
            if (driver == null) { return NotFound(); }
            var driverDto = mapper.Map<DriverDto>(driver);
            return Ok(driverDto);
        }

        // POST: api/drivers
        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] AddDriverDto addDriverDto)
        {
            // mapping dto to model
            var driverDomainModel = mapper.Map<Driver>(addDriverDto);

            var driver = await repository.AddDriverAsync(driverDomainModel);

            // mapping model to dto
            var driverDto = mapper.Map<DriverDto>(driver);
            return Ok(driverDto);
        }

        // PUT: api/drivers/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateDriver([FromRoute] Guid id, [FromBody] UpdateDriverDto updateDriverDto)
        {
            var driverDomainModel = mapper.Map<Driver>(updateDriverDto);
            var updatedDriver = await repository.UpdateDriverAsync(id, driverDomainModel);

            if(updatedDriver is null)
            {
                return NotFound();
            }

            var driverDto = mapper.Map<DriverDto>(updatedDriver);
            
            return Ok(driverDto);
        }

        // DELETE: api/drivers/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeletePlayer([FromRoute] Guid id)
        {
            var driver = await repository.DeleteDriverAsync(id);
            if(driver is null) {  return NotFound(); }
            return Ok(driver);
        }
    }
}
