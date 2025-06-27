using F1.API.Models.Domains;

namespace F1.API.Models.DTOs
{
    public class DriverDto
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int Age { get; set; }
        public Guid TeamId { get; set; }

        // Navigation property to the Team entity
        public Team Team { get; set; }
    }
}
