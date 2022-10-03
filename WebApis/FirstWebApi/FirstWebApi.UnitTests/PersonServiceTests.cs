using FirstWebApi.Repositories;
using FirstWebApi.Services;
using FirstWebApi.UnitTests.Mocks;
using NUnit.Framework;

namespace FirstWebApi.UnitTests
{
    public class PersonServiceTests
    {
        private PersonService _personService;

        private IPersonRepository _personRepository;

        [SetUp]
        public void Setup()
        {
            _personRepository = new TestPersonRepository();
            _personService = new PersonService(_personRepository, )
        }

        [Test]
        public void UpdateAsync_GivenCorrectUpdate_LastModifiedUtcGetsUpdated()
        {
            //Arrange
            //Act
            //Assert
        }
    }
}
