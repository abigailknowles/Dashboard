using Moq;
using NUnit.Framework;
using PatientWarningApp.Data.Entities;
using PatientWarningApp.Data.Repositories;
using PatientWarningApp.Services.Models;
using PatientWarningApp.Services.PatientServices;

namespace PatientWarningApp.Tests.ServiceTests
{
    public class MedicalRecordService_Tests
    {
        private MedicalRecordService _medicalRecordService;
        private Mock<IMedicalRecordRepository> _medicalRecordRepository;

        private MedicalRecord _medicalRecord;
        private MedicalRecordModel _medicalRecordModel;


        [SetUp]
        public void Setup()
        {
            _medicalRecord = new MedicalRecord() {  Id = 1, StartDate="08/08/2000", SeizureTimes = "Mid-day", SeizureFrequencies = "Daily", SeizureTriggers = "Flashing lights", SeizureTypes="Fits", SideEffects="Impacts mental health", Notes="Has gotten worse over the past year" };
            _medicalRecordModel = new MedicalRecordModel { Id = 1, StartDate = "08/08/2000", SeizureTimes = "Mid-day", SeizureFrequencies = "Daily", SeizureTriggers = "Flashing lights", SeizureTypes = "Fits", SideEffects = "Impacts mental health", Notes = "Has gotten worse over the past year" };

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
            _medicalRecordRepository.Setup(o => o.Create(It.IsAny<MedicalRecord>())).Returns(_medicalRecord);

            _medicalRecordService = new MedicalRecordService(_medicalRecordRepository.Object);

            //Act
            var result = _medicalRecordService.Create(_medicalRecordModel);

            //Assert
            Assert.That(result.Id, Is.EqualTo(1));

        }

        [Test]
        public void GivenAMedicalRecordExists_DeleteReturnsEntity_WithIdAndPatientAccountIsDeleted()
        {
            //Arrange
            var medicalRecord = new MedicalRecord() { Id = 1, StartDate = "08/08/2000", SeizureTimes = "Mid-day", SeizureFrequencies = "Daily", SeizureTriggers = "Flashing lights", SeizureTypes = "Fits", SideEffects = "Impacts mental health", Notes = "Has gotten worse over the past year" };
            var medicalRecordModel = new MedicalRecordModel { Id = 1, StartDate = "08/08/2000", SeizureTimes = "Mid-day", SeizureFrequencies = "Daily", SeizureTriggers = "Flashing lights", SeizureTypes = "Fits", SideEffects = "Impacts mental health", Notes = "Has gotten worse over the past year" };

            _medicalRecordRepository = new Mock<IMedicalRecordRepository>();
            _medicalRecordRepository.Setup(o => o.Delete(It.IsAny<MedicalRecord>())).Returns(_medicalRecord);
            _medicalRecordRepository.Setup(o => o.Read(It.IsAny<int>()));
            _medicalRecordService = new MedicalRecordService(_medicalRecordRepository.Object);

            //Act
            var result = _medicalRecordService.Delete(_medicalRecordModel);
            var readResult = _medicalRecordService.Read(_medicalRecordModel.Id);

            //Assert
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(readResult, Is.Null);
        }

        [Test]
        public void GivenAMedicalRecordId_ReadReturnsEntity()
        {
            //Arrange
            var medicalRecord = new MedicalRecord() { Id = 1, StartDate = "08/08/2000", SeizureTimes = "Mid-day", SeizureFrequencies = "Daily", SeizureTriggers = "Flashing lights", SeizureTypes = "Fits", SideEffects = "Impacts mental health", Notes = "Has gotten worse over the past year" };
            var medicalRecordModel = new MedicalRecordModel { Id = 1, StartDate = "08/08/2000", SeizureTimes = "Mid-day", SeizureFrequencies = "Daily", SeizureTriggers = "Flashing lights", SeizureTypes = "Fits", SideEffects = "Impacts mental health", Notes = "Has gotten worse over the past year" };

            _medicalRecordRepository = new Mock<IMedicalRecordRepository>();
            _medicalRecordRepository.Setup(o => o.Read(It.IsAny<int>())).Returns(_medicalRecord);
            _medicalRecordService = new MedicalRecordService(_medicalRecordRepository.Object);

            //Act
            var readResult = _medicalRecordService.Read(_medicalRecordModel.Id);

            //Assert
            Assert.That(readResult.Id, Is.EqualTo(1));
        }

        [Test]
        public void GivenAnAccount_UpdateReturnsEntity_WithUpdatedValue()
        {
            //Arrange
            _medicalRecordRepository = new Mock<IMedicalRecordRepository>();
            _medicalRecordRepository.Setup(o => o.Update(It.IsAny<MedicalRecord>())).Returns(_medicalRecord);
            _medicalRecordService = new MedicalRecordService(_medicalRecordRepository.Object);

            //Act
            var readResult = _medicalRecordService.Update(_medicalRecordModel);

            //Assert
            Assert.That(readResult.Id, Is.EqualTo(1));
        }
    }
}
