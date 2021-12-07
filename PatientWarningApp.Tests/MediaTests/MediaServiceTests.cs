using Moq;
using NUnit.Framework;
using PatientWarningApp.Api.Media;
using PatientWarningApp.Api.Media.Entities;
using PatientWarningApp.Api.Media.Interfaces;
using PatientWarningApp.Api.Media.Models;

namespace PatientWarningApp.Tests.MediaTests
{
    public class MediaServiceTests
    {
        private MediaService _service;
        private Mock<IMediaRepository> _repository;
        private MediaEntity _entity;
        private MediaModel _model;


        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IMediaRepository>();

            _entity = new MediaEntity() { Id = 1, Title="Shrek", Genre="Family", Director="JK Rowling", ReleaseDate="08/08/2000" };
            _model = new MediaModel { Id = 1, Title = "Shrek", Genre = "Family", Director = "JK Rowling", ReleaseDate = "08/08/2000" };

            _repository.Setup(o => o.Create(It.IsAny<MediaEntity>())).Returns(_entity);
            _repository.Setup(o => o.Read(It.IsAny<int>())).Returns(_entity);
            _repository.Setup(o => o.Update(It.IsAny<MediaEntity>())).Returns(_entity);
            _service = new MediaService(_repository.Object);
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void CreateMedia()
        {
            //Act
            var result = _service.Create(_model);

            //Assert
            Assert.That(result.Id, Is.EqualTo(1));

        }

        [Test]
        public void DeleteMedia()
        {
            //Act
            var result = _service.Delete(_model);

            //Assert
            Assert.That(result, Is.Null);

        }

        [Test]
        public void UpdateMedia()
        {
            //Act
            var result = _service.Update(_model);

            //Assert
            Assert.That(result.Title, Is.EqualTo("Shrek"));

        }

        [Test]
        public void ReadMedia()
        {
            //Act
            var result = _service.Read(_model.Id);

            //Assert
            Assert.That(result.Title, Is.EqualTo("Shrek"));

        }
    }
}
