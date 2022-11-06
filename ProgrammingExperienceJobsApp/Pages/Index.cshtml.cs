using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProgrammingExperienceJobsApp.Constants;
using ProgrammingExperienceJobsApp.Data;
using ProgrammingExperienceJobsApp.Models;

namespace ProgrammingExperienceJobsApp.Pages.JobPosts;
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;

    public IEnumerable<JobPost> JobPosts { get; set; }
    [BindProperty]
    public Experience Experience { get; set; }
    public Array languageValues = Enum.GetValues(typeof(Languages));

    public IndexModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnPost()
    {
        JobPosts = _db.JobPost.Where(jp => jp.Experiences.Contains(Experience)).OrderByDescending(jp => jp.CreatedDate);
    }

    public void OnGet()
    {
        JobPosts = _db.JobPost;
    }
}
