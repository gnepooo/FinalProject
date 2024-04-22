using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class ReplyViewModel
    {
        public int ThreadId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
