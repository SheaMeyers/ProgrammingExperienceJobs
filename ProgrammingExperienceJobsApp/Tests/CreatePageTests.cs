using Xunit;
using ProgrammingExperienceJobsApp.Models;
using ProgrammingExperienceJobsApp.Pages.JobPosts;
using ProgrammingExperienceJobsApp.Constants;

public class CreatePageTests : IClassFixture<TestDatabaseFixture>
{
    public CreatePageTests(TestDatabaseFixture fixture) => Fixture = fixture;

    public TestDatabaseFixture Fixture { get; }

    [Fact]
    public async Task TestCreatePageOnGet()
    {
        var context = Fixture.CreateContext();

        JobPost jobPost = new JobPost{
            Id = new Guid("15108906-56c7-4544-9703-dba5826a67bd"),
            Title = "Title 1",
            Description = "Description 1",
            CompanyName = "Company 1",
            Email = "email1@email.com",
            PhoneNumber = "0000000001"
        };
        
        Experience experience = new Experience {
            Language = (Languages)2,
            Years = 4
        };

        var pageModel = new CreateModel(context);
        pageModel.JobPost = jobPost;
        pageModel.Experience = experience;
        await pageModel.OnPost();

        Assert.Equal(context.JobPost.Where(jp => jp == jobPost).Count(), 1);
        Assert.Equal(context.Experience.Where(e => e == experience).Count(), 1);
    }
}