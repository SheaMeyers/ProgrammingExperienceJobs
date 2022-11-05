using System.ComponentModel.DataAnnotations;
using ProgrammingExperienceJobsApp.Constants;

namespace ProgrammingExperienceJobsApp.Models;

public class Experience {
    
    [Key]
    public Language Language { get; set; }
    [Required]
    public int Years { get; set; }
    public virtual ICollection<JobPost> JobPosts { get; set; }
    public Experience() 
    {
        this.JobPosts = new HashSet<JobPost>();
    }
}
