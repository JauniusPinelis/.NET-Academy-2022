using FirstWebApi.Entities;

namespace FirstWebApi.Repositories
{
    public interface IPersonRepository
    {
        Task AddAsync(PersonEntity entity);

        Task<PersonEntity> GetById(int id);

        Task<List<PersonEntity>> GetAllAsync();

        Task RemoveAsync(PersonEntity person);

        Task UpdateAsync(PersonEntity person);
    }
}
