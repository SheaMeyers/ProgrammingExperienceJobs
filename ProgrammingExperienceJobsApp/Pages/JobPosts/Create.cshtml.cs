using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProgrammingExperienceJobsApp.Models;
using ProgrammingExperienceJobsApp.Data;

namespace ProgrammingExperienceJobsApp.Pages.JobPosts;
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _db;
    [BindProperty]
    public JobPost JobPost { get; set; }

    public CreateModel(ApplicationDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
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
