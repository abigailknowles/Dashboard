using Moq;
using NUnit.Framework;
using PatientWarningApp.Data.Entities;
using PatientWarningApp.Data.Repositories;
using PatientWarningApp.Services.Models;
using PatientWarningApp.Services.PatientServices;

namespace PatientWarningApp.Tests.ServiceTests
{
    public class PatientService_Tests
    {
        private PatientService _patientService;
        private Mock<IPatientRepository> _patientRepository;
        private Patient _patient;
        private PatientModel _patientModel;


        [SetUp]
        public void Setup()
        {
            _patientRepository = new Mock<IPatientRepository>();

            _patient = new Patient() { PatientId=1, Id = 1, FirstName="Abigail", LastName="Surname", Title="Miss", Gender="Female",MobileNumber="01772318926",DOB= "08/08/2000" };
            _patientModel = new PatientModel { PatientId=1, Id = 1, FirstName = "Abigail", LastName = "Surname", Title = "Miss", Gender = "Female", MobileNumber = "01772318926", DOB = "08/08/2000" };

            _patientRepository.Setup(o => o.Create(It.IsAny<Patient>())).Returns(_patient);
            _patientRepository.Setup(o => o.Read(It.IsAny<int>())).Returns(_patient);
            _patientRepository.Setup(o => o.Update(It.IsAny<Patient>())).Returns(_patient);
            _patientService = new PatientService(_patientRepository.Object);
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void GivenAPatientAccountExists_CreatePatient()
        {
            //Act
            var result = _patientService.Create(_patientModel);

            //Assert
            Assert.That(result.PatientId, Is.EqualTo(1));

        }

        [Test]
        public void GivenAPatientAccountExists_DeletePatient()
        {
            //Act
            var result = _patientService.Delete(_patientModel);

            //Assert
            Assert.That(result, Is.Null);

        }

        [Test]
        public void GivenAPatientAccountExists_UpdatePatient()
        {
            //Act
            var result = _patientService.Update(_patientModel);

            //Assert
            Assert.That(result.LastName, Is.EqualTo("Surname"));

        }

        [Test]
        public void GivenAPatientAccountExists_ReadPatient()
        {
            //Act
            var result = _patientService.Read(_patientModel.Id);

            //Assert
            Assert.That(result.PatientId, Is.EqualTo(1));

        }
    }
}
