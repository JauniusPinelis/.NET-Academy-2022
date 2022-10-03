using AutoMapper;
using FirstWebApi.ApiClients;
using FirstWebApi.Dtos;
using FirstWebApi.Entities;
using FirstWebApi.Exceptions;
using FirstWebApi.Profiles;
using FirstWebApi.Repositories;
using FirstWebApi.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace FirstWebApi.UnitTests
{
    public class PersonServiceTests
    {
        private PersonService _personService;

        private Mock<IPersonRepository> _personRepository;
        private Mock<IJsonPlaceholderApiClient> _jsonPlaceholderApiClient;
        private Mock<IDateTimeService> _dateTimeService;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _personRepository = new Mock<IPersonRepository>();
            _jsonPlaceholderApiClient = new Mock<IJsonPlaceholderApiClient>();
            _dateTimeService = new Mock<IDateTimeService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            _mapper = mappingConfig.CreateMapper();

            _personService = new PersonService(_personRepository.Object, _jsonPlaceholderApiClient.Object, _mapper, _dateTimeService.Object);
        }

        [Test]
        public void UpdateAsync_GivenIncorrectBodyId_ExceptionGetsThrown()
        {
            int id = 1;
            UpdatePerson updatePerson = new()
            {
                Id = 3
            };

            Assert.ThrowsAsync<ArgumentException>(async () => await _personService.UpdateAsync(id, updatePerson));
        }

        [Test]
        public void UpdateAsync_GivenIncorrectId_ThrowsNotFound()
        {
            int id = 1;
            UpdatePerson updatePerson = new()
            {
                Id = 1
            };

            Assert.ThrowsAsync<NotFoundException>(async () => await _personService.UpdateAsync(id, updatePerson));
        }

        [Test]
        public async Task UpdateAsync_GivenValidData_RepositoryUpdateWithCorrectUpdatedIsCalled()
        {
            int id = 1;
            UpdatePerson updatePerson = new()
            {
                Id = 1
            };

            PersonEntity personEntity = new()
            {
                Id = 1
            };

            _personRepository.Setup(x => x.GetById(id)).ReturnsAsync(personEntity);
            _personRepository.Setup(x => x.UpdateAsync(personEntity));

            personEntity.LastModifiedUtc = DateTime.UtcNow;

            await _personService.UpdateAsync(id, updatePerson);

            _personRepository.Verify(x => x.UpdateAsync(personEntity), Times.Once);
        }

        [Test]
        public async Task GetAllExternal_RegularCall_VerifyGetsCalled()
        {
            //Arrange
            _jsonPlaceholderApiClient.Setup(x => x.FetchData()).ReturnsAsync(new System.Collections.Generic.List<ApiClients.Contracts.PlaceholderUser>
            {
                new ApiClients.Contracts.PlaceholderUser()
                {
                    Username = "Jaunius",
                    Email = "Jauniuspinelis@gmail.com"
                }
            });

            var results = await _personService.GetAllExternal();
            //Act
            //Assert
            Assert.AreEqual("Jaunius", results[0].Username);

            _jsonPlaceholderApiClient.Verify(x => x.FetchData(), Times.Once);
        }
    }
}
