using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class GroupProject
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        // Navigation property
        public ICollection<GroupMembership> Memberships { get; set; }
    }
}
