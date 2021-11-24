using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PatientWarningApp.Data.DbContexts;
using PatientWarningApp.Data.Entities;
using PatientWarningApp.Data.Repositories;
using System;
using System.Collections.Generic;

namespace PatientWarningApp.Tests.DataTests
{
    public class PractitionerRepositoryTests
    {
        private PractitionerRepository _practitionerRepository;
        private DbContextOptions<AppDbContext> _options;
        private AppDbContext _context;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
            .EnableSensitiveDataLogging()
            .UseInMemoryDatabase(databaseName: "PractitionerListDatabase")
            .Options;

        }

        [TearDown]
        public void TearDown()
        {
           
        }

        [Test]
        public void GivenAnAccountExists_CreatePractitionerRecord()
        {
            //Arrange
            var practitioner = new Practitioner() { 
                Id = 1,
                PractitionerId = 1,
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
                _context.Practitioner.Add(practitioner);
                _context.SaveChanges();
                _practitionerRepository = new PractitionerRepository(_context);

                var result = _practitionerRepository.Create(practitioner);

                //Assert
                Assert.That(result.Id, Is.EqualTo(1));
                Assert.That(result.FirstName, Is.EqualTo("Abbie"));
                Assert.That(result.LastName, Is.EqualTo("Knowles"));
            }
        }

        [Test]
        public void GivenAnAccountExists_DeletePractitionerRecordById()
        {
            //Arrange
            var practitioner = new Practitioner() { Id = 2 };

            //Act
            using (_context = new AppDbContext(_options))
            {
                _context.Practitioner.Add(practitioner);
                _context.SaveChanges();

                _practitionerRepository = new PractitionerRepository(_context);

                var result = _practitionerRepository.Delete(practitioner);
                var readResult = _practitionerRepository.Read(practitioner.Id);

                //Assert
                Assert.That(result.Id, Is.EqualTo(2));
                Assert.That(readResult, Is.Null);
            }
        }

        [Test]
        public void GivenAnAccountExists_ReadPractitionerRecordById()
        {
            //Arrange
            var practitioner = new Practitioner{ PractitionerId = 5 };

            using (var context = new AppDbContext(_options))
            {
                context.Practitioner.Add(practitioner);
                context.SaveChanges();

                //Act
                var practitionerRepository = new PractitionerRepository(context);

                var readResult = practitionerRepository.Read(practitioner.PractitionerId);

                //Assert
                Assert.That(readResult.PractitionerId, Is.EqualTo(5));
            }
        }

        [Test]
        public void GivenAnAccountExists_UpdatePractitionerRecord()
        {
            //Arrange
           
            var practitioner = new Practitioner()
            {
                Id = 7,
                PractitionerId = 7,
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
                context.Practitioner.Add(practitioner);
                context.SaveChanges();

                //Act
                var practitionerRepository = new PractitionerRepository(context);


                practitioner.FirstName = "Abigail";

                var readResult = practitionerRepository.Update(practitioner);

                var result = practitionerRepository.Read(practitioner.Id);
                //Assert
                Assert.That(result.Id, Is.EqualTo(7));
                Assert.That(result.FirstName, Is.EqualTo("Abigail"));
            }
        
        }
    }
}
