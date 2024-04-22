namespace FinalProject.Models.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        // Navigation property for the associated question
        public int QuestionId { get; set; } 
        public Question Question { get; set; } // Reference navigation property
    }
}
