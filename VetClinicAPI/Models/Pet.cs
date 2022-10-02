namespace VetClinicAPI.Models
{
    public class Pet
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Color { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public Guid ClientId { get; set; }
        public bool IsActive { get; set; }
    }
}
