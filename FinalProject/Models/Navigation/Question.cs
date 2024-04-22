using System.Collections.Generic;



namespace FinalProject.Models.Navigation
{
    public class Question
    {
        // Navigation property for answers to the question
        public ICollection<Answer> Answers { get; set; }

        // Navigation property for the quiz to which the question belongs
        public int QuizId { get; set; } // Foreign key
        public Quiz Quiz { get; set; } // Reference navigation property
    }
}
