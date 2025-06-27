namespace F1.API.Models.Domains
{
    public class Driver
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
