using Microsoft.EntityFrameworkCore;
using ProgrammingExperienceJobsApp.Constants;
using ProgrammingExperienceJobsApp.Models;

namespace ProgrammingExperienceJobsApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    public DbSet<JobPost> JobPost { get; set; }
    public DbSet<Experience> Experience { get; set; }
}