using System.ComponentModel.DataAnnotations;
namespace ProgrammingExperienceJobsApp.Models;

public class JobPost {
    
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    public string CompanyName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
