using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PatientWarningApp.Api.Patient;
using PatientWarningApp.Api.Patient.Entities;
using PatientWarningApp.Api.Shared.Contexts;

namespace PatientWarningApp.Tests.PatientTests
{
    public class PatientRepoTests
    {
        private PatientRepository _repository;
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
            var entity = new PatientEntity() { 
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
            using var context = _context = new AppDbContext(_options);
            context.Patients.Add(entity);
            context.SaveChanges();
            _repository = new PatientRepository(context);

            var result = _repository.Create(entity);

            //Assert
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.FirstName, Is.EqualTo("Abbie"));
            Assert.That(result.LastName, Is.EqualTo("Knowles"));
        }

        [Test]
        public void GivenAnAccountExists_DeletePatientRecordById()
        {
            //Arrange
            var entity = new PatientEntity() { Id = 2 };

            //Act
            using (_context = new AppDbContext(_options))
            {
                _context.Patients.Add(entity);
                _context.SaveChanges();

                _repository = new PatientRepository(_context);

                var result = _repository.Delete(entity);
                var readResult = _repository.Read(entity.Id);

                //Assert
                Assert.That(result.Id, Is.EqualTo(2));
                Assert.That(readResult, Is.Null);
            }
        }

        [Test]
        public void GivenAnAccountExists_ReadPatientRecordById()
        {
            //Arrange
            var entity = new PatientEntity{ PatientId = 5 };

            using var context = new AppDbContext(_options);
            context.Patients.Add(entity);
            context.SaveChanges();
            var repository = new PatientRepository(context);
            
            //Act
            var result = repository.Read(entity.PatientId);

            //Assert
            Assert.That(result.PatientId, Is.EqualTo(5));
        }

        [Test]
        public void GivenAnAccountExists_UpdatePatientRecord()
        {
            //Arrange
            var entity = new PatientEntity()
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
            using var context = new AppDbContext(_options);
            context.Patients.Add(entity);
            context.SaveChanges();

            //Act
            var repository = new PatientRepository(context);

            entity.FirstName = "Abigail";

            repository.Update(entity);

            var result = repository.Read(entity.Id);
            //Assert
            Assert.That(result.Id, Is.EqualTo(7));
            Assert.That(result.FirstName, Is.EqualTo("Abigail"));
        }
    }
}
