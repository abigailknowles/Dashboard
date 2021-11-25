using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PatientWarningApp.Data.DbContexts;
using PatientWarningApp.Data.Entities;
using PatientWarningApp.Data.Repositories;
using System;
using System.Collections.Generic;

namespace PatientWarningApp.Tests.DataTests
{
    public class PatientRepoTests
    {
        private PatientRepository patientRepository;
        private DbContextOptions<AppDbContext> _options;
        private AppDbContext _context;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
            .EnableSensitiveDataLogging()
            .UseInMemoryDatabase(databaseName: "PatientListDatabase")
            .Options;

        }

        [TearDown]
        public void TearDown()
        {
           
        }

        [Test]
        public void GivenAnAccountExists_CreatePatientRecord()
        {
            //Arrange
            var patient = new Patient() { 
                Id = 1,
                PatientId = 1,
                Title = "Miss",
                FirstName = "Abbie",
                LastName="Knowles",
                Gender="Female",
                DOB="08/08/2000",
                MobileNumber="01772818926"
                };

            //Act
            using (_context = new AppDbContext(_options))
            {
                _context.Patient.Add(patient);
                _context.SaveChanges();
                patientRepository = new PatientRepository(_context);

                var result = patientRepository.Create(patient);

                //Assert
                Assert.That(result.Id, Is.EqualTo(1));
                Assert.That(result.FirstName, Is.EqualTo("Abbie"));
                Assert.That(result.LastName, Is.EqualTo("Knowles"));
            }
        }

        [Test]
        public void GivenAnAccountExists_DeletePatientRecordById()
        {
            //Arrange
            var patient = new Patient() { Id = 2 };

            //Act
            using (_context = new AppDbContext(_options))
            {
                _context.Patient.Add(patient);
                _context.SaveChanges();

                patientRepository = new PatientRepository(_context);

                var result = patientRepository.Delete(patient);
                var readResult = patientRepository.Read(patient.Id);

                //Assert
                Assert.That(result.Id, Is.EqualTo(2));
                Assert.That(readResult, Is.Null);
            }
        }

        [Test]
        public void GivenAnAccountExists_ReadPatientRecordById()
        {
            //Arrange
            var patient = new Patient{ PatientId = 5 };

            using (var context = new AppDbContext(_options))
            {
                context.Patient.Add(patient);
                context.SaveChanges();

                //Act
                var patientRepository = new PatientRepository(context);

                var readResult = patientRepository.Read(patient.PatientId);

                //Assert
                Assert.That(readResult.PatientId, Is.EqualTo(5));
            }
        }

        [Test]
        public void GivenAnAccountExists_UpdatePatientRecord()
        {
            //Arrange
           
            var patient = new Patient()
            {
                Id = 7,
                PatientId = 7,
                Title = "Miss",
                FirstName = "Abbie",
                LastName = "Knowles",
                Gender = "Female",
                DOB = "08/08/2000",
                MobileNumber = "01772818926",
            };
            //Act
            using (var context = new AppDbContext(_options))
            {
                context.Patient.Add(patient);
                context.SaveChanges();

                //Act
                var patientRepository = new PatientRepository(context);


                patient.FirstName = "Abigail";

                var readResult = patientRepository.Update(patient);

                var result = patientRepository.Read(patient.Id);
                //Assert
                Assert.That(result.Id, Is.EqualTo(7));
                Assert.That(result.FirstName, Is.EqualTo("Abigail"));
            }
        
        }
    }
}
