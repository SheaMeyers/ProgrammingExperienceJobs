using Xunit;
using ProgrammingExperienceJobsApp.Models;
using ProgrammingExperienceJobsApp.Pages.JobPosts;
using ProgrammingExperienceJobsApp.Constants;

public class IndexPageTests : IClassFixture<TestDatabaseFixture>
{
    public IndexPageTests(TestDatabaseFixture fixture) => Fixture = fixture;

    public TestDatabaseFixture Fixture { get; }

    [Fact]
    public void TestIndexPageOnGet()
    {
        var context = Fixture.CreateContext();

        context.Add(new JobPost{
            Id = new Guid(),
            Title = "Title 1",
            Description = "Description 1",
            CompanyName = "Company 1",
            Email = "email1@email.com",
            PhoneNumber = "0000000001"
        });
        context.Add(new JobPost{
            Id = new Guid(),
            Title = "Title 2",
            Description = "Description 2",
            CompanyName = "Company 2",
            Email = "email2@email.com",
            PhoneNumber = "0000000002"
        });

        context.SaveChanges();

        var expectedJobPosts = context.JobPost.ToList();

        var pageModel = new IndexModel(context);
        pageModel.OnGet();
        var actualJobPosts = pageModel.JobPosts.ToList();

        Assert.Equal(expectedJobPosts, actualJobPosts);
    }

    [Fact]
    public void TestIndexPageOnPost()
    {
        var context = Fixture.CreateContext();

        JobPost job1 = new JobPost{
            Id = new Guid(),
            Title = "Title 1",
            Description = "Description 1",
            CompanyName = "Company 1",
            Email = "email1@email.com",
            PhoneNumber = "0000000001"
        };
        JobPost job2 = new JobPost{
            Id = new Guid(),
            Title = "Title 2",
            Description = "Description 2",
            CompanyName = "Company 2",
            Email = "email2@email.com",
            PhoneNumber = "0000000002"
        };
        Experience experience1 = new Experience {
            Language = 0,
            Years = 3
        };
        Experience experience2 = new Experience {
            Language = (Languages)1,
            Years = 5
        };
        job1.Experiences.Add(experience1);
        experience1.JobPosts.Add(job1);
        job2.Experiences.Add(experience2);
        experience2.JobPosts.Add(job2);

        context.Add(job1);
        context.Add(job2);
        context.Add(experience1);
        context.Add(experience2);

        context.SaveChanges();

        var expectedJobPosts = context.JobPost.ToList();

        var pageModel = new IndexModel(context);
        pageModel.Experience = experience1;
        pageModel.OnPost();
        var actualJobPosts = pageModel.JobPosts.ToList();

        Assert.Equal(1, actualJobPosts.Count());
        Assert.Equal(job1, actualJobPosts.First());
    }
}