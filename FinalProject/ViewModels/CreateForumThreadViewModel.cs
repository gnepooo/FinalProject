using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class CreateForumThreadViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
