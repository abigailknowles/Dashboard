using Moq;
using NUnit.Framework;
using PatientWarningApp.Api.Patient;
using PatientWarningApp.Api.Patient.Entities;
using PatientWarningApp.Api.Patient.Interfaces;
using PatientWarningApp.Api.Patient.Models;

namespace PatientWarningApp.Tests.PatientTests
{
    public class PatientServiceTests
    {
        private PatientService _service;
        private Mock<IPatientRepository> _repository;
        private PatientEntity _entity;
        private PatientModel _model;


        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IPatientRepository>();

            _entity = new PatientEntity() { PatientId=1, Id = 1, FirstName="Abigail", LastName="Surname", Title="Miss", Gender="Female",MobileNumber="01772318926",DOB= "08/08/2000" };
            _model = new PatientModel { PatientId=1, Id = 1, FirstName = "Abigail", LastName = "Surname", Title = "Miss", Gender = "Female", MobileNumber = "01772318926", DOB = "08/08/2000" };

            _repository.Setup(o => o.Create(It.IsAny<PatientEntity>())).Returns(_entity);
            _repository.Setup(o => o.Read(It.IsAny<int>())).Returns(_entity);
            _repository.Setup(o => o.Update(It.IsAny<PatientEntity>())).Returns(_entity);
            _service = new PatientService(_repository.Object);
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void GivenAPatientAccountExists_CreatePatient()
        {
            //Act
            var result = _service.Create(_model);

            //Assert
            Assert.That(result.PatientId, Is.EqualTo(1));

        }

        [Test]
        public void GivenAPatientAccountExists_DeletePatient()
        {
            //Act
            var result = _service.Delete(_model);

            //Assert
            Assert.That(result, Is.Null);

        }

        [Test]
        public void GivenAPatientAccountExists_UpdatePatient()
        {
            //Act
            var result = _service.Update(_model);

            //Assert
            Assert.That(result.LastName, Is.EqualTo("Surname"));

        }

        [Test]
        public void GivenAPatientAccountExists_ReadPatient()
        {
            //Act
            var result = _service.Read(_model.Id);

            //Assert
            Assert.That(result.PatientId, Is.EqualTo(1));

        }
    }
}
