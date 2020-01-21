using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TW.Models;

namespace TW.DataLayer
{
    public interface IProjectGalleryProvider
    {
        List<ProjectGallery> GetAllProjectGallery();
        ProjectGallery GetProjectGalleryById(long Id);
        long InsertProjectGallery(ProjectGallery gallery);
        bool UpdateProjectGallery(ProjectGallery gallery);
        bool DeleteProjectGallery(long Id);
    }
}
