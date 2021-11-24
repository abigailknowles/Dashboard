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
                context.PatientAccounts.Add(new PatientAccount { PatientAccountId = 1 });
                context.PatientAccounts.Add(new PatientAccount { PatientAccountId = 2 });
                context.PatientAccounts.Add(new PatientAccount { PatientAccountId = 3 });
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
            var patientAccount = new PatientAccount();

            //Act
            using (var context = new AppDbContext(_options))
            {
                _patientAccountRepository = new PatientAccountRepository(context);

                var result = _patientAccountRepository.Create(patientAccount);

                //Assert
                Assert.That(result.PatientAccountId, Is.EqualTo(4));
            }
        }

        [Test]
        public void GivenAnPatientAccount_DeleteReturnsEntity_WithIdAndPatientAccountIsDeleted()
        {
            //Arrange
            var patientAccount = new PatientAccount() { PatientAccountId = 2 };

            //Act
            using (var context = new AppDbContext(_options))
            {
                _patientAccountRepository = new PatientAccountRepository(context);

                var result = _patientAccountRepository.Delete(patientAccount);
                var readResult = _patientAccountRepository.Read(patientAccount.PatientAccountId);

                //Assert
                Assert.That(result.PatientAccountId, Is.EqualTo(2));
                Assert.That(readResult, Is.Null);
            }
        }

        [Test]
        public void GivenAnPatientAccountId_ReadReturnsEntity()
        {
            //Arrange
            var patientAccount = new PatientAccount() { PatientAccountId = 2 };

            //Act
            using (var context = new AppDbContext(_options))
            {
                _patientAccountRepository = new PatientAccountRepository(context);

                var readResult = _patientAccountRepository.Read(patientAccount.PatientAccountId);

                //Assert
                Assert.That(readResult.PatientAccountId, Is.EqualTo(2));
            }
        }

        [Test]
        public void GivenAnAccount_UpdateReturnsEntity_WithUpdatedValue()
        {
            //Arrange
            var account = new PatientAccount() { PatientAccountId = 2, Email = "example@example.com" };

            //Act
            using (var context = new AppDbContext(_options))
            {
                _patientAccountRepository = new PatientAccountRepository(context);

                var readResult = _patientAccountRepository.Update(account);

                //Assert
                Assert.That(readResult.PatientAccountId, Is.EqualTo(2));
            }
        }
    }
}