namespace F1.API.Models.DTOs
{
    public class UpdateDriverDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int Age { get; set; }
        public Guid TeamId { get; set; }
    }
}
