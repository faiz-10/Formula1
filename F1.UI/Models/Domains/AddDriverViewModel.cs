namespace F1.UI.Models.Domains
{
    public class AddDriverViewModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int Age { get; set; }
        public Guid TeamId { get; set; }
    }
}
