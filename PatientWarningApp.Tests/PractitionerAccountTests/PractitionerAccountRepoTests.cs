using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PatientWarningApp.Api.PatientAccount;
using PatientWarningApp.Api.PatientAccount.Entities;
using PatientWarningApp.Api.PractitionerAccount;
using PatientWarningApp.Api.PractitionerAccount.Entities;
using PatientWarningApp.Api.Shared.Contexts;

namespace PatientWarningApp.Tests.PractitionerAccountTests
{
    public class PractitionerAccountRepositoryTests
    {
        private PractitionerAccountRepository _repository;
        private DbContextOptions<AppDbContext> _options;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
            .EnableSensitiveDataLogging()
            .UseInMemoryDatabase(databaseName: "PractitionerAccountListDatabase")
            .Options;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void GivenAnAccount_CreateReturnsEntity_WithId()
        {
            //Arrange
            var entity = new PractitionerAccountEntity();
            using var context = new AppDbContext(_options);
            _repository = new PractitionerAccountRepository(context);
            
            //Act
            var result = _repository.Create(entity);

            //Assert
            Assert.That(result.PractitionerAccountId, Is.EqualTo(1));
        }

        [Test]
        public void GivenAnAccount_DeleteReturnsEntity_WithIdAndAccountIsDeleted()
        {
            //Arrange
            var entity = new PractitionerAccountEntity() { PractitionerAccountId = 2 };
            using var context = new AppDbContext(_options);
            context.PractitionerAccounts.Add(entity);
            context.SaveChanges();
            _repository = new PractitionerAccountRepository(context);
            
            //Act
            var result = _repository.Delete(entity);
            var readResult = _repository.Read(entity.PractitionerAccountId);

            //Assert
            Assert.That(result.PractitionerAccountId, Is.EqualTo(entity.PractitionerAccountId));
            Assert.That(readResult, Is.Null);
        }

        [Test]
        public void GivenAnAccountId_ReadReturnsEntity()
        {
            //Arrange
            var entity = new PractitionerAccountEntity { PractitionerAccountId = 3 };
            using var context = new AppDbContext(_options);
            context.PractitionerAccounts.Add(entity);
            context.SaveChanges();

            _repository = new PractitionerAccountRepository(context);
            
            //Act
            var readResult = _repository.Read(entity.PractitionerAccountId);

            //Assert
            Assert.That(readResult.PractitionerAccountId, Is.EqualTo(entity.PractitionerAccountId));
        }

        [Test]
        public void GivenAnAccount_UpdateReturnsEntity_WithUpdatedValue()
        {
            //Arrange
            var entity = new PractitionerAccountEntity() { PractitionerAccountId = 2, Email = "example@example.com" };

            //Act
            using var context = new AppDbContext(_options);
            context.PractitionerAccounts.Add(entity);
            context.SaveChanges();
            _repository = new PractitionerAccountRepository(context);
            entity.Password = "password";
            
            //Act
            _repository.Update(entity);
            var result = _repository.Read(entity.PractitionerAccountId);
            
            //Assert
            Assert.That(result.PractitionerAccountId, Is.EqualTo(entity.PractitionerAccountId));
            Assert.That(result.Password, Is.EqualTo("password"));
        }

        [Test]
        public void GivenAnAccountId_ReadReturnsEntity_WithTwoPatientAccounts()
        {
            //Arrange
            var patientList = new List<PatientAccountEntity> {
                new PatientAccountEntity
                {
                    PatientAccountId = 11,
                    Email = "Patient1@example.com",
                    IsAdmin = false
                },
                new PatientAccountEntity
                {
                    PatientAccountId = 12,
                    Email = "Patient2@example.com",
                    IsAdmin = false
                }
            };
            var entity = new PractitionerAccountEntity { PractitionerAccountId = 4 };
            patientList[0].PractitionerAccountId = entity.PractitionerAccountId;
            patientList[1].PractitionerAccountId = entity.PractitionerAccountId;
            entity.PatientAccounts = patientList;

            using var context = new AppDbContext(_options);
            context.PractitionerAccounts.Add(entity);
            context.SaveChanges();

            var account = context.PractitionerAccounts.Find(entity.PractitionerAccountId);
            _repository = new PractitionerAccountRepository(context);
            
            //Act
            var readResult = _repository.Read(account.PractitionerAccountId);

            //Assert
            Assert.That(readResult.PractitionerAccountId, Is.EqualTo(entity.PractitionerAccountId));
            Assert.That(readResult.PatientAccounts.Count, Is.EqualTo(2));
        }
        
        [Test]
        public void GivenAnAccountUsername_And_Password_ReadReturnsEntity()
        {
            //Arrange
            var entity = new PractitionerAccountEntity { Username = "Abbie", Password="password" };

            using var context = new AppDbContext(_options);
            context.PractitionerAccounts.Add(entity);
            context.SaveChanges();
            _repository = new PractitionerAccountRepository(context);
            
            //Act
            var readResult = _repository.ReadByUsernameAndPassword(entity);

            //Assert
            Assert.That(readResult.Username, Is.EqualTo("Abbie"));
            Assert.That(readResult.Password, Is.EqualTo("password"));
        }
    }
}
