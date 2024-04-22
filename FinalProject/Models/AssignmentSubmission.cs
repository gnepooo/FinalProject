using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class AssignmentSubmission
    {
        public int Id { get; set; }

        [Required]
        public int AssignmentId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Submission Date")]
        public DateTime SubmissionDate { get; set; }

        // Navigation properties
        public Assignment Assignment { get; set; }
        public ApplicationUser User { get; set; }
    }
}