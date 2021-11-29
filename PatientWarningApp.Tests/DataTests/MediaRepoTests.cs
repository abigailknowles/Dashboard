using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PatientWarningApp.Data.DbContexts;
using PatientWarningApp.Data.Entities;
using PatientWarningApp.Data.Repositories;

namespace PatientWarningApp.Tests.DataTests
{
    public class MediaRepoTests
    {
        private MediaRepository mediaRepository;
        private DbContextOptions<AppDbContext> _options;
        private AppDbContext _context;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
            .EnableSensitiveDataLogging()
            .UseInMemoryDatabase(databaseName: "MediaListDatabase")
            .Options;

        }

        [TearDown]
        public void TearDown()
        {
           
        }

        [Test]
        public void CreateMediaRecord()
        {
            //Arrange
            var media = new Media() { 
                Id = 1,
                Title = "Shrek",
                Genre = "Family",
                Director="JK Rowling",
                ReleaseDate="08/08/2000"
                };

            //Act
            using (_context = new AppDbContext(_options))
            {
                _context.Media.Add(media);
                _context.SaveChanges();
                mediaRepository = new MediaRepository(_context);

                var result = mediaRepository.Create(media);

                //Assert
                Assert.That(result.Id, Is.EqualTo(1));
                Assert.That(result.Title, Is.EqualTo("Shrek"));
            }
        }

        [Test]
        public void DeleteMediaRecordById()
        {
            //Arrange
            var media = new Media() { Id = 2 };

            //Act
            using (_context = new AppDbContext(_options))
            {
                _context.Media.Add(media);
                _context.SaveChanges();

                mediaRepository = new MediaRepository(_context);

                var result = mediaRepository.Delete(media);
                var readResult = mediaRepository.Read(media.Id);

                //Assert
                Assert.That(result.Id, Is.EqualTo(2));
                Assert.That(readResult, Is.Null);
            }
        }

        [Test]
        public void ReadMediaRecordById()
        {
            //Arrange
            var media = new Media{ Id = 5 };

            using (var context = new AppDbContext(_options))
            {
                context.Media.Add(media);
                context.SaveChanges();

                //Act
                var mediaRepository = new MediaRepository(context);

                var readResult = mediaRepository.Read(media.Id);

                //Assert
                Assert.That(readResult.Id, Is.EqualTo(5));
            }
        }

        [Test]
        public void UpdatePatientRecord()
        {
            //Arrange
            var media = new Media()
            {
                Id = 7,
                Title = "Shrek",
                Genre = "Family",
                Director = "JK Rowling",
                ReleaseDate = "08/08/2000"
            };

            //Act
            using (var context = new AppDbContext(_options))
            {
                context.Media.Add(media);
                context.SaveChanges();

                //Act
                var mediaRepository = new MediaRepository(context);


                media.Title = "Shrek 2";

                var readResult = mediaRepository.Update(media);

                var result = mediaRepository.Read(media.Id);
                //Assert
                Assert.That(result.Id, Is.EqualTo(7));
                Assert.That(result.Title, Is.EqualTo("Shrek 2"));
            }
        
        }
    }
}
