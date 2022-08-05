using System.ComponentModel.DataAnnotations;

namespace ProgrammingExperienceJobsApp.Models;

public class JobPost {
    
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }

    public JobPost(string title, string description) {
        Id = new Guid();
        Title = title;
        Description = description;
    }
}
