using Moq;
using NUnit.Framework;
using PatientWarningApp.Api.MedicalRecords;
using PatientWarningApp.Api.MedicalRecords.Entities;
using PatientWarningApp.Api.MedicalRecords.Interfaces;
using PatientWarningApp.Api.MedicalRecords.Models;

namespace PatientWarningApp.Tests.ServiceTests
{
    public class MedicalRecordService_Tests
    {
        private MedicalRecordService _medicalRecordService;
        private Mock<IMedicalRecordRepository> _medicalRecordRepository;

        private MedicalRecordEntity _entity;
        private MedicalRecordModel _model;


        [SetUp]
        public void Setup()
        {
            _entity = new MedicalRecordEntity() { Id = 1, StartDate = "08/08/2000", SeizureTimes = "Mid-day", SeizureFrequencies = "Daily", SeizureTriggers = "Flashing lights", SeizureTypes = "Fits", SideEffects = "Impacts mental health", Notes = "Has gotten worse over the past year" };
            _model = new MedicalRecordModel { Id = 1, StartDate = "08/08/2000", SeizureTimes = "Mid-day", SeizureFrequencies = "Daily", SeizureTriggers = "Flashing lights", SeizureTypes = "Fits", SideEffects = "Impacts mental health", Notes = "Has gotten worse over the past year" };

        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void GivenAMedicalRecordExists_CreateReturnsEntity_WithId()
        {
            //Arrange
            _medicalRecordRepository = new Mock<IMedicalRecordRepository>();
            _medicalRecordRepository.Setup(o => o.Create(It.IsAny<MedicalRecordEntity>())).Returns(_entity);

            _medicalRecordService = new MedicalRecordService(_medicalRecordRepository.Object);

            //Act
            var result = _medicalRecordService.Create(_model);

            //Assert
            Assert.That(result.Id, Is.EqualTo(1));

        }

        [Test]
        public void GivenAMedicalRecordExists_DeleteReturnsEntity_WithIdAndPatientAccountIsDeleted()
        {
            //Arrange
            var entity = new MedicalRecordEntity() { Id = 1, StartDate = "08/08/2000", SeizureTimes = "Mid-day", SeizureFrequencies = "Daily", SeizureTriggers = "Flashing lights", SeizureTypes = "Fits", SideEffects = "Impacts mental health", Notes = "Has gotten worse over the past year" };
            var model = new MedicalRecordModel { Id = 1, StartDate = "08/08/2000", SeizureTimes = "Mid-day", SeizureFrequencies = "Daily", SeizureTriggers = "Flashing lights", SeizureTypes = "Fits", SideEffects = "Impacts mental health", Notes = "Has gotten worse over the past year" };

            _medicalRecordRepository = new Mock<IMedicalRecordRepository>();
            _medicalRecordRepository.Setup(o => o.Delete(It.IsAny<MedicalRecordEntity>())).Returns(entity);
            _medicalRecordRepository.Setup(o => o.Read(It.IsAny<int>()));
            _medicalRecordService = new MedicalRecordService(_medicalRecordRepository.Object);

            //Act
            var result = _medicalRecordService.Delete(model);
            var readResult = _medicalRecordService.Read(model.Id);

            //Assert
            Assert.That(result.Id, Is.EqualTo(entity.Id));
            Assert.That(readResult, Is.Null);
        }

        [Test]
        public void GivenAMedicalRecordId_ReadReturnsEntity()
        {
            //Arrange
            var entity = new MedicalRecordEntity() { Id = 1, StartDate = "08/08/2000", SeizureTimes = "Mid-day", SeizureFrequencies = "Daily", SeizureTriggers = "Flashing lights", SeizureTypes = "Fits", SideEffects = "Impacts mental health", Notes = "Has gotten worse over the past year" };
            var model = new MedicalRecordModel { Id = 1, StartDate = "08/08/2000", SeizureTimes = "Mid-day", SeizureFrequencies = "Daily", SeizureTriggers = "Flashing lights", SeizureTypes = "Fits", SideEffects = "Impacts mental health", Notes = "Has gotten worse over the past year" };

            _medicalRecordRepository = new Mock<IMedicalRecordRepository>();
            _medicalRecordRepository.Setup(o => o.Read(It.IsAny<int>())).Returns(entity);
            _medicalRecordService = new MedicalRecordService(_medicalRecordRepository.Object);

            //Act
            var readResult = _medicalRecordService.Read(model.Id);

            //Assert
            Assert.That(readResult.Id, Is.EqualTo(entity.Id));
        }

        [Test]
        public void GivenAMedicalRecord_UpdateReturnsEntity_WithUpdatedValue()
        {
            //Arrange
            var entity = new MedicalRecordEntity() { Id = 1, StartDate = "08/08/2000", SeizureTimes = "Mid-day", SeizureFrequencies = "Daily", SeizureTriggers = "Flashing lights", SeizureTypes = "Fits", SideEffects = "Impacts mental health", Notes = "Has gotten worse over the past year" };
            var model = new MedicalRecordModel { Id = 1, StartDate = "08/08/2000", SeizureTimes = "Night", SeizureFrequencies = "Weekly", SeizureTriggers = "Flashing lights", SeizureTypes = "Fits", SideEffects = "Impacts mental health", Notes = "Has gotten worse over the past year" };

            _medicalRecordRepository = new Mock<IMedicalRecordRepository>();
            _medicalRecordRepository.Setup(o => o.Update(It.IsAny<MedicalRecordEntity>())).Returns(entity);
            _medicalRecordService = new MedicalRecordService(_medicalRecordRepository.Object);

            //Act
            var readResult = _medicalRecordService.Update(model);

            //Assert
            Assert.That(readResult.SeizureTimes, Is.EqualTo(entity.SeizureTimes));
            Assert.That(readResult.SeizureFrequencies, Is.EqualTo(entity.SeizureFrequencies));
        }
    }
}
