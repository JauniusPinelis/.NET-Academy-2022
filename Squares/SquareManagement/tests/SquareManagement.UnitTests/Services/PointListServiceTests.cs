using AutoFixture.NUnit3;
using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SquareManagement.Core.Exceptions;
using SquareManagement.Core.Interfaces;
using SquareManagement.Core.Model;
using SquareManagement.Services.Dtos;
using SquareManagement.Services.MappingProfiles;
using SquareManagement.Services.Services;
using System;
using System.Threading.Tasks;

namespace SquareManagement.UnitTests.Services
{
    [TestFixture]
    public class PointListServiceTests
    {
        private PointListService _pointListService = null!;

        private Mock<IPointListRepository> _pointListRepository = null!;

        private IMapper _mapper = null!;

        [SetUp]
        public void Setup()
        {
            _pointListRepository = new Mock<IPointListRepository>();

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(typeof(MainMappingProfile)));
            _mapper = new Mapper(configuration);

            _pointListService = new PointListService(_pointListRepository.Object, _mapper);
        }

        [Test, AutoData]
        public async Task Create_GivenValidCreate_RepositoryCreateIsCalled(CreatePointList createPointList)
        {
            var created = await _pointListService.Create(createPointList);

            created.Should().NotBeNull();

            _pointListRepository.Verify(mock => mock.Create(It.IsAny<PointList>()), Times.Once());
        }

        [Test, AutoData]
        public async Task Remove_GivenValidId_RepositoryRemoveIsCalled(PointList pointList)
        {
            _pointListRepository.Setup(x => x.Get(pointList.Id)).ReturnsAsync(pointList);

            await _pointListService.Remove(pointList.Id);

            _pointListRepository.Verify(mock => mock.Remove(pointList.Id), Times.Once());
        }

        [Test, AutoData]
        public async Task Remove_GivenIncorrectId_ExceptionGetsThrown(PointList pointList)
        {
            Func<Task> act = async () => await _pointListService.Remove(pointList.Id);

            await act.Should().ThrowAsync<PointListNotFoundException>();
        }

    }
}
