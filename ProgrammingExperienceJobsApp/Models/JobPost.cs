using System.ComponentModel.DataAnnotations;
using ProgrammingExperienceJobsApp.Constants;

namespace ProgrammingExperienceJobsApp.Models;

public class JobPost {
    
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
    [Required]
    public string CompanyName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    public virtual ICollection<Experience> Experiences { get; set; }


    public JobPost() 
    {
        this.CreatedDate = DateTime.UtcNow;
        this.Experiences = new HashSet<Experience>();
    }
}
