using Moq;
using NUnit.Framework;
using PatientWarningApp.Data.Entities;
using PatientWarningApp.Data.Repositories;
using PatientWarningApp.Services.Mappers;
using PatientWarningApp.Services.Models;
using PatientWarningApp.Services.PatientServices;

namespace PatientWarningApp.Tests.ServiceTests
{
    public class PractitionerAccountService_Tests
    {
        private PractitionerAccountService _practitionerAccountService;
        private Mock<IPractitionerAccountRepository> _practitionerAccountRepository;
        private Mock<IPractitionerAccountMapper> _practitionerAccountMapper;

        private PractitionerAccount _patient;
        private PractitionerAccountModel _patientModel;


        [SetUp]
        public void Setup()
        {
            _practitionerAccountRepository = new Mock<IPractitionerAccountRepository>();

            _patient = new PractitionerAccount() { Id = 1, Email = "example@example.com", Password = "password", Username = "username" };
            _patientModel = new PractitionerAccountModel { Id = 1, Email = "example@example.com", Password = "password", Username = "username" };

            _practitionerAccountMapper = new Mock<IPractitionerAccountMapper>();
            _practitionerAccountMapper.Setup(o => o.ToEntity(_patientModel)).Returns(_patient);
            _practitionerAccountMapper.Setup(o => o.ToModel(_patient)).Returns(_patientModel);

            _practitionerAccountRepository.Setup(o => o.Create(It.IsAny<PractitionerAccount>())).Returns(_patient);
            _practitionerAccountRepository.Setup(o => o.Read(It.IsAny<PractitionerAccount>())).Returns(_patient);
            _practitionerAccountRepository.Setup(o => o.Update(It.IsAny<PractitionerAccount>())).Returns(_patient);
            _practitionerAccountService = new PractitionerAccountService(_practitionerAccountRepository.Object, _practitionerAccountMapper.Object);
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void GivenAnPractitionerAccount_CreateReturnsEntity_WithId()
        {
            //Act
            var result = _practitionerAccountService.Create(_patientModel);

            //Assert
            Assert.That(result.Id, Is.EqualTo(1));

        }

        [Test]
        public void GivenAnPatientAccount_DeleteReturnsEntity_WithIdAndPatientAccountIsDeleted()
        {
            //Arrange
            var practitionerAccountRepository = new Mock<IPractitionerAccountRepository>();
            practitionerAccountRepository.Setup(o => o.Delete(It.IsAny<PractitionerAccount>())).Returns(_patient);
            practitionerAccountRepository.Setup(o => o.Read(It.IsAny<PractitionerAccount>()));
            var practitionerAccountService = new PractitionerAccountService(practitionerAccountRepository.Object, _practitionerAccountMapper.Object);

            //Act
            var result = practitionerAccountService.Delete(_patientModel);
            var readResult = practitionerAccountService.Read(_patientModel);

            //Assert
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(readResult, Is.Null);
        }

        [Test]
        public void GivenAnPatientAccountId_ReadReturnsEntity()
        {
            //Act
            var readResult = _practitionerAccountService.Read(_patientModel);

            //Assert
            Assert.That(readResult.Id, Is.EqualTo(1));
        }

        [Test]
        public void GivenAnAccount_UpdateReturnsEntity_WithUpdatedValue()
        {
            //Act
            var readResult = _practitionerAccountService.Update(_patientModel);

            //Assert
            Assert.That(readResult.Id, Is.EqualTo(1));
        }
    }

    

    

    
}
