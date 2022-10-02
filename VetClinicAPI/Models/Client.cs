namespace VetClinicAPI.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public List<Pet> Pets { get; set; }
        public bool IsActive { get; set; }
    }
}
