using FirstWebApi.Entities;
using Newtonsoft.Json;

namespace FirstWebApi.Repositories
{
    public class PersonRepository
    {
        private readonly string _filePath = "persons.txt";

        public void Add(PersonEntity entity)
        {
            var entities = GetAll();

            entities.Add(entity);

            WriteAll(entities);
        }

        public PersonEntity GetById(int id)
        {
            var persons = GetAll();
            return persons.FirstOrDefault(p => p.Id == id);
        }

        public List<PersonEntity> GetAll()
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
            var data = File.ReadAllText(_filePath);
            var persons = JsonConvert.DeserializeObject<List<PersonEntity>>(data);

            return persons.Where(p => !p.IsDeleted).ToList();
        }

        public void Remove(PersonEntity person)
        {
            var persons = GetAll();
            persons.Remove(person);
            WriteAll(persons);
        }

        public void Update(PersonEntity person)
        {
            var persons = GetAll();
            var personToUpdate = persons.FirstOrDefault(p => p.Id == person.Id);

            personToUpdate.FirstName = person.FirstName;
            personToUpdate.LastName = person.LastName;
            personToUpdate.LastModifiedUtc = person.LastModifiedUtc;

            WriteAll(persons);

            //This part could be improved
        }

        private void WriteAll(List<PersonEntity> persons)
        {
            var data = JsonConvert.SerializeObject(persons);
            File.WriteAllText(_filePath, data);
        }
    }
}
