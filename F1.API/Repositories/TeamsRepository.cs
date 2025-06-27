using F1.API.Data;
using F1.API.Models.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace F1.API.Repositories
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly F1DbContext dbContext;

        public TeamsRepository(F1DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        async Task<Team> ITeamsRepository.AddTeamAsync(Team team)
        {
            await dbContext.AddAsync(team);
            await dbContext.SaveChangesAsync();

            return team;
        }

        async Task<Team?> ITeamsRepository.DeleteTeamAsync(Guid id)
        {
            var team = await dbContext.Teams.FirstOrDefaultAsync(t => t.Id == id);
            if(team is not null)
            {
                dbContext.Teams.Remove(team);
                await dbContext.SaveChangesAsync();
            }

            return team;
        }

        async Task<Team?> ITeamsRepository.GetTeamByIdAsync(Guid id)
        {
            var team = await dbContext.Teams.FirstOrDefaultAsync(t => t.Id == id);
            return team;
        }

        async Task<List<Team>> ITeamsRepository.GetTeamsAsync()
        {
            var teams = await dbContext.Teams.ToListAsync();
            return teams;
        }

        async Task<Team> ITeamsRepository.UpdateTeamAsync(Guid id, Team team)
        {
            var existingTeam = await dbContext.Teams.FirstOrDefaultAsync(t => t.Id == id);
            if(existingTeam is not null)
            {
                existingTeam.Name = team.Name;
                await dbContext.SaveChangesAsync();
            }
            return team;
        }
    }
}
