using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PatientWarningApp.Data.DbContexts;
using PatientWarningApp.Data.Entities;
using PatientWarningApp.Data.Repositories;
using PatientWarningApp.Services.Models;

namespace PatientWarningApp.Tests.DataTests
{
    public class MedicalRecordRepositoryTests
    {
        private MedicalRecordRepository _medicalRecordRepository;
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
            var medicalRecord = new MedicalRecord() { 
                Id = 1,
                SeizureTimes= "Mid-day",
                SeizureFrequencies = "Daily",
                SeizureTriggers = "Flashing lights",
                SeizureTypes="Fits",
                StartDate = "08/08/2000",
                SideEffects="Headaches",
                Notes= "Badly impacting mental health"
                };

            //Act
            using (_context = new AppDbContext(_options))
            {
                _context.MedicalRecords.Add(medicalRecord);
                _context.SaveChanges();
                _medicalRecordRepository = new MedicalRecordRepository(_context);

                var result = _medicalRecordRepository.Create(medicalRecord);

                //Assert
                Assert.That(result.Id, Is.EqualTo(1));
                Assert.That(result.SeizureFrequencies, Is.EqualTo("Daily"));
            }
        }

        [Test]
        public void GivenMedicalRecordExists_DeleteMedicalRecordById()
        {
            //Arrange
            var medicalRecord = new MedicalRecord() { Id = 2 };

            //Act
            using (_context = new AppDbContext(_options))
            {
                _context.MedicalRecords.Add(medicalRecord);
                _context.SaveChanges();

                _medicalRecordRepository = new MedicalRecordRepository(_context);

                var result = _medicalRecordRepository.Delete(medicalRecord);
                var readResult = _medicalRecordRepository.Read(medicalRecord.Id);

                //Assert
                Assert.That(result.Id, Is.EqualTo(2));
                Assert.That(readResult, Is.Null);
            }
        }

        [Test]
        public void GivenMedicalRecordExists_ReadMedicalRecordById()
        {
            //Arrange
            var medicalRecord = new MedicalRecord{ Id = 5 };

            using (var context = new AppDbContext(_options))
            {
                context.MedicalRecords.Add(medicalRecord);
                context.SaveChanges();

                //Act
                var medicalRecordRepository = new MedicalRecordRepository(context);

                var readResult = medicalRecordRepository.Read(medicalRecord.Id);

                //Assert
                Assert.That(readResult.Id, Is.EqualTo(5));
            }
        }

        [Test]
        public void GivenMedicalRecordExists_UpdateMedicalRecord()
        {
            //Arrange
            var medicalRecord = new MedicalRecord()
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
            using (var context = new AppDbContext(_options))
            {
                context.MedicalRecords.Add(medicalRecord);
                context.SaveChanges();

                //Act
                var medicalRecordRepository = new MedicalRecordRepository(context);


                medicalRecord.SeizureFrequencies = "Weekly";

                var readResult = medicalRecordRepository.Update(medicalRecord);

                var result = medicalRecordRepository.Read(medicalRecord.Id);
                //Assert
                Assert.That(result.Id, Is.EqualTo(7));
                Assert.That(result.SeizureFrequencies, Is.EqualTo("Weekly"));
            }
        
        }
    }
}
