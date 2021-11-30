using Moq;
using NUnit.Framework;
using PatientWarningApp.Api.Practitioner;
using PatientWarningApp.Api.Practitioner.Entities;
using PatientWarningApp.Api.Practitioner.Interfaces;
using PatientWarningApp.Api.Practitioner.Models;

namespace PatientWarningApp.Tests.PractitionerTests
{
    public class PractitionerServiceTests
    {
        private PractitionerService _service;
        private Mock<IPractitionerRepository> _repository;
        private PractitionerEntity _entity;
        private PractitionerModel _model;


        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IPractitionerRepository>();

            _entity = new PractitionerEntity() { PractitionerId=1, Id = 1, FirstName="Abigail", LastName="Surname", Title="Miss", Gender="Female",MobileNumber="01772318926",DOB= "08/08/2000" };
            _model = new PractitionerModel { PractitionerId = 1, Id = 1, FirstName = "Abigail", LastName = "Surname", Title = "Miss", Gender = "Female", MobileNumber = "01772318926", DOB = "08/08/2000" };

            _repository.Setup(o => o.Create(It.IsAny<PractitionerEntity>())).Returns(_entity);
            _repository.Setup(o => o.Read(It.IsAny<int>())).Returns(_entity);
            _repository.Setup(o => o.Update(It.IsAny<PractitionerEntity>())).Returns(_entity);
            _service = new PractitionerService(_repository.Object);
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void GivenAPractitionerAccountExists_CreatePractitioner()
        {
            //Act
            var result = _service.Create(_model);

            //Assert
            Assert.That(result.PractitionerId, Is.EqualTo(1));

        }

        [Test]
        public void GivenAPractitionerAccountExists_DeletePractitioner()
        {
            //Act
            var result = _service.Delete(_model);

            //Assert
            Assert.That(result, Is.Null);

        }

        [Test]
        public void GivenAPractitionerAccountExists_UpdatePractitioner()
        {
            //Act
            var result = _service.Update(_model);

            //Assert
            Assert.That(result.LastName, Is.EqualTo("Surname"));

        }

        [Test]
        public void GivenAPractitionerAccountExists_ReadPractitioner()
        {
            //Act
            var result = _service.Read(_model.PractitionerId);

            //Assert
            Assert.That(result.PractitionerId, Is.EqualTo(1));

        }
    }
}
