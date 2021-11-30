using Moq;
using NUnit.Framework;
using PatientWarningApp.Api.PatientAccount;
using PatientWarningApp.Api.PatientAccount.Entities;
using PatientWarningApp.Api.PatientAccount.Interfaces;
using PatientWarningApp.Api.PatientAccount.Models;

namespace PatientWarningApp.Tests.PatientAccountTests
{
    public class PatientAccountServiceTests
    {
        private PatientAccountService _service;
        private Mock<IPatientAccountRepository> _repository;

        private PatientAccountEntity _entity;
        private PatientAccountModel _model;


        [SetUp]
        public void Setup()
        {
            _entity = new PatientAccountEntity() { PatientAccountId = 1, Id = 1, Email = "example@example.com", Password = "password", Username = "username" };
            _model = new PatientAccountModel { PatientAccountId = 1, Id = 1, Email = "example@example.com", Password = "password", Username = "username" };

        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void GivenAnPatientAccount_CreateReturnsEntity_WithId()
        {
            //Arrange
            _repository = new Mock<IPatientAccountRepository>();
            _repository.Setup(o => o.Create(It.IsAny<PatientAccountEntity>())).Returns(_entity);

            _service = new PatientAccountService(_repository.Object);

            //Act
            var result = _service.Create(_model);

            //Assert
            Assert.That(result.PatientAccountId, Is.EqualTo(1));

        }

        [Test]
        public void GivenAnPatientAccount_DeleteReturnsEntity_WithIdAndPatientAccountIsDeleted()
        {
            //Arrange
            var entity = new PatientAccountEntity() { Id = 1, Email = "example@example.com", Password = "password", Username = "username" };
            var model = new PatientAccountModel { Id = 1, Email = "example@example.com", Password = "password", Username = "username" };

            _repository = new Mock<IPatientAccountRepository>();
            _repository.Setup(o => o.Delete(It.IsAny<PatientAccountEntity>())).Returns(entity);
            _repository.Setup(o => o.Read(It.IsAny<int>()));
            _service = new PatientAccountService(_repository.Object);

            //Act
            var result = _service.Delete(model);
            var readResult = _service.Read(model.PatientAccountId);

            //Assert
            Assert.That(result.PatientAccountId, Is.EqualTo(entity.PatientAccountId));
            Assert.That(readResult, Is.Null);
        }

        [Test]
        public void GivenAnPatientAccountId_ReadReturnsEntity()
        {
            //Arrange
            var entity = new PatientAccountEntity() { Id = 1, Email = "example@example.com", Password = "password", Username = "username" };
            var model = new PatientAccountModel { Id = 1, Email = "example@example.com", Password = "password", Username = "username" };

            _repository = new Mock<IPatientAccountRepository>();
            _repository.Setup(o => o.Read(It.IsAny<int>())).Returns(entity);
            _service = new PatientAccountService(_repository.Object);

            //Act
            var readResult = _service.Read(model.PatientAccountId);

            //Assert
            Assert.That(readResult.PatientAccountId, Is.EqualTo(entity.PatientAccountId));
        }

        [Test]
        public void GivenAnAccount_UpdateReturnsEntity_WithUpdatedValue()
        {
            //Arrange
            var entity = new PatientAccountEntity() { Id = 1, Email = "example@example.com", Password = "password", Username = "username" };
            var model = new PatientAccountModel { Id = 1, Email = "ian@example.com", Password = "password", Username = "username" };

            _repository = new Mock<IPatientAccountRepository>();
            _repository.Setup(o => o.Update(It.IsAny<PatientAccountEntity>())).Returns(entity);
            _service = new PatientAccountService(_repository.Object);

            //Act
            var readResult = _service.Update(model);

            //Assert
            Assert.That(readResult.PatientAccountId, Is.EqualTo(entity.PatientAccountId));
            Assert.That(readResult.Email, Is.EqualTo(entity.Email));
        }
    }
}
