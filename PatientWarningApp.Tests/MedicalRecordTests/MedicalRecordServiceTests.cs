using Moq;
using NUnit.Framework;
using PatientWarningApp.Api.MedicalRecords;
using PatientWarningApp.Api.MedicalRecords.Entities;
using PatientWarningApp.Api.MedicalRecords.Interfaces;
using PatientWarningApp.Api.MedicalRecords.Models;

namespace PatientWarningApp.Tests.MedicalRecordTests
{
    public class MedicalRecordServiceTests
    {
        private MedicalRecordService _service;
        private Mock<IMedicalRecordRepository> _repository;

        [SetUp]
        public void Setup()
        {

        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void GivenAMedicalRecordExists_CreateReturnsEntity_WithId()
        {
            var entity = new MedicalRecordEntity() { Id = 1, StartDate = "08/08/2000", SeizureTimes = "Mid-day", SeizureFrequencies = "Daily", SeizureTriggers = "Flashing lights", SeizureTypes = "Fits", SideEffects = "Impacts mental health", Notes = "Has gotten worse over the past year" };
            var model = new MedicalRecordModel { Id = 1, StartDate = "08/08/2000", SeizureTimes = "Mid-day", SeizureFrequencies = "Daily", SeizureTriggers = "Flashing lights", SeizureTypes = "Fits", SideEffects = "Impacts mental health", Notes = "Has gotten worse over the past year" };

            //Arrange
            _repository = new Mock<IMedicalRecordRepository>();
            _repository.Setup(o => o.Create(It.IsAny<MedicalRecordEntity>())).Returns(entity);

            _service = new MedicalRecordService(_repository.Object);

            //Act
            var result = _service.Create(model);

            //Assert
            Assert.That(result.Id, Is.EqualTo(1));

        }

        [Test]
        public void GivenAMedicalRecordExists_DeleteReturnsEntity_WithIdAndPatientAccountIsDeleted()
        {
            //Arrange
            var entity = new MedicalRecordEntity() { Id = 1, StartDate = "08/08/2000", SeizureTimes = "Mid-day", SeizureFrequencies = "Daily", SeizureTriggers = "Flashing lights", SeizureTypes = "Fits", SideEffects = "Impacts mental health", Notes = "Has gotten worse over the past year" };
            var model = new MedicalRecordModel { Id = 1, StartDate = "08/08/2000", SeizureTimes = "Mid-day", SeizureFrequencies = "Daily", SeizureTriggers = "Flashing lights", SeizureTypes = "Fits", SideEffects = "Impacts mental health", Notes = "Has gotten worse over the past year" };

            _repository = new Mock<IMedicalRecordRepository>();
            _repository.Setup(o => o.Delete(It.IsAny<MedicalRecordEntity>())).Returns(entity);
            _repository.Setup(o => o.Read(It.IsAny<int>()));
            _service = new MedicalRecordService(_repository.Object);

            //Act
            var result = _service.Delete(model);
            var readResult = _service.Read(model.Id);

            //Assert
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(readResult, Is.Null);
        }

        [Test]
        public void GivenAMedicalRecordId_ReadReturnsEntity()
        {
            //Arrange
            var entity = new MedicalRecordEntity() { Id = 1, StartDate = "08/08/2000", SeizureTimes = "Mid-day", SeizureFrequencies = "Daily", SeizureTriggers = "Flashing lights", SeizureTypes = "Fits", SideEffects = "Impacts mental health", Notes = "Has gotten worse over the past year" };
            var model = new MedicalRecordModel { Id = 1, StartDate = "08/08/2000", SeizureTimes = "Mid-day", SeizureFrequencies = "Daily", SeizureTriggers = "Flashing lights", SeizureTypes = "Fits", SideEffects = "Impacts mental health", Notes = "Has gotten worse over the past year" };

            _repository = new Mock<IMedicalRecordRepository>();
            _repository.Setup(o => o.Read(It.IsAny<int>())).Returns(entity);
            _service = new MedicalRecordService(_repository.Object);

            //Act
            var readResult = _service.Read(model.Id);

            //Assert
            Assert.That(readResult.Id, Is.EqualTo(1));
        }

        [Test]
        public void GivenAnAccount_UpdateReturnsEntity_WithUpdatedValue()
        {
            //Arrange
            var entity = new MedicalRecordEntity() { Id = 1, StartDate = "08/08/2000", SeizureTimes = "Mid-day", SeizureFrequencies = "Daily", SeizureTriggers = "Flashing lights", SeizureTypes = "Fits", SideEffects = "Impacts mental health", Notes = "Has gotten worse over the past year" };
            var model = new MedicalRecordModel { Id = 1, StartDate = "08/08/2000", SeizureTimes = "Mid-day", SeizureFrequencies = "Daily", SeizureTriggers = "Flashing lights", SeizureTypes = "Fits", SideEffects = "Impacts mental health", Notes = "Has gotten worse over the past year" };

            _repository = new Mock<IMedicalRecordRepository>();
            _repository.Setup(o => o.Update(It.IsAny<MedicalRecordEntity>())).Returns(entity);
            _service = new MedicalRecordService(_repository.Object);

            //Act
            var readResult = _service.Update(model);

            //Assert
            Assert.That(readResult.Id, Is.EqualTo(1));
        }
    }
}
