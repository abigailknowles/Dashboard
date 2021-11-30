using Moq;
using NUnit.Framework;
using PatientWarningApp.Api.PractitionerAccount;
using PatientWarningApp.Api.PractitionerAccount.Entities;
using PatientWarningApp.Api.PractitionerAccount.Interfaces;
using PatientWarningApp.Api.PractitionerAccount.Models;

namespace PatientWarningApp.Tests.PractitionerAccountTests
{
    public class PractitionerAccountServiceTests
    {
        private PractitionerAccountService _service;
        private Mock<IPractitionerAccountRepository> _repository;

        private PractitionerAccountEntity _entity;
        private PractitionerAccountModel _model;


        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IPractitionerAccountRepository>();

            _entity = new PractitionerAccountEntity() { PractitionerAccountId=1, Id = 1, Email = "example@example.com", Password = "password", Username = "username" };
            _model = new PractitionerAccountModel { PractitionerAccountId = 1, Id = 1, Email = "example@example.com", Password = "password", Username = "username" };

            _repository.Setup(o => o.Create(It.IsAny<PractitionerAccountEntity>())).Returns(_entity);
            _repository.Setup(o => o.Read(It.IsAny<int>())).Returns(_entity);
            _repository.Setup(o => o.Update(It.IsAny<PractitionerAccountEntity>())).Returns(_entity);
            _service = new PractitionerAccountService(_repository.Object);
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void GivenAnPractitionerAccount_CreateReturnsEntity_WithId()
        {
            //Act
            var result = _service.Create(_model);

            //Assert
            Assert.That(result.PractitionerAccountId, Is.EqualTo(1));

        }

        [Test]
        public void GivenAnPatientAccount_DeleteReturnsEntity_WithIdAndPatientAccountIsDeleted()
        {
            //Arrange
            var practitionerAccountRepository = new Mock<IPractitionerAccountRepository>();
            practitionerAccountRepository.Setup(o => o.Delete(It.IsAny<PractitionerAccountEntity>())).Returns(_entity);
            practitionerAccountRepository.Setup(o => o.Read(It.IsAny<int>()));
            var practitionerAccountService = new PractitionerAccountService(practitionerAccountRepository.Object);

            //Act
            var result = practitionerAccountService.Delete(_model);
            var readResult = practitionerAccountService.Read(_model.Id);

            //Assert
            Assert.That(result.PractitionerAccountId, Is.EqualTo(1));
            Assert.That(readResult, Is.Null);
        }

        [Test]
        public void GivenAnPatientAccountId_ReadReturnsEntity()
        {
            //Act
            var readResult = _service.Read(_model.Id);

            //Assert
            Assert.That(readResult.PractitionerAccountId, Is.EqualTo(1));
        }

        [Test]
        public void GivenAPatientUsername_And_Password_ReadReturnsEntity()
        {
            //Arrange
            var practitionerAccountRepository = new Mock<IPractitionerAccountRepository>();
            practitionerAccountRepository.Setup(o => o.ReadByUsernameAndPassword(It.IsAny<PractitionerAccountEntity>())).Returns(_entity);
            var practitionerAccountService = new PractitionerAccountService(practitionerAccountRepository.Object);

            //Act
            var pract = new PractitionerAccountModel { Username = "username", Password = "password" };
            var readResult = practitionerAccountService.ReadByUsernameAndPassword(pract);

            //Assert
            Assert.That(readResult.Username, Is.EqualTo("username"));
            Assert.That(readResult.Password, Is.EqualTo("password"));
        }


        [Test]
        public void GivenAnAccount_UpdateReturnsEntity_WithUpdatedValue()
        {
            //Act
            var readResult = _service.Update(_model);

            //Assert
            Assert.That(readResult.PractitionerAccountId, Is.EqualTo(1));
        }
    }

    

    

    
}
