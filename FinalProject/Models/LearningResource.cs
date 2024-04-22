using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class LearningResource
    {
        public int Id { get; set; }
        // Other properties...

        // Navigation property for quizzes
        public ICollection<Quiz> Quizzes { get; set; }
    }

    // Add a new Quiz model
    

    // Add a new Question model

    // Add a new Answer model
    
}
