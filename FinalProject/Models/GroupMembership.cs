using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class GroupMembership
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int GroupProjectId { get; set; }

        // Navigation properties
        public ApplicationUser User { get; set; }
        public GroupProject GroupProject { get; set; }
    }
}
