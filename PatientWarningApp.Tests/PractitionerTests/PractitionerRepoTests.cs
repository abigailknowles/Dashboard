using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PatientWarningApp.Api.Practitioner;
using PatientWarningApp.Api.Practitioner.Entities;
using PatientWarningApp.Api.Shared.Contexts;

namespace PatientWarningApp.Tests.PractitionerTests
{
    public class PractitionerRepositoryTests
    {
        private PractitionerRepository _repository;
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
            var entity = new PractitionerEntity() { 
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
            using var context = new AppDbContext(_options);
            _repository = new PractitionerRepository(context);

            var result = _repository.Create(entity);

            //Assert
            Assert.That(result.Id, Is.EqualTo(1));
                Assert.That(result.FirstName, Is.EqualTo("Abbie"));
                Assert.That(result.LastName, Is.EqualTo("Knowles"));
            }
        
        [Test]
        public void GivenAnAccountExists_DeletePractitionerRecordById()
        {
            //Arrange
            var practitioner = new PractitionerEntity() { Id = 2 };

            //Act
            using (_context = new AppDbContext(_options))
            {
                _context.Practitioners.Add(practitioner);
                _context.SaveChanges();

                _repository = new PractitionerRepository(_context);

                var result = _repository.Delete(practitioner);
                var readResult = _repository.Read(practitioner.Id);

                //Assert
                Assert.That(result.Id, Is.EqualTo(2));
                Assert.That(readResult, Is.Null);
            }
        }

        [Test]
        public void GivenAnAccountExists_ReadPractitionerRecordById()
        {
            //Arrange
            var practitioner = new PractitionerEntity{ PractitionerId = 5 };

            using (var context = new AppDbContext(_options))
            {
                context.Practitioners.Add(practitioner);
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
           
            var practitioner = new PractitionerEntity()
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
                context.Practitioners.Add(practitioner);
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
