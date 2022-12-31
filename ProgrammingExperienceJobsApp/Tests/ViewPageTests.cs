using Xunit;
using ProgrammingExperienceJobsApp.Models;
using ProgrammingExperienceJobsApp.Pages.JobPosts;
using ProgrammingExperienceJobsApp.Constants;

public class ViewPageTests : IClassFixture<TestDatabaseFixture>
{
    public ViewPageTests(TestDatabaseFixture fixture) => Fixture = fixture;

    public TestDatabaseFixture Fixture { get; }

    [Fact]
    public void TestViewPageOnGet()
    {
        var context = Fixture.CreateContext();

        Guid id1 = new Guid("db545766-8850-4bce-885e-8a29e180478d");
        Guid id2 = new Guid("cb3f6807-7fb9-48ba-8ee4-2535eb50f1a9");

        JobPost jobPost1 = new JobPost{
            Id = id1,
            Title = "Title 1",
            Description = "Description 1",
            CompanyName = "Company 1",
            Email = "email1@email.com",
            PhoneNumber = "0000000001"
        };

        JobPost jobPost2 = new JobPost{
            Id = id2,
            Title = "Title 2",
            Description = "Description 2",
            CompanyName = "Company 2",
            Email = "email2@email.com",
            PhoneNumber = "0000000002"
        };

        context.Add(jobPost1);
        context.Add(jobPost2);

        context.SaveChanges();

        var pageModel = new ViewModel(context);
        pageModel.OnGet(id1);
        var retrievedJobPost = pageModel.JobPost;

        Assert.Equal(jobPost1, retrievedJobPost);
    }
}