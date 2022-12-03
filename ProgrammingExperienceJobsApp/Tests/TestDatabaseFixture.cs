using ProgrammingExperienceJobsApp.Data;
using Microsoft.EntityFrameworkCore;

public class TestDatabaseFixture
{
    private const string ConnectionString = "User ID=stocktrackertest;Password=stocktrackertest;Host=localhost;Port=5432;Database=stocktrackertest;Pooling=true;";

    private static readonly object _lock = new();
    private static bool _databaseInitialized;

    public TestDatabaseFixture()
    {
        lock (_lock)
        {
            if (!_databaseInitialized)
            {
                using (var context = CreateContext())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    context.SaveChanges();
                }

                _databaseInitialized = true;
            }
        }
    }

    public ApplicationDbContext CreateContext()
        => new ApplicationDbContext(
            new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseNpgsql(ConnectionString)
                .Options);
}
