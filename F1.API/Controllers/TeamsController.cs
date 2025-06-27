using AutoMapper;
using F1.API.Models.Domains;
using F1.API.Models.DTOs;
using F1.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace F1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsRepository teamsRepository;
        private readonly IMapper mapper;

        public TeamsController(ITeamsRepository teamsRepository, IMapper mapper)
        {
            this.teamsRepository = teamsRepository;
            this.mapper = mapper;
        }

        // GET: api/teams
        [HttpGet]
        public async Task<IActionResult> GetTeamsAsync()
        {

            var teamsDomainModel = await teamsRepository.GetTeamsAsync();

            // Mapping domain model to DTO can be done here if needed
            var teamsDto = mapper.Map<List<TeamDto>>(teamsDomainModel);

            return Ok(teamsDto);
        }

        // GET: api/teams/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetTeamByIdAsync([FromRoute] Guid id)
        {
            var teamDomainModel = await teamsRepository.GetTeamByIdAsync(id);

            if (teamDomainModel is null)
            {
                return NotFound();
            }

            // Mapping domain model to DTO can be done here if needed
            var teamDto = mapper.Map<TeamDto>(teamDomainModel);

            return Ok(teamDto);
        }

        // POST: api/teams
        [HttpPost]
        public async Task<IActionResult> AddTeamAsync([FromBody] AddTeamDto addTeamDto)
        {

            // Mapping DTO to domain model

            var teamDomainModel = mapper.Map<Team>(addTeamDto);

            await teamsRepository.AddTeamAsync(teamDomainModel);

            return Ok();
        }

        // PUT: api/teams/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateTeamAsync([FromRoute] Guid id, [FromBody] UpdateTeamDto updateTeamDto)
        {
            // Mapping DTO to domain model

            var team = mapper.Map<Team>(updateTeamDto);

            var updatedTeam = await teamsRepository.UpdateTeamAsync(id, team);

            // mapping updated domain model to DTO can be done here if needed

            var updatedTeamDto = mapper.Map<TeamDto>(updatedTeam);

            return Ok(updatedTeamDto);
        }

        // DELETE: api/teams/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> RemoveTeam([FromRoute] Guid id)
        {
            var deletedTeam = await teamsRepository.DeleteTeamAsync(id);
            if(deletedTeam != null)
            {
                return Ok(deletedTeam);
            }

            return NotFound();
        }
    }
}
