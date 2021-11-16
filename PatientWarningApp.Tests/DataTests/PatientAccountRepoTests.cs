using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PatientWarningApp.Data.DbContexts;
using PatientWarningApp.Data.Entities;
using PatientWarningApp.Data.Repositories;

namespace PatientWarningApp.Tests.DataTests
{
    public class PatientAccountRepoTests
    {
        private PatientAccountRepository _patientAccountRepository;
        private DbContextOptions<AppDbContext> _options;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "PatientAccountListDatabase")
            .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new AppDbContext(_options))
            {
                context.PatientAccounts.Add(new PatientAccount { Id = 1 });
                context.PatientAccounts.Add(new PatientAccount { Id = 2 });
                context.PatientAccounts.Add(new PatientAccount { Id = 3 });
                context.SaveChanges();
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var context = new AppDbContext(_options))
            {
                context.PatientAccounts.RemoveRange(context.PatientAccounts);
                context.SaveChanges();
            }
        }

        [Test]
        public void GivenAnPatientAccount_CreateReturnsEntity_WithId()
        {
            //Arrange
            var PatientAccount = new PatientAccount();

            //Act
            using (var context = new AppDbContext(_options))
            {
                _patientAccountRepository = new PatientAccountRepository(context);

                var result = _patientAccountRepository.Create(PatientAccount);

                //Assert
                Assert.That(result.Id, Is.EqualTo(4));
            }
        }

        [Test]
        public void GivenAnPatientAccount_DeleteReturnsEntity_WithIdAndPatientAccountIsDeleted()
        {
            //Arrange
            var PatientAccount = new PatientAccount() { Id = 2 };

            //Act
            using (var context = new AppDbContext(_options))
            {
                _patientAccountRepository = new PatientAccountRepository(context);

                var result = _patientAccountRepository.Delete(PatientAccount);
                var readResult = _patientAccountRepository.Read(PatientAccount);

                //Assert
                Assert.That(result.Id, Is.EqualTo(2));
                Assert.That(readResult, Is.Null);
            }
        }

        [Test]
        public void GivenAnPatientAccountId_ReadReturnsEntity()
        {
            //Arrange
            var PatientAccount = new PatientAccount() { Id = 2 };

            //Act
            using (var context = new AppDbContext(_options))
            {
                _patientAccountRepository = new PatientAccountRepository(context);

                var readResult = _patientAccountRepository.Read(PatientAccount);

                //Assert
                Assert.That(readResult.Id, Is.EqualTo(2));
            }
        }

        [Test]
        public void GivenAnAccount_UpdateReturnsEntity_WithUpdatedValue()
        {
            //Arrange
            var account = new PatientAccount() { Id = 2, Email = "example@example.com" };

            //Act
            using (var context = new AppDbContext(_options))
            {
                _patientAccountRepository = new PatientAccountRepository(context);

                var readResult = _patientAccountRepository.Update(account);

                //Assert
                Assert.That(readResult.Id, Is.EqualTo(2));
            }
        }
    }
}