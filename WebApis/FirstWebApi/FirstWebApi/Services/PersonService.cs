using FirstWebApi.Dtos;
using FirstWebApi.Entities;
using FirstWebApi.Repositories;

namespace FirstWebApi.Services
{
    public class PersonService
    {
        private readonly PersonRepository _personRepository;

        public PersonService(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void Add(CreatePerson person)
        {
            // map from dto to entity
            var entity = new PersonEntity
            {
                Id = 1,//autogenerate
                FirstName = person.FirstName,
                LastName = person.LastName,
            };

            _personRepository.Add(entity);
        }

        public void Update(PersonEntity person)
        {
            var existingPerson = GetById(person.Id);

            existingPerson.LastName = person.LastName;
            existingPerson.FirstName = person.FirstName;
        }

        public List<Person> GetAll()
        {
            return _personRepository.GetAll()
                .Select(p => new Person
                {
                    FirstName = p.FirstName,
                    CreatedUtc = p.CreatedUtc,
                    LastModifiedUtc = p.LastModifiedUtc,
                    LastName = p.LastName
                }).ToList();
        }

        public Person GetById(int id)
        {
            var person = _personRepository.GetById(id);

            if (person == null)
            {
                throw new ArgumentNullException("person not found");
            }

            return new Person
            {
                FirstName = person.FirstName,
                CreatedUtc = person.CreatedUtc,
                LastModifiedUtc = person.LastModifiedUtc,
                LastName = person.LastName
            };
        }

        public void Remove(int id)
        {
            var person = _personRepository.GetById(id);

            if (person == null)
            {
                throw new ArgumentNullException("person not found");
            }

            _personRepository.Remove(person);
        }
    }
}
