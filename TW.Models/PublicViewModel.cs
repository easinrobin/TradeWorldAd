﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TW.Models
{
    public class PublicViewModel
    {
        public List<Banner> Banners { get; set; }
        public AboutUs AboutUs { get; set; }
        public OurClient Clients { get; set; }
        public List<OurClient> OurClients { get; set; }
        public CompanySetting CompanySetting { get; set; }
        public List<OurMachine> OurMachines { get; set; }
        public List<ProjectCategory> ProjectCategories { get; set; }
        public List<OurService> OurServices { get; set; }
        public List<Project> Projects { get; set; }
        public ProjectCategory ProjectCategory { get; set; }
        public Project Project { get; set; }
        public List<ProjectGallery> ProjectGalleries { get; set; }
        public Feedback Feedback { get; set; }
    }
}
