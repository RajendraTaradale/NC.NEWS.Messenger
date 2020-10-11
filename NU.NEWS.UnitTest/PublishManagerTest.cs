using Microsoft.EntityFrameworkCore;
using NC.NEWS.Messenger.Controllers;
using NC.NEWS.Messenger.DistributedCache;
using NC.NEWS.PersistenceStorage;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NC.NEWS.UnitTest
{
    class PublishManagerTest
    {
        private ApplicationDbContext applicationDbContext = null;
        PublishManagerController objPublishManagerController = null;
        public PublishManagerTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "UnitTestDB")
                .Options;
            applicationDbContext = new ApplicationDbContext(options);
        }

        [Test]
        public void Validate_PublishedMessages()
        {
            // Arrange
            objPublishManagerController = new PublishManagerController(applicationDbContext);
            IntrimData.SetData(new List<Domain.NotificationQueue> { new Domain.NotificationQueue { Id = 1, ChannelMessage = "facebook" } });

            // Act
            var data = objPublishManagerController.Get();

            // Assert
            Assert.IsNotNull(data);
            Assert.AreEqual(1, data.Count());
        }


    }
}
