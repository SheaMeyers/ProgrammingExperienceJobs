using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProgrammingExperienceJobsApp.Models;
using ProgrammingExperienceJobsApp.Data;
using ProgrammingExperienceJobsApp.Constants;

namespace ProgrammingExperienceJobsApp.Pages.JobPosts;
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _db;
    [BindProperty]
    public JobPost JobPost { get; set; }
    [BindProperty]
    public Experience Experience { get; set; }
    public Array languageValues { get; set; }

    public CreateModel(ApplicationDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
        this.languageValues = Enum.GetValues(typeof(Languages));
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid) 
        return Page();

        if(!_db.Experience.Any(e => e.Language == Experience.Language && e.Years == Experience.Years)){
            // If Language and Years combination does not yet exist, add it so it can be updated later
            await _db.Experience.AddAsync(Experience);
            await _db.SaveChangesAsync();
        }

        JobPost.Experiences.Add(Experience);
        Experience.JobPosts.Add(JobPost);
        
        await _db.JobPost.AddAsync(JobPost);
        _db.Experience.Update(Experience);
        await _db.SaveChangesAsync();
        return RedirectToPage("../Index");
    }
}
