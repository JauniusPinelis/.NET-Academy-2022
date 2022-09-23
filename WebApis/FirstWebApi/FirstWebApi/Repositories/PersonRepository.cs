using FirstWebApi.Entities;
using Newtonsoft.Json;

namespace FirstWebApi.Repositories
{
    public class PersonRepository
    {
        private readonly string _filePath = "persons.txt";

        public async Task AddAsync(PersonEntity entity)
        {
            var entities = await GetAllAsync();

            entities.Add(entity);

            await WriteAllAsync(entities);
        }

        public async Task<PersonEntity> GetById(int id)
        {
            var persons = await GetAllAsync();
            return persons.FirstOrDefault(p => p.Id == id);
        }

        public async Task<List<PersonEntity>> GetAllAsync()
        {
            if (!File.Exists(_filePath))
            {
                await File.WriteAllTextAsync(_filePath, "[]");
            }
            var data = await File.ReadAllTextAsync(_filePath);
            var persons = JsonConvert.DeserializeObject<List<PersonEntity>>(data);

            return persons.Where(p => !p.IsDeleted).ToList();
        }

        public async Task RemoveAsync(PersonEntity person)
        {
            var persons = await GetAllAsync();
            persons.Remove(person);
            await WriteAllAsync(persons);
        }

        public async Task UpdateAsync(PersonEntity person)
        {
            var persons = await GetAllAsync();
            var personToUpdate = persons.FirstOrDefault(p => p.Id == person.Id);

            personToUpdate.FirstName = person.FirstName;
            personToUpdate.LastName = person.LastName;
            personToUpdate.LastModifiedUtc = person.LastModifiedUtc;

            await WriteAllAsync(persons);

            //This part could be improved
        }

        private async Task WriteAllAsync(List<PersonEntity> persons)
        {
            var data = JsonConvert.SerializeObject(persons);
            await File.WriteAllTextAsync(_filePath, data);
        }
    }
}
