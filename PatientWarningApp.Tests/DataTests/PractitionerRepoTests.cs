using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PatientWarningApp.Data.DbContexts;
using PatientWarningApp.Data.Entities;
using PatientWarningApp.Data.Repositories;
using System.Collections.Generic;

namespace PatientWarningApp.Tests.DataTests
{
    public class PractitionerAccountRepositoryTests
    {
        private PractitionerAccountRepository _accountRepository;
        private DbContextOptions<AppDbContext> _options;
        private AppDbContext _context;

        private List<PatientAccount> _patientSetOne;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
            .EnableSensitiveDataLogging()
            .UseInMemoryDatabase(databaseName: "PractitionerAccountListDatabase")
            .Options;

            _patientSetOne = new List<PatientAccount> {
                            new PatientAccount
                            {
                                Id = 11,
                                Email = "Patient1@example.com",
                                IsAdmin = false
                            },
                            new PatientAccount
                            {
                                Id = 12,
                                Email = "Patient2@example.com",
                                IsAdmin = false
                            }
                        };
        }

        [TearDown]
        public void TearDown()
        {
            using (_context = new AppDbContext(_options))
            {
                _context.PatientAccounts.RemoveRange(_context.PatientAccounts);
                _context.PractitionerAccounts.RemoveRange(_context.PractitionerAccounts);
                _context.SaveChanges();
            }
        }

        [Test]
        public void GivenAnAccount_CreateReturnsEntity_WithId()
        {
            //Arrange
            var account = new PractitionerAccount() { Id = 4 };

            //Act
            using (_context = new AppDbContext(_options))
            {
                _context.PractitionerAccounts.Add(account);
                _context.SaveChanges();
                _accountRepository = new PractitionerAccountRepository(_context);

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
            using (_context = new AppDbContext(_options))
            {
                _context.PractitionerAccounts.Add(account);
                _context.SaveChanges();

                _accountRepository = new PractitionerAccountRepository(_context);

                var result = _accountRepository.Delete(account);
                var readResult = _accountRepository.Read(account.Id);

                //Assert
                Assert.That(result.Id, Is.EqualTo(2));
                Assert.That(readResult, Is.Null);
            }
        }

        [Test]
        public void GivenAnAccountId_ReadReturnsEntity()
        {
            //Arrange
            var pract = new PractitionerAccount { Id = 1 };

            using (_context = new AppDbContext(_options))
            {
                _context.PractitionerAccounts.Add(pract);
                _context.SaveChanges();

                //Act
                var account = _context.PractitionerAccounts.Find(1);
                _accountRepository = new PractitionerAccountRepository(_context);

                var readResult = _accountRepository.Read(account.Id);

                //Assert
                Assert.That(readResult.Id, Is.EqualTo(1));
            }
        }

        [Test]
        public void GivenAnAccount_UpdateReturnsEntity_WithUpdatedValue()
        {
            //Arrange
            var pract = new PractitionerAccount() { Id = 2, Email = "example@example.com" };

            //Act
            using (_context = new AppDbContext(_options))
            {
                _context.PractitionerAccounts.Add(pract);
                _context.SaveChanges();

                //Act
                _accountRepository = new PractitionerAccountRepository(_context);


                pract.Password = "password";

                var readResult = _accountRepository.Update(pract);

                var result = _accountRepository.Read(pract.Id);
                //Assert
                Assert.That(result.Id, Is.EqualTo(2));
                Assert.That(result.Password, Is.EqualTo("password"));
            }
        }

        [Test]
        public void GivenAnAccountId_ReadReturnsEntity_WithTwoPatientAccounts()
        {
            //Arrange
            var pract = new PractitionerAccount { Id = 1 };
            _patientSetOne[0].PractitionerId = pract.Id;
            _patientSetOne[1].PractitionerId = pract.Id;
            pract.PatientAccounts = _patientSetOne;

            using (_context = new AppDbContext(_options))
            {
                _context.PractitionerAccounts.Add(pract);
                _context.SaveChanges();

                //Act
                var account = _context.PractitionerAccounts.Find(1);
                _accountRepository = new PractitionerAccountRepository(_context);

                var readResult = _accountRepository.Read(account.Id);

                //Assert
                Assert.That(readResult.Id, Is.EqualTo(1));
                Assert.That(readResult.PatientAccounts.Count, Is.EqualTo(2));
            }
        }
        
        [Test]
        public void GivenAnAccountUsername_And_Password_ReadReturnsEntity()
        {
            //Arrange
            var pract = new PractitionerAccount { Username = "Abbie", Password="password" };

            using (_context = new AppDbContext(_options))
            {
                _context.PractitionerAccounts.Add(pract);
                _context.SaveChanges();

                //Act
                _accountRepository = new PractitionerAccountRepository(_context);

                var readResult = _accountRepository.ReadByUsernameAndPassword(pract);

                //Assert
                Assert.That(readResult.Username, Is.EqualTo("Abbie"));
                Assert.That(readResult.Password, Is.EqualTo("password"));

            }
        }
    }
}
