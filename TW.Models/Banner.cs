﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace TW.Models
{
    public class Banner
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title required")]
        public string Title { get; set; }

        [Display(Name = "Short Description")]
        [Required(ErrorMessage = "Short Description required")]
        public string ShortDescription { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Image required")]
        public string ImageUrl { get; set; }

        [Display(Name = "Slider Background Img")]
        [Required(ErrorMessage = "Image required")]
        public string SliderBgImgUrl { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }

    [NotMapped]
    public class SliderBgImgUrl
    {
        public HttpPostedFileBase File { get; set; }
    }
}
