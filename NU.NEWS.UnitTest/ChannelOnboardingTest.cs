using Microsoft.EntityFrameworkCore;
using NC.NEWS.Messenger.Controllers;
using NC.NEWS.PersistenceStorage;
using NUnit.Framework;
using System.Linq;

namespace NU.NEWS.UnitTest
{
    class ChannelOnboardingTest
    {
        private ApplicationDbContext applicationDbContext = null;
        ChannelOnboardingController objChannelOnboardingController = null;
        public ChannelOnboardingTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "UnitTestDB")
                .Options;
            applicationDbContext = new ApplicationDbContext(options);
        }


        [Test]
        public void ValidateInitalData()
        {
            // Arrange
            objChannelOnboardingController = new ChannelOnboardingController(applicationDbContext);

            // Act
            var data = objChannelOnboardingController.Get();

            // Assert
            Assert.IsNotNull(data);
            Assert.AreEqual("NC.News.Communications", data.FirstOrDefault().sourceName);
        }

        [Test]
        public void ValidateNewChannelOnboardingTest()
        {
            // Arrange
            objChannelOnboardingController = new ChannelOnboardingController(applicationDbContext);

            // Act
            var response = objChannelOnboardingController.Post(new NC.NEWS.Domain.ChannelOnboard { sourceName = "google" });
            var getallChannels = objChannelOnboardingController.Get();

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual("google", response.ToString());
            Assert.NotZero(getallChannels.Count());
            Assert.AreEqual(2, getallChannels.Count());
        }
    }
}
