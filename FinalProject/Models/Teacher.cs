// Teacher.cs
namespace FinalProject.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Add other properties for Teacher

        // Navigation property for related LearningResources
        public ICollection<LearningResource> LearningResources { get; set; }
    }
}
