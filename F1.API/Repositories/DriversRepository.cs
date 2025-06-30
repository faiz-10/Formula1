using F1.API.Data;
using F1.API.Models.Domains;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace F1.API.Repositories
{
    public class DriversRepository : IDriversRepository
    {
        private readonly F1DbContext dbContext;

        public DriversRepository(F1DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Driver> AddDriverAsync(Driver driver)
        {
            await dbContext.Drivers.AddAsync(driver);
            await dbContext.SaveChangesAsync();
            return driver;
        }

        public async Task<Driver?> DeleteDriverAsync(Guid id)
        {
            var existingDriver = await dbContext.Drivers.FirstOrDefaultAsync(d => d.Id == id);
            if (existingDriver != null) 
            {
                dbContext.Drivers.Remove(existingDriver);
                await dbContext.SaveChangesAsync();
            }
            return existingDriver;
        }

        public async Task<Driver?> GetDriverByIdAsync(Guid id)
        {
            var driver = await dbContext.Drivers.FirstOrDefaultAsync(d => d.Id == id);
            return driver;
        }

        public async Task<List<Driver>> GetDriversAsync()
        {
            var drivers = await dbContext.Drivers.Include(d => d.Team).ToListAsync();
            return drivers;
        }

        public async Task<Driver?> UpdateDriverAsync(Guid id, Driver driver)
        {
            var existingDriver =  await dbContext.Drivers.FirstOrDefaultAsync(d => d.Id == id);
            if (existingDriver != null) 
            {
                existingDriver.Age = driver.Age;
                existingDriver.FirstName = driver.FirstName;
                existingDriver.LastName = driver.LastName;
                existingDriver.TeamId = driver.TeamId;
            }
            await dbContext.SaveChangesAsync();
            return existingDriver;
        }
    }
}
