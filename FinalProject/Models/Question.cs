namespace FinalProject.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        // Other properties...

        // Navigation property for answers
        public ICollection<Answer> Answers { get; set; }
    }
}
