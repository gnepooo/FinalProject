using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class StudyGroupMembership
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int StudyGroupId { get; set; }

        // Navigation properties
        public ApplicationUser User { get; set; }
        public StudyGroup StudyGroup { get; set; }
    }
}
