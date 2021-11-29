using Moq;
using NUnit.Framework;
using PatientWarningApp.Data.Entities;
using PatientWarningApp.Data.Repositories;
using PatientWarningApp.Services.Models;
using PatientWarningApp.Services.PatientServices;

namespace PatientWarningApp.Tests.ServiceTests
{
    public class ReviewedMediaService_Tests
    {
        private ReviewedMediaService _reviewedMediaService;
        private Mock<IReviewedMediaRepository> _reviewedMediaRepository;
        private ReviewedMedia _reviewedMedia;
        private ReviewedMediaModel _reviewedMediaModel;


        [SetUp]
        public void Setup()
        {
            _reviewedMediaRepository = new Mock<IReviewedMediaRepository>();

            _reviewedMedia = new ReviewedMedia() { Id=1, FilmId=1, SeizureTriggerTimes="Half way", EpilepsyRating="1/10", Notes="Safe to watch" };
            _reviewedMediaModel = new ReviewedMediaModel { Id = 1, FilmId = 1, SeizureTriggerTimes = "Half way", EpilepsyRating = "1/10", Notes = "Safe to watch" };

            _reviewedMediaRepository.Setup(o => o.Create(It.IsAny<ReviewedMedia>())).Returns(_reviewedMedia);
            _reviewedMediaRepository.Setup(o => o.Read(It.IsAny<int>())).Returns(_reviewedMedia);
            _reviewedMediaRepository.Setup(o => o.Update(It.IsAny<ReviewedMedia>())).Returns(_reviewedMedia);
            _reviewedMediaService = new ReviewedMediaService(_reviewedMediaRepository.Object);
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void CreateMedia()
        {
            //Act
            var result = _reviewedMediaService.Create(_reviewedMediaModel);

            //Assert
            Assert.That(result.Id, Is.EqualTo(1));

        }

        [Test]
        public void DeleteMedia()
        {
            //Act
            var result = _reviewedMediaService.Delete(_reviewedMediaModel);

            //Assert
            Assert.That(result, Is.Null);

        }

        [Test]
        public void UpdateMedia()
        {
            //Act
            var result = _reviewedMediaService.Update(_reviewedMediaModel);

            //Assert
            Assert.That(result.SeizureTriggerTimes, Is.EqualTo("Half way"));

        }

        [Test]
        public void ReadMedia()
        {
            //Act
            var result = _reviewedMediaService.Read(_reviewedMediaModel.Id);

            //Assert
            Assert.That(result.SeizureTriggerTimes, Is.EqualTo("Half way"));

        }
    }
}
