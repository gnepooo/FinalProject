namespace FinalProject.Models.Entities
{
    public class LearningResource
    {
        public int Id { get; set; }
        // Navigation property for answers
        public ICollection<Quiz> Quizzes { get; set; }
    }
}
