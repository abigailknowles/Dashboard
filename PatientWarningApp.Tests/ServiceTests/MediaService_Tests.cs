using Moq;
using NUnit.Framework;
using PatientWarningApp.Data.Entities;
using PatientWarningApp.Data.Repositories;
using PatientWarningApp.Services.Models;
using PatientWarningApp.Services.PatientServices;

namespace PatientWarningApp.Tests.ServiceTests
{
    public class MediaService_Tests
    {
        private MediaService _mediaService;
        private Mock<IMediaRepository> _mediaRepository;
        private Media _media;
        private MediaModel _mediaModel;


        [SetUp]
        public void Setup()
        {
            _mediaRepository = new Mock<IMediaRepository>();

            _media = new Media() { Id=1, Title="Shrek", Genre="Family", Director="JK Rowling", ReleaseDate="08/08/2000" };
            _mediaModel = new MediaModel { Id = 1, Title = "Shrek", Genre = "Family", Director = "JK Rowling", ReleaseDate = "08/08/2000" };

            _mediaRepository.Setup(o => o.Create(It.IsAny<Media>())).Returns(_media);
            _mediaRepository.Setup(o => o.Read(It.IsAny<int>())).Returns(_media);
            _mediaRepository.Setup(o => o.Update(It.IsAny<Media>())).Returns(_media);
            _mediaService = new MediaService(_mediaRepository.Object);
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void CreateMedia()
        {
            //Act
            var result = _mediaService.Create(_mediaModel);

            //Assert
            Assert.That(result.Id, Is.EqualTo(1));

        }

        [Test]
        public void DeleteMedia()
        {
            //Act
            var result = _mediaService.Delete(_mediaModel);

            //Assert
            Assert.That(result, Is.Null);

        }

        [Test]
        public void UpdateMedia()
        {
            //Act
            var result = _mediaService.Update(_mediaModel);

            //Assert
            Assert.That(result.Title, Is.EqualTo("Shrek"));

        }

        [Test]
        public void ReadMedia()
        {
            //Act
            var result = _mediaService.Read(_mediaModel.Id);

            //Assert
            Assert.That(result.Title, Is.EqualTo("Shrek"));

        }
    }
}
