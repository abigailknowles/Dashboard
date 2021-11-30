using Moq;
using NUnit.Framework;
using PatientWarningApp.Api.Media;
using PatientWarningApp.Api.Media.Entities;
using PatientWarningApp.Api.Media.Models;
using PatientWarningApp.Api.ReviewedMedia;
using PatientWarningApp.Api.ReviewedMedia.Entities;
using PatientWarningApp.Api.ReviewedMedia.Models;

namespace PatientWarningApp.Tests.MediaTests
{
    public class ReviewedMediaServiceTests
    {
        private ReviewedMediaService _service;
        private Mock<IReviewedMediaRepository> _repository;
        private ReviewedMediaEntity _entity;
        private ReviewedMediaModel _model;


        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IReviewedMediaRepository>();

            _entity = new ReviewedMediaEntity() { Id=1, FilmId=1, SeizureTriggerTimes="Half way", EpilepsyRating="1/10", Notes="Safe to watch" };
            _model = new ReviewedMediaModel { Id = 1, FilmId = 1, SeizureTriggerTimes = "Half way", EpilepsyRating = "1/10", Notes = "Safe to watch" };

            _repository.Setup(o => o.Create(It.IsAny<ReviewedMediaEntity>())).Returns(_entity);
            _repository.Setup(o => o.Read(It.IsAny<int>())).Returns(_entity);
            _repository.Setup(o => o.Update(It.IsAny<ReviewedMediaEntity>())).Returns(_entity);
            _service = new ReviewedMediaService(_repository.Object);
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
            Assert.That(result.SeizureTriggerTimes, Is.EqualTo("Half way"));

        }

        [Test]
        public void ReadMedia()
        {
            //Act
            var result = _service.Read(_model.Id);

            //Assert
            Assert.That(result.SeizureTriggerTimes, Is.EqualTo("Half way"));

        }
    }
}
