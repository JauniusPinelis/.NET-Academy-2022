using AutoFixture.NUnit3;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SquareManagement.Core.Exceptions;
using SquareManagement.Core.Interfaces;
using SquareManagement.Core.Model;
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


        [SetUp]
        public void Setup()
        {
            _pointListRepository = new Mock<IPointListRepository>();



            _pointListService = new PointListService(_pointListRepository.Object);
        }

        [Test, AutoData]
        public async Task Create_GivenValidCreate_RepositoryCreateIsCalled(PointListModel createPointList)
        {
            var created = await _pointListService.Create(createPointList);

            created.Should().NotBeNull();

            _pointListRepository.Verify(mock => mock.Create(It.IsAny<PointListModel>()), Times.Once());
        }

        [Test, AutoData]
        public async Task Remove_GivenValidId_RepositoryRemoveIsCalled(PointListModel pointList)
        {
            _pointListRepository.Setup(x => x.Get(pointList.Id)).ReturnsAsync(pointList);

            await _pointListService.Remove(pointList.Id);

            _pointListRepository.Verify(mock => mock.Remove(pointList.Id), Times.Once());
        }

        [Test, AutoData]
        public async Task Remove_GivenIncorrectId_ExceptionGetsThrown(PointListModel pointList)
        {
            Func<Task> act = async () => await _pointListService.Remove(pointList.Id);

            await act.Should().ThrowAsync<PointListNotFoundException>();
        }

    }
}
