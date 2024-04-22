using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class ForumThread
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public ApplicationUser User { get; set; }
        public ICollection<ForumReply> Replies { get; set; }
    }
}
