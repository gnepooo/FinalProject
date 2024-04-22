using System;

namespace FinalProject.Models
{
    public class QuizResult
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public string UserId { get; set; }
        public DateTime SubmittedAt { get; set; }
        public int Score { get; set; }

        // Navigation properties
        public Quiz Quiz { get; set; }
        public ApplicationUser User { get; set; }
    }
}
