using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PatientWarningApp.Api.PatientAccount;
using PatientWarningApp.Api.PatientAccount.Entities;
using PatientWarningApp.Api.Shared.Contexts;

namespace PatientWarningApp.Tests.PatientAccountTests
{
    public class PatientAccountRepoTests
    {
        private PatientAccountRepository _repository;
        private DbContextOptions<AppDbContext> _options;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "PatientAccountListDatabase")
            .Options;

            // Insert seed data into the database using one instance of the context
            using var context = new AppDbContext(_options);
            context.PatientAccounts.Add(new PatientAccountEntity { PatientAccountId = 1 });
            context.PatientAccounts.Add(new PatientAccountEntity { PatientAccountId = 2 });
            context.PatientAccounts.Add(new PatientAccountEntity { PatientAccountId = 3 });
            context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            using var context = new AppDbContext(_options);
            context.PatientAccounts.RemoveRange(context.PatientAccounts);
            context.SaveChanges();
        }

        [Test]
        public void GivenAnPatientAccount_CreateReturnsEntity_WithId()
        {
            //Arrange
            var entity = new PatientAccountEntity();

            //Act
            using var context = new AppDbContext(_options);
            _repository = new PatientAccountRepository(context);

            var result = _repository.Create(entity);

            //Assert
            Assert.That(result.PatientAccountId, Is.EqualTo(4));
        }

        [Test]
        public void GivenAnPatientAccount_DeleteReturnsEntity_WithIdAndPatientAccountIsDeleted()
        {
            //Arrange
            var entity = new PatientAccountEntity() { PatientAccountId = 2 };

            //Act
            using var context = new AppDbContext(_options);
            _repository = new PatientAccountRepository(context);

            var result = _repository.Delete(entity);
            var readResult = _repository.Read(entity.PatientAccountId);

            //Assert
            Assert.That(result.PatientAccountId, Is.EqualTo(2));
            Assert.That(readResult, Is.Null);
        }

        [Test]
        public void GivenAnPatientAccountId_ReadReturnsEntity()
        {
            //Arrange
            var entity = new PatientAccountEntity() { PatientAccountId = 2 };

            //Act
            using var context = new AppDbContext(_options);
            _repository = new PatientAccountRepository(context);

            var readResult = _repository.Read(entity.PatientAccountId);

            //Assert
            Assert.That(readResult.PatientAccountId, Is.EqualTo(2));
        }

        [Test]
        public void GivenAnAccount_UpdateReturnsEntity_WithUpdatedValue()
        {
            //Arrange
            var entity = new PatientAccountEntity() { PatientAccountId = 2, Email = "example@example.com" };

            //Act
            using var context = new AppDbContext(_options);
            _repository = new PatientAccountRepository(context);

            var readResult = _repository.Update(entity);

            //Assert
            Assert.That(readResult.PatientAccountId, Is.EqualTo(2));
        }
    }
}