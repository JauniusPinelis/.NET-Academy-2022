using AutoMapper;
using FirstWebApi.Dtos;
using FirstWebApi.Entities;
using FirstWebApi.Exceptions;
using FirstWebApi.Repositories;

namespace FirstWebApi.Services
{
    public class PersonService
    {
        private readonly PersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(PersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public void Add(CreatePerson person)
        {
            // map from dto to entity
            //var entity = new PersonEntity
            //{
            //    Id = 1,//autogenerate
            //    FirstName = person.FirstName,
            //    LastName = person.LastName,
            //};

            var entity = _mapper.Map<PersonEntity>(person);
            entity.Id = 1;

            _personRepository.Add(entity);
        }

        public void Update(int id, UpdatePerson updatePerson)
        {
            if (id != updatePerson.Id)
            {
                throw new ArgumentException("Ids do not match");
            }

            var existingPerson = GetById(updatePerson.Id);

            if (updatePerson == null)
            {
                throw new NotFoundException();
            }

            //var entity = new PersonEntity
            //{
            //    Id = id,
            //    LastModifiedUtc = DateTime.UtcNow,
            //    FirstName = person.FirstName,
            //    LastName = person.LastName
            //};
            var entity = _mapper.Map<PersonEntity>(updatePerson);
            entity.LastModifiedUtc = DateTime.UtcNow;



            _personRepository.Update(entity);
        }

        public List<Person> GetAll()
        {
            return _personRepository.GetAll()
                .Select(p => _mapper.Map<Person>(p)).ToList();
        }

        public Person GetById(int id)
        {
            var entity = _personRepository.GetById(id);

            if (entity == null)
            {
                throw new ArgumentNullException("person not found");
            }

            return _mapper.Map<Person>(entity);
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
