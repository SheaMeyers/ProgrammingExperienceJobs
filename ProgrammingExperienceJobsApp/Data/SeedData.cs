using ProgrammingExperienceJobsApp.Models;
using ProgrammingExperienceJobsApp.Constants;

namespace ProgrammingExperienceJobsApp.Data;

public static class SeedData {
    public static void CreateData(ApplicationDbContext db)
    {
        Console.WriteLine("Creating seed data");
        
        Experience experience1 = new Experience
        {
            Language = Languages.CSharp,
            Years = 4
        };

        Experience experience2 = new Experience
        {
            Language = Languages.Java,
            Years = 2
        };

        JobPost jobPost1 = new JobPost
        {
            Id = new Guid("a1103eb7-0243-453d-9f94-6b1d585cc684"),
            Title = "C# Job",
            Description = "A job using C#",
            CompanyName = "C# Company",
            Email = "csharp@email.com",
            PhoneNumber = "1234567890",
        };

        JobPost jobPost2 = new JobPost
        {
            Id = new Guid("fc19864e-910e-494f-99ac-ee0103af5344"),
            Title = "Java Job",
            Description = "A job using Java",
            CompanyName = "Java Company",
            Email = "java@email.com",
            PhoneNumber = "0987654321",
        };

        jobPost1.Experiences.Add(experience1);
        experience1.JobPosts.Add(jobPost1);
        jobPost2.Experiences.Add(experience2);
        experience2.JobPosts.Add(jobPost2);

        db.JobPost.Add(jobPost1);
        db.JobPost.Add(jobPost2);
        db.Experience.Add(experience1);
        db.Experience.Add(experience2);

        db.SaveChanges();
    }
}