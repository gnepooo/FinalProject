using System.Collections.Generic;



namespace FinalProject.Models.Navigation
{
    public class LearningResource
    {
        public ICollection<Quiz> Quizzes { get; set; }
    }
}
