using Microsoft.AspNetCore.Mvc.RazorPages;
using ProgrammingExperienceJobsApp.Data;
using ProgrammingExperienceJobsApp.Models;

namespace ProgrammingExperienceJobsApp.Pages.JobPosts;
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;

    public IEnumerable<JobPost> JobPosts { get; set; }

    public IndexModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet()
    {
        JobPosts = _db.JobPost.OrderByDescending(jobPost => jobPost.CreatedDate);
    }
}
