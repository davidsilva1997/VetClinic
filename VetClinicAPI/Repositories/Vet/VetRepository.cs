using Microsoft.EntityFrameworkCore;
using VetClinicAPI.Data;

namespace VetClinicAPI.Repositories.Vet
{
    public class VetRepository : IVetRepository
    {
        private readonly VetClinicDbContext vetClinicDbContext;

        public VetRepository(VetClinicDbContext vetClinicDbContext)
        {
            this.vetClinicDbContext = vetClinicDbContext;
        }

        public async Task<IEnumerable<Models.Vet>> GetAllAsync()
        {
            return await vetClinicDbContext.Vets.ToListAsync();
        }

        public async Task<Models.Vet?> GetAsync(Guid id)
        {
            return await vetClinicDbContext.Vets.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Models.Vet> AddAsync(Models.Vet vet)
        {
            vet.Id = Guid.NewGuid();
            vet.IsActive = true;

            await vetClinicDbContext.Vets.AddAsync(vet);
            await vetClinicDbContext.SaveChangesAsync();

            return vet;
        }

        public async Task<Models.Vet?> UpdateAsync(Guid id, Models.Vet newVet)
        {
            var vet = await GetAsync(id);

            if (vet is null)
            {
                return null;
            }

            vet.FirstName = newVet.FirstName;
            vet.LastName = newVet.LastName;
            vet.Email = newVet.Email;
            vet.Birthday = newVet.Birthday;
            vet.IsActive = newVet.IsActive;

            await vetClinicDbContext.SaveChangesAsync();

            return vet;
        }

        public async Task<Models.Vet?> RemoveAsync(Guid id)
        {
            var vet = await GetAsync(id);

            if (vet is null)
            {
                return null;
            }

            vetClinicDbContext.Vets.Remove(vet);
            await vetClinicDbContext.SaveChangesAsync();

            return vet;
        }
    }
}
