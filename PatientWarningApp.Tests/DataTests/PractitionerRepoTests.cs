using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PatientWarningApp.Data.DbContexts;
using PatientWarningApp.Data.Entities;
using PatientWarningApp.Data.Repositories;

namespace PatientWarningApp.Tests.DataTests
{
    public class PractitionerAccountRepositoryTests
    {
        private PractitionerAccountRepository _accountRepository;
        private DbContextOptions<AppDbContext> _options;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "PractitionerAccountListDatabase")
            .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new AppDbContext(_options))
            {
                context.PractitionerAccounts.Add(new PractitionerAccount { Id = 1 });
                context.PractitionerAccounts.Add(new PractitionerAccount { Id = 2 });
                context.PractitionerAccounts.Add(new PractitionerAccount { Id = 3 });
                context.SaveChanges();
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var context = new AppDbContext(_options))
            {
                context.PractitionerAccounts.RemoveRange(context.PractitionerAccounts);
                context.SaveChanges();
            }
        }

        [Test]
        public void GivenAnAccount_CreateReturnsEntity_WithId()
        {
            //Arrange
            var account = new PractitionerAccount();

            //Act
            using (var context = new AppDbContext(_options))
            {
                _accountRepository = new PractitionerAccountRepository(context);

                var result = _accountRepository.Create(account);

                //Assert
                Assert.That(result.Id, Is.EqualTo(4));
            }
        }

        [Test]
        public void GivenAnAccount_DeleteReturnsEntity_WithIdAndAccountIsDeleted()
        {
            //Arrange
            var account = new PractitionerAccount() { Id = 2 };

            //Act
            using (var context = new AppDbContext(_options))
            {
                _accountRepository = new PractitionerAccountRepository(context);

                var result = _accountRepository.Delete(account);
                var readResult = _accountRepository.Read(account);

                //Assert
                Assert.That(result.Id, Is.EqualTo(2));
                Assert.That(readResult, Is.Null);
            }
        }

        [Test]
        public void GivenAnAccountId_ReadReturnsEntity()
        {
            //Arrange
            var account = new PractitionerAccount() { Id = 2 };

            //Act
            using (var context = new AppDbContext(_options))
            {
                _accountRepository = new PractitionerAccountRepository(context);

                var readResult = _accountRepository.Read(account);

                //Assert
                Assert.That(readResult.Id, Is.EqualTo(2));
            }
        }

        [Test]
        public void GivenAnAccount_UpdateReturnsEntity_WithUpdatedValue()
        {
            //Arrange
            var account = new PractitionerAccount() { Id = 2, Email = "example@example.com" };

            //Act
            using (var context = new AppDbContext(_options))
            {
                _accountRepository = new PractitionerAccountRepository(context);

                var readResult = _accountRepository.Update(account);

                //Assert
                Assert.That(readResult.Id, Is.EqualTo(2));
            }
        }
    }
}
