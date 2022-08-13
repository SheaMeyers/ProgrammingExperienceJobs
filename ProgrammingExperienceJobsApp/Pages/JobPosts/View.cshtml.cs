using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProgrammingExperienceJobsApp.Models;
using ProgrammingExperienceJobsApp.Data;

namespace ProgrammingExperienceJobsApp.Pages.JobPosts;
public class ViewModel : PageModel
{
    private readonly ApplicationDbContext _db;
    [BindProperty]
    public JobPost JobPost { get; set; }

    public ViewModel(ApplicationDbContext db)
    {
        _db = db;
    }
    public void OnGet(Guid id)
    {
        JobPost = _db.JobPost.Find(id);
    }
}
