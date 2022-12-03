using ProgrammingExperienceJobsApp.Pages;
using ProgrammingExperienceJobsApp.Models;
using Xunit;


public class IndexPageTests : IClassFixture<TestDatabaseFixture>
{
    public IndexPageTests(TestDatabaseFixture fixture) => Fixture = fixture;

    public TestDatabaseFixture Fixture { get; }

    [Fact]
    public void TestIndexPage()
    {
        var context = Fixture.CreateContext();

        Assert.Equal(true, true);
    }
}