using F1.API.Models.Domains;

namespace F1.API.Repositories
{
    public interface IDriversRepository
    {
        Task<List<Driver>> GetDriversAsync();
        Task<Driver?> GetDriverByIdAsync(Guid id);
        Task<Driver> AddDriverAsync(Driver driver);
        Task<Driver?> UpdateDriverAsync(Guid id, Driver driver);
        Task<Driver?> DeleteDriverAsync(Guid id);
    }
}
