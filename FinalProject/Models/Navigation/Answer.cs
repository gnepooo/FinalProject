namespace FinalProject.Models.Navigation
{
    public class Answer
    {
        public int QuestionId { get; set; } // Foreign key
        public Question Question { get; set; } // Reference navigation property
    }
}
