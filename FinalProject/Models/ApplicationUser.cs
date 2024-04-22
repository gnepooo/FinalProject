using Microsoft.AspNetCore.Identity;

namespace FinalProject.Models
{
    // Add any additional properties you need to track for users
    public class ApplicationUser : IdentityUser
    {
        // Properties for tracking progress
        public int CompletedLessons { get; set; }
        public int QuizScores { get; set; }
        public string LearningMilestones { get; set; }
    }
}
