using System.Collections.Generic;



namespace FinalProject.Models.Navigation
{
    public class Quiz
    {
        // Navigation property for questions belonging to the quiz
        public ICollection<Question> Questions { get; set; }

        // Navigation property for the learning resource associated with the quiz
        public int LearningResourceId { get; set; } // Foreign key
        public LearningResource LearningResource { get; set; } // Reference navigation property

        // Navigation property for quiz results submitted for this quiz
        public ICollection<QuizResult> QuizResults { get; set; }
    }
}
