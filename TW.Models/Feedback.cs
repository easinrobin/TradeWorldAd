using System;
using System.ComponentModel.DataAnnotations;

namespace TW.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Display(Name = "Mobile")]
        [Required(ErrorMessage = "Mobile required")]
        public string Mobile { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }

        [Display(Name = "Subject")]
        [Required(ErrorMessage = "Subject required")]
        public string Subject { get; set; }

        [Display(Name = "Message")]
        [Required(ErrorMessage = "Message required")]
        public string Message { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }
    }
}
