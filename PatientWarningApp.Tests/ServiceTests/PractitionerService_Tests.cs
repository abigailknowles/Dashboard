using Moq;
using NUnit.Framework;
using PatientWarningApp.Data.Entities;
using PatientWarningApp.Data.Repositories;
using PatientWarningApp.Services.Mappers;
using PatientWarningApp.Services.Models;
using PatientWarningApp.Services.PatientServices;
using System;

namespace PatientWarningApp.Tests.ServiceTests
{
    public class PractitionerService_Tests
    {
        private PractitionerService _practitionerService;
        private Mock<IPractitionerRepository> _practitionerRepository;
        private Practitioner _practioner;
        private PractitionerModel _practionerModel;


        [SetUp]
        public void Setup()
        {
            _practitionerRepository = new Mock<IPractitionerRepository>();

            _practioner = new Practitioner() { PractitionerId=1, Id = 1, FirstName="Abigail", LastName="Surname", Title="Miss", Gender="Female",MobileNumber="01772318926",DOB= "08/08/2000" };
            _practionerModel = new PractitionerModel { PractitionerId = 1, Id = 1, FirstName = "Abigail", LastName = "Surname", Title = "Miss", Gender = "Female", MobileNumber = "01772318926", DOB = "08/08/2000" };

            _practitionerRepository.Setup(o => o.Create(It.IsAny<Practitioner>())).Returns(_practioner);
            _practitionerRepository.Setup(o => o.Read(It.IsAny<int>())).Returns(_practioner);
            _practitionerRepository.Setup(o => o.Update(It.IsAny<Practitioner>())).Returns(_practioner);
            _practitionerService = new PractitionerService(_practitionerRepository.Object);
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void GivenAPractitionerAccountExists_CreatePractitioner()
        {
            //Act
            var result = _practitionerService.Create(_practionerModel);

            //Assert
            Assert.That(result.PractitionerId, Is.EqualTo(1));

        }

        [Test]
        public void GivenAPractitionerAccountExists_DeletePractitioner()
        {
            //Act
            var result = _practitionerService.Delete(_practionerModel);

            //Assert
            Assert.That(result, Is.Null);

        }

        [Test]
        public void GivenAPractitionerAccountExists_UpdatePractitioner()
        {
            //Act
            var result = _practitionerService.Update(_practionerModel);

            //Assert
            Assert.That(result.LastName, Is.EqualTo("Surname"));

        }

        [Test]
        public void GivenAPractitionerAccountExists_ReadPractitioner()
        {
            //Act
            var result = _practitionerService.Read(_practionerModel.PractitionerId);

            //Assert
            Assert.That(result.PractitionerId, Is.EqualTo(1));

        }
    }
}
