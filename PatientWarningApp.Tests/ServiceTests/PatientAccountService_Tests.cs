using Moq;
using NUnit.Framework;
using PatientWarningApp.Data.Entities;
using PatientWarningApp.Data.Repositories;
using PatientWarningApp.Services;
using PatientWarningApp.Services.Mappers;
using PatientWarningApp.Services.Models;

namespace PatientWarningApp.Tests.ServiceTests
{
    public class PatientAccountService_Tests
    {
        private PatientAccountService _patientAccountService;
        private Mock<IPatientAccountRepository> _patientAccountRepository;
        private Mock<IPatientAccountMapper> _patientAccountMapper;

        private PatientAccount _patient;
        private PatientAccountModel _patientModel;


        [SetUp]
        public void Setup()
        {
            _patient = new PatientAccount() { Id = 1, Email = "example@example.com", Password = "password", Username = "username" };
            _patientModel = new PatientAccountModel { Id = 1, Email = "example@example.com", Password = "password", Username = "username" };

            _patientAccountMapper = new Mock<IPatientAccountMapper>();
            _patientAccountMapper.Setup(o => o.ToEntity(_patientModel)).Returns(_patient);
            _patientAccountMapper.Setup(o => o.ToModel(_patient)).Returns(_patientModel);
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void GivenAnPatientAccount_CreateReturnsEntity_WithId()
        {
            //Arrange
            _patientAccountRepository = new Mock<IPatientAccountRepository>();
            _patientAccountRepository.Setup(o => o.Create(It.IsAny<PatientAccount>())).Returns(_patient);

            _patientAccountService = new PatientAccountService(_patientAccountRepository.Object, _patientAccountMapper.Object);

            //Act
            var result = _patientAccountService.Create(_patientModel);

            //Assert
            Assert.That(result.Id, Is.EqualTo(1));

        }

        [Test]
        public void GivenAnPatientAccount_DeleteReturnsEntity_WithIdAndPatientAccountIsDeleted()
        {
            //Arrange
            var patient = new PatientAccount() { Id = 1, Email = "example@example.com", Password = "password", Username = "username" };
            var patientModel = new PatientAccountModel { Id = 1, Email = "example@example.com", Password = "password", Username = "username" };

            _patientAccountRepository = new Mock<IPatientAccountRepository>();
            _patientAccountRepository.Setup(o => o.Delete(It.IsAny<PatientAccount>())).Returns(_patient);
            _patientAccountRepository.Setup(o => o.Read(It.IsAny<PatientAccount>()));
            _patientAccountService = new PatientAccountService(_patientAccountRepository.Object, _patientAccountMapper.Object);

            //Act
            var result = _patientAccountService.Delete(_patientModel);
            var readResult = _patientAccountService.Read(_patientModel);

            //Assert
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(readResult, Is.Null);
        }

        [Test]
        public void GivenAnPatientAccountId_ReadReturnsEntity()
        {
            //Arrange
            var patient = new PatientAccount() { Id = 1, Email = "example@example.com", Password = "password", Username = "username" };
            var patientModel = new PatientAccountModel { Id = 1, Email = "example@example.com", Password = "password", Username = "username" };

            _patientAccountRepository = new Mock<IPatientAccountRepository>();
            _patientAccountRepository.Setup(o => o.Read(It.IsAny<PatientAccount>())).Returns(_patient);
            _patientAccountService = new PatientAccountService(_patientAccountRepository.Object, _patientAccountMapper.Object);

            //Act
            var readResult = _patientAccountService.Read(_patientModel);

            //Assert
            Assert.That(readResult.Id, Is.EqualTo(1));
        }

        [Test]
        public void GivenAnAccount_UpdateReturnsEntity_WithUpdatedValue()
        {
            //Arrange
            _patientAccountRepository = new Mock<IPatientAccountRepository>();
            _patientAccountRepository.Setup(o => o.Update(It.IsAny<PatientAccount>())).Returns(_patient);
            _patientAccountService = new PatientAccountService(_patientAccountRepository.Object, _patientAccountMapper.Object);

            //Act
            var readResult = _patientAccountService.Update(_patientModel);

            //Assert
            Assert.That(readResult.Id, Is.EqualTo(1));
        }
    }

    

    

    
}
