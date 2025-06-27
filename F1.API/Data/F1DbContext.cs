using F1.API.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace F1.API.Data
{
    public class F1DbContext : DbContext
    {
        public F1DbContext(DbContextOptions options): base(options) { }


        public DbSet<Team> Teams { get; set; }
        public DbSet<Driver> Drivers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var teamsData = new List<Team>
            {
                new Team { Id = Guid.Parse("ac2614dc-d31a-4c8e-8942-8ddf3e935db7"), Name = "Ferrari"},
                new Team { Id = Guid.Parse("52f1f598-ac3d-4935-bc12-4992cfda1a83"), Name = "Mercedes"},
                new Team { Id = Guid.Parse("b3525116-0539-4e29-820c-acb2e1e04975"), Name = "Red Bull Racing"},
                new Team { Id = Guid.Parse("f04b5bb2-2340-45d6-8b4e-8ee91a08fe2b"), Name = "McLaren"},
                new Team { Id = Guid.Parse("e3ad6c87-c25a-4c23-92e5-dab0c4fd25d4"), Name = "Alpine"},
                new Team { Id = Guid.Parse("949b9cbf-6044-4708-8263-3c002d43a0a5"), Name = "Aston Martin"},
            };

            modelBuilder.Entity<Team>().HasData(teamsData);

            base.OnModelCreating(modelBuilder);
        }
    }
}
