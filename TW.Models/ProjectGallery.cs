﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TW.Models
{
    public class ProjectGallery
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Project Id")]
        public long ProjectId { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Image required")]
        public string ImageUrl { get; set; }

        [Display(Name = "Image Details")]
        public string ImageDetails { get; set; }


        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
