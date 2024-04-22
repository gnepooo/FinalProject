using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FinalProject.Models.Navigation
{
    public class ApplicationUser
    {
        public ICollection<QuizResult> QuizResults { get; set; }
    }
}
