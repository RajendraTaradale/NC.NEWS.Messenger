using Microsoft.EntityFrameworkCore;
using NC.NEWS.Domain;

namespace NC.NEWS.PersistenceStorage
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {

        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .Entity<NotificationQueue>(eb =>
        //        {
        //            eb.HasNoKey();
        //        });
        //}

        public DbSet<ChannelOnboard> channelOnboard { get; set; }

        public DbSet<SubscriberOnboard> subscriberOnboard { get; set; }

        public DbSet<NotificationQueue> notificationQueue { get; set; }
    }

}

