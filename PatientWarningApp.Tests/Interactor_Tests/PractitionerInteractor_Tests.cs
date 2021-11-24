using Moq;
using NUnit.Framework;
using PatientWarningApp.Api.Interactors;
using PatientWarningApp.Services;
using PatientWarningApp.Services.Models;
using PatientWarningApp.Services.PatientServices;
using System.Collections.Generic;
using System.Linq;

namespace PatientWarningApp.Tests.Interactor_Tests
{
    public class PractitionerInteractor_Tests
    {
        private PractitionerInteractor _interactor;

        private Mock<IPractitionerAccountService> _practitionerService;
        private Mock<IPatientAccountService> _patientService;

        [SetUp]
        public void Setup()
        {
            _practitionerService = new Mock<IPractitionerAccountService>();
            _patientService = new Mock<IPatientAccountService>();
            _patientService.Setup(o => o.Update(It.IsAny<PatientAccountModel>())).Returns(new PatientAccountModel { });
            _patientService.Setup(o => o.ReadAll()).Returns(new List<PatientAccountModel>() { 
                new PatientAccountModel
                {
                    Id = 1,
                    PractitionerId = 1
                },
                new PatientAccountModel()
                {
                    Id = 2,
                    Email = "",
                    Password = "password",
                    PractitionerId = 1
                },
                new PatientAccountModel
                {
                    Id = 3,
                    PractitionerId = 1
                }
            });
            _practitionerService.Setup(o => o.Read(It.IsAny<int>())).Returns(new PractitionerAccountModel { });

            _interactor = new PractitionerInteractor(_practitionerService.Object, _patientService.Object);

        }

        [Test]
        public void AddPatientToPractitionerAccount()
        {
            var practitioner = new PractitionerAccountModel { 
                Id = 1, 
                PatientAccounts = new List<PatientAccountModel> {
                    new PatientAccountModel
                    {
                        Id = 1,
                        PractitionerId = 1
                    }
                } 
            };

            var result = _interactor.AddPatientToPractitionerAccount(practitioner);

            Assert.That(result.PatientAccounts[0].Id, Is.EqualTo(1));
        }
    }
}
