namespace VetClinicAPI.Models
{
    public class Vet
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsActive { get; set; }
    }
}
