using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProgrammingExperienceJobsApp.Constants;
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
        var experience = _db.Experience.First(e => e.Language == Languages.CSharp);
        JobPosts = _db.JobPost.Where(jp => jp.Experiences.Contains(experience)).OrderByDescending(jp => jp.CreatedDate);
    }
}
