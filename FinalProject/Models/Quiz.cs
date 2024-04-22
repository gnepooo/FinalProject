namespace FinalProject.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // Other properties...

        // Navigation property for questions
        public ICollection<Question> Questions { get; set; }
    }
}
