using FirstWebApi.Entities;
using FirstWebApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstWebApi.UnitTests.Mocks
{
    public class TestPersonRepository : IPersonRepository
    {
        public Task AddAsync(PersonEntity entity)
        {
            return Task.CompletedTask;
        }

        public Task<List<PersonEntity>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<PersonEntity> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAsync(PersonEntity person)
        {
            return Task.CompletedTask;
        }

        public Task UpdateAsync(PersonEntity person)
        {
            return Task.CompletedTask;
        }
    }
}
