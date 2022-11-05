using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProgrammingExperienceJobsApp.Models;
using ProgrammingExperienceJobsApp.Data;
using ProgrammingExperienceJobsApp.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ProgrammingExperienceJobsApp.Pages.JobPosts;
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _db;
    [BindProperty]
    public JobPost JobPost { get; set; }
    public IEnumerable<Experience> Experiences { get; set; }
    public Array languages { get; set; }

    public CreateModel(ApplicationDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
        this.languages = Enum.GetValues(typeof(Languages));
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid) 
        return Page();
        
        await _db.JobPost.AddAsync(JobPost);
        await _db.SaveChangesAsync();
        return RedirectToPage("../Index");
    }
}
