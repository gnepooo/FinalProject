using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class ForumReply
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int ThreadId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public ApplicationUser User { get; set; }
        public ForumThread Thread { get; set; }
    }
}
