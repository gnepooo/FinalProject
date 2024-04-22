namespace FinalProject.Models.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        // Navigation property for answers
        public ICollection<Answer> Answers { get; set; }
    }
}
