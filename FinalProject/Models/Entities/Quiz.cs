namespace FinalProject.Models.Entities
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // Navigation property for questions
        public ICollection<Question> Questions { get; set; }
    }
}
