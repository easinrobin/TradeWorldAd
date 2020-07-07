using System;
using System.ComponentModel.DataAnnotations;

namespace TW.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Project Category Id")]
        [Required(ErrorMessage = "Project Category Id required")]
        public int ProjectCategoryId { get; set; }

        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "Project Name required")]
        public string ProjectName { get; set; }

        [Display(Name = "Project Location")]
        [Required(ErrorMessage = "Project Location required")]
        public string ProjectLocation { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Image required")]
        public string ImageUrl { get; set; }

        [Display(Name = "Architect Name")]
        [Required(ErrorMessage = "Architect Name required")]
        public string ArchitectName { get; set; }

        [Display(Name = "Consultant Contractor")]
        [Required(ErrorMessage = "Consultant Contractor required")]
        public string Consultant_Contractor { get; set; }

        [Display(Name = "Short Details")]
        [Required(ErrorMessage = "Short Details required")]
        public string ShortDetails { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        //public string ProjectCategoryName { get; set; }
    }
}
