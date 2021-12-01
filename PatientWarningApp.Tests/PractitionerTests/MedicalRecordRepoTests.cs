using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PatientWarningApp.Api.MedicalRecords;
using PatientWarningApp.Api.MedicalRecords.Entities;
using PatientWarningApp.Api.Shared.Contexts;

namespace PatientWarningApp.Tests.DataTests
{
    public class MedicalRecordRepositoryTests
    {
        private MedicalRecordRepository _medicalRecordRepository;
        private DbContextOptions<AppDbContext> _options;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
        .UseInMemoryDatabase(databaseName: "PatientAccountListDatabase")
        .Options;

            // Insert seed data into the database using one instance of the context
            using var context = new AppDbContext(_options);
            context.MedicalRecords.Add(new MedicalRecordEntity { Id = 1 });
            context.MedicalRecords.Add(new MedicalRecordEntity { Id = 2 });
            context.MedicalRecords.Add(new MedicalRecordEntity { Id = 3 });
            context.SaveChanges();
        }
        [TearDown]
        public void TearDown()
        {
           
        }

        [Test]
        public void GivenValidMedicalRecord_CreateMedicalRecord()
        {
            //Arrange
            var entity = new MedicalRecordEntity()
            {
                Id = 4,
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
            _medicalRecordRepository = new MedicalRecordRepository(context);

            var result = _medicalRecordRepository.Create(entity);

            //Assert
            Assert.That(result.Id, Is.EqualTo(4));
        }

        [Test]
        public void GivenMedicalRecordExists_DeleteMedicalRecordById()
        {
            //Arrange
            var entity = new MedicalRecordEntity() { Id = 2 };

            //Act
            using var context = new AppDbContext(_options);
            _medicalRecordRepository = new MedicalRecordRepository(context);

            var result = _medicalRecordRepository.Delete(entity);
            var readResult = _medicalRecordRepository.Read(entity.Id);

            //Assert
            Assert.That(result.Id, Is.EqualTo(2));
            Assert.That(readResult, Is.Null);
    }
        
        [Test]
        public void GivenMedicalRecordExists_ReadMedicalRecordById()
        {
        //Arrange
        var entity = new MedicalRecordEntity() { Id = 2 };

        //Act
        using var context = new AppDbContext(_options);
        _medicalRecordRepository = new MedicalRecordRepository(context);

        var readResult = _medicalRecordRepository.Read(entity.Id);

        //Assert
        Assert.That(readResult.Id, Is.EqualTo(2));
    }
        
        [Test]
        public void GivenMedicalRecordExists_UpdateMedicalRecord()
        {
            //Arrange
            var entity = new MedicalRecordEntity() { Id = 2, StartDate = "08/08/2000", Notes="Effecting mental health", SideEffects="Headaches", SeizureFrequencies="Twice a day", SeizureTimes="In the evening", SeizureTriggers="Flashing lights", SeizureTypes="Fits" };

            //Act
            using var context = new AppDbContext(_options);
            _medicalRecordRepository = new MedicalRecordRepository(context);

            var readResult = _medicalRecordRepository.Update(entity);

            //Assert
            Assert.That(readResult.Id, Is.EqualTo(2));
        }
        
        }
    }
