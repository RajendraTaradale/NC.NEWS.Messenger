using Microsoft.EntityFrameworkCore;
using NC.NEWS.Messenger.Controllers;
using NC.NEWS.PersistenceStorage;
using NUnit.Framework;

namespace NC.NEWS.UnitTest
{
    class SubscriberOnboardingTest
    {
        private ApplicationDbContext applicationDbContext = null;
        SubscriberOnboardingController objSubscriberOnboardingController = null;
        public SubscriberOnboardingTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "UnitTestDB")
                .Options;
            applicationDbContext = new ApplicationDbContext(options);
        }

        [Test]
        public void GetAllSubscribers_Test()
        {
            // Arrange
            objSubscriberOnboardingController = new SubscriberOnboardingController(applicationDbContext);

            // Act
            var data = objSubscriberOnboardingController.Get();

            // Assert
            Assert.IsNotNull(data);
        }
    }
}
