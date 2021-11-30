using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PatientWarningApp.Api.MedicalRecords;
using PatientWarningApp.Api.MedicalRecords.Entities;
using PatientWarningApp.Api.Shared.Contexts;

namespace PatientWarningApp.Tests.MedicalRecordTests
{
    public class MedicalRecordRepositoryTests
    {
        private MedicalRecordRepository _repository;
        private DbContextOptions<AppDbContext> _options;
        private AppDbContext _context;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
            .EnableSensitiveDataLogging()
            .UseInMemoryDatabase(databaseName: "MedicalRecordListDatabase")
            .Options;

        }

        [TearDown]
        public void TearDown()
        {
           
        }

        [Test]
        public void GivenValidMedicalRecord_CreateMedicalRecord()
        {
            //Arrange
            var entity = new MedicalRecordEntity() { 
                Id = 1,
                SeizureTimes= "Mid-day",
                SeizureFrequencies = "Daily",
                SeizureTriggers = "Flashing lights",
                SeizureTypes="Fits",
                StartDate = "08/08/2000",
                SideEffects="Headaches",
                Notes= "Badly impacting mental health"
                };

            using var context = _context = new AppDbContext(_options);
            _context.MedicalRecords.Add(entity);
            _context.SaveChanges();
            _repository = new MedicalRecordRepository(_context);
            
            //Act
            var result = _repository.Create(entity);

            //Assert
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.SeizureFrequencies, Is.EqualTo("Daily"));
        }

        [Test]
        public void GivenMedicalRecordExists_DeleteMedicalRecordById()
        {
            //Arrange
            var entity = new MedicalRecordEntity() { Id = 2 };
            using var context = _context = new AppDbContext(_options);
            _context.MedicalRecords.Add(entity);
            _context.SaveChanges();
            _repository = new MedicalRecordRepository(_context);

            //Act
            var result = _repository.Delete(entity);
            var readResult = _repository.Read(entity.Id);

            //Assert
            Assert.That(result.Id, Is.EqualTo(2));
            Assert.That(readResult, Is.Null);
        }

        [Test]
        public void GivenMedicalRecordExists_ReadMedicalRecordById()
        {
            //Arrange
            var entity = new MedicalRecordEntity{ Id = 5 };

            using var context = new AppDbContext(_options);
            context.MedicalRecords.Add(entity);
            context.SaveChanges();

            //Act
            var medicalRecordRepository = new MedicalRecordRepository(context);
            var readResult = medicalRecordRepository.Read(entity.Id);

            //Assert
            Assert.That(readResult.Id, Is.EqualTo(5));
        }

        [Test]
        public void GivenMedicalRecordExists_UpdateMedicalRecord()
        {
            //Arrange
            var entity = new MedicalRecordEntity()
            {
                Id = 7,
                SeizureTimes = "Mid-day",
                SeizureFrequencies = "Daily",
                SeizureTriggers = "Flashing lights",
                SeizureTypes = "Fits",
                StartDate = "08/08/2000",
                SideEffects = "Headaches",
                Notes = "Badly impacting mental health"
            };

            //Act
            using var context = new AppDbContext(_options);
            context.MedicalRecords.Add(entity);
            context.SaveChanges();
            var medicalRecordRepository = new MedicalRecordRepository(context);
            entity.SeizureFrequencies = "Weekly";
            //Act

            medicalRecordRepository.Update(entity);
            var result = medicalRecordRepository.Read(entity.Id);

            //Assert
            Assert.That(result.Id, Is.EqualTo(7));
            Assert.That(result.SeizureFrequencies, Is.EqualTo("Weekly"));
        }
    }
}
