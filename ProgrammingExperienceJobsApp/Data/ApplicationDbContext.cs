using Microsoft.EntityFrameworkCore;
using ProgrammingExperienceJobsApp.Models;

namespace ProgrammingExperienceJobsApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    public DbSet<JobPost> JobPost { get; set; }
}