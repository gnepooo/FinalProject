using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Assignment
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        // Navigation property for submissions
        public ICollection<AssignmentSubmission> Submissions { get; set; }
    }
}