﻿using Moq;
using NUnit.Framework;
using PatientWarningApp.Data.Entities;
using PatientWarningApp.Data.Repositories;
using PatientWarningApp.Services.Models;
using PatientWarningApp.Services.PatientServices;

namespace PatientWarningApp.Tests.ServiceTests
{
    public class PractitionerAccountService_Tests
    {
        private PractitionerAccountService _practitionerAccountService;
        private Mock<IPractitionerAccountRepository> _practitionerAccountRepository;

        private PractitionerAccount _practioner;
        private PractitionerAccountModel _practionerModel;


        [SetUp]
        public void Setup()
        {
            _practitionerAccountRepository = new Mock<IPractitionerAccountRepository>();

            _practioner = new PractitionerAccount() { PractitionerAccountId=1, Id = 1, Email = "example@example.com", Password = "password", Username = "username" };
            _practionerModel = new PractitionerAccountModel { PractitionerAccountId = 1, Id = 1, Email = "example@example.com", Password = "password", Username = "username" };

            _practitionerAccountRepository.Setup(o => o.Create(It.IsAny<PractitionerAccount>())).Returns(_practioner);
            _practitionerAccountRepository.Setup(o => o.Read(It.IsAny<int>())).Returns(_practioner);
            _practitionerAccountRepository.Setup(o => o.Update(It.IsAny<PractitionerAccount>())).Returns(_practioner);
            _practitionerAccountService = new PractitionerAccountService(_practitionerAccountRepository.Object);
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void GivenAnPractitionerAccount_CreateReturnsEntity_WithId()
        {
            //Act
            var result = _practitionerAccountService.Create(_practionerModel);

            //Assert
            Assert.That(result.Id, Is.EqualTo(1));

        }

        [Test]
        public void GivenAnPatientAccount_DeleteReturnsEntity_WithIdAndPatientAccountIsDeleted()
        {
            //Arrange
            var practitionerAccountRepository = new Mock<IPractitionerAccountRepository>();
            practitionerAccountRepository.Setup(o => o.Delete(It.IsAny<PractitionerAccount>())).Returns(_practioner);
            practitionerAccountRepository.Setup(o => o.Read(It.IsAny<int>()));
            var practitionerAccountService = new PractitionerAccountService(practitionerAccountRepository.Object);

            //Act
            var result = practitionerAccountService.Delete(_practionerModel);
            var readResult = practitionerAccountService.Read(_practionerModel.Id);

            //Assert
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(readResult, Is.Null);
        }

        [Test]
        public void GivenAnPatientAccountId_ReadReturnsEntity()
        {
            //Act
            var readResult = _practitionerAccountService.Read(_practionerModel.Id);

            //Assert
            Assert.That(readResult.Id, Is.EqualTo(1));
        }

        [Test]
        public void GivenAPatientUsername_And_Password_ReadReturnsEntity()
        {
            //Arrange
            var practitionerAccountRepository = new Mock<IPractitionerAccountRepository>();
            practitionerAccountRepository.Setup(o => o.ReadByUsernameAndPassword(It.IsAny<PractitionerAccount>())).Returns(_practioner);
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
            var readResult = _practitionerAccountService.Update(_practionerModel);

            //Assert
            Assert.That(readResult.Id, Is.EqualTo(1));
        }
    }

    

    

    
}
