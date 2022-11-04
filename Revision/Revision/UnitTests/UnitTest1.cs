using Moq;
using NUnit.Framework;
using Revision.Services;

namespace UnitTests
{
    public class Tests
    {
        private Mock<FileService> _fileServiceMock;
        [SetUp]
        public void Setup()
        {
            _fileServiceMock = new Mock<FileService>();
        }

        [Test]
        public void Test1()
        {
            var fileService = _fileServiceMock.Object;

            Assert.Pass();
        }
    }
}