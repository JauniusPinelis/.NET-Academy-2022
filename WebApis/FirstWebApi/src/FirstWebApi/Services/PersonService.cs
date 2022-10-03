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
        private readonly IPersonRepository _personRepository;
        private readonly IJsonPlaceholderApiClient _jsonPlaceholderApiClient;
        private readonly IMapper _mapper;
        private readonly IDateTimeService _dateTimeService;

        public PersonService(IPersonRepository personRepository, IJsonPlaceholderApiClient jsonPlaceholderApiClient,
            IMapper mapper, IDateTimeService dateTimeService)
        {
            _personRepository = personRepository;
            _jsonPlaceholderApiClient = jsonPlaceholderApiClient;
            _mapper = mapper;
            _dateTimeService = dateTimeService;
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

            var existingPerson = await GetById(updatePerson.Id);

            var entity = _mapper.Map<PersonEntity>(updatePerson);
            entity.LastModifiedUtc = _dateTimeService.GetNowUtc();

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


        public async Task<Person> GetById(int id)
        {
            var entity = await _personRepository.GetById(id);

            if (entity == null)
            {
                throw new NotFoundException();
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
