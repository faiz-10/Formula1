using F1.API.Models.Domains;
using Microsoft.AspNetCore.Mvc;

namespace F1.API.Repositories
{
    public interface ITeamsRepository
    {
        Task<List<Team>> GetTeamsAsync();
        Task<Team?> GetTeamByIdAsync(Guid id);
        Task<Team> AddTeamAsync(Team team);
        Task<Team> UpdateTeamAsync(Guid id, Team team);
        Task<Team?> DeleteTeamAsync(Guid id);
    }
}
