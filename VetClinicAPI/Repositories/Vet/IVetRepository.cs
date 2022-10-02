namespace VetClinicAPI.Repositories.Vet
{
    public interface IVetRepository
    {
        Task<IEnumerable<Models.Vet>> GetAllAsync();
        Task<Models.Vet?> GetAsync(Guid id);
        Task<Models.Vet> AddAsync(Models.Vet vet);
        Task<Models.Vet?> UpdateAsync(Guid id, Models.Vet vet);
        Task<Models.Vet?> RemoveAsync(Guid id);
    }
}
