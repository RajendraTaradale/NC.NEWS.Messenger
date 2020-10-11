using Microsoft.EntityFrameworkCore;
using NC.NEWS.PersistenceStorage;

namespace NC.NEWS.UnitTest
{
    public class MockInMemoryDbContext
    {
        public ApplicationDbContext GetArticleDbContext()
        {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "UnitTestDB")
                .Options;
            var dbContext = new ApplicationDbContext(options);

            return dbContext;
        }
    }
}
