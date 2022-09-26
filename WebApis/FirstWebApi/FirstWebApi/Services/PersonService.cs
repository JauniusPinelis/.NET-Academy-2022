using AutoMapper;
using FirstWebApi.ApiClients;
using FirstWebApi.ApiClients.Contracts;
using FirstWebApi.Dtos;
using FirstWebApi.Entities;
using FirstWebApi.Exceptions;
using FirstWebApi.Repositories;

namespace FirstWebApi.Services
{
    public class PersonService
    {
        private readonly PersonRepository _personRepository;
        private readonly JsonPlaceholderApiClient _jsonPlaceholderApiClient;
        private readonly IMapper _mapper;

        public PersonService(PersonRepository personRepository, JsonPlaceholderApiClient jsonPlaceholderApiClient, IMapper mapper)
        {
            _personRepository = personRepository;
            _jsonPlaceholderApiClient = jsonPlaceholderApiClient;
            _mapper = mapper;
        }

        private async Task<List<PlaceholderUser>> FetchDataAsync()
        {
            return await _jsonPlaceholderApiClient.FetchData();
        }

        public async Task Add(CreatePerson person)
        {
            var entity = _mapper.Map<PersonEntity>(person);
            entity.Id = 1;

            await _personRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, UpdatePerson updatePerson)
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

            var entity = _mapper.Map<PersonEntity>(updatePerson);
            entity.LastModifiedUtc = DateTime.UtcNow;



            await _personRepository.UpdateAsync(entity);
        }

        public async Task<List<Person>> GetAll()
        {

            var entities = await _personRepository.GetAllAsync();
            return entities.Select(p => _mapper.Map<Person>(p)).ToList();
        }

        public async Task<List<PlaceholderUser>> GetAllExternal()
        {
            return await FetchDataAsync();
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

        public async Task RemoveAsync(int id)
        {
            var person = await _personRepository.GetById(id);

            if (person == null)
            {
                throw new ArgumentNullException("person not found");
            }

            await _personRepository.RemoveAsync(person);
        }
    }
}
