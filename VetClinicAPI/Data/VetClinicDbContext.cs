using Microsoft.EntityFrameworkCore;

namespace VetClinicAPI.Data
{
    public class VetClinicDbContext : DbContext
    {
        public VetClinicDbContext(DbContextOptions<VetClinicDbContext> options) : base(options)
        {

        }

        public DbSet<Models.Vet> Vets { get; set; }
        public DbSet<Models.Client> Clients { get; set; }
        public DbSet<Models.Pet> Pets { get; set; }
    }
}
