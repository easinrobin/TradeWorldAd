using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TW.DataLayerSql;
using TW.Models;

namespace TW.BusinessLayer
{
    public class ProjectManager
    {
        public static List<Project> GetAllProject()
        {
            SqlProjectProvider provider = new SqlProjectProvider();
            return provider.GetAllProject();
        }

        public static Project GetProjectById(long Id)
        {
            SqlProjectProvider provider = new SqlProjectProvider();
            return provider.GetProjectById(Id);
        }

        public static bool UpdateProject(Project project)
        {
            SqlProjectProvider provider = new SqlProjectProvider();
            return provider.UpdateProject(project);
        }

        public static long InsertProject(Project project)
        {
            SqlProjectProvider provider = new SqlProjectProvider();
            return provider.InsertProject(project);
        }

        public static bool DeleteProject(long Id)
        {
            SqlProjectProvider provider = new SqlProjectProvider();
            return provider.DeleteProject(Id);
        }

        public static List<ProjectCategory> GetAllProjectCategory()
        {
            SqlProjectCategoryProvider provider = new SqlProjectCategoryProvider();
            return provider.GetAllProjectCategory();
        }

        public static ProjectCategory GetProjectCategoryById(long Id)
        {
            SqlProjectCategoryProvider provider = new SqlProjectCategoryProvider();
            return provider.GetProjectCategoryById(Id);
        }

        public static bool UpdateProjectCategory(ProjectCategory project)
        {
            SqlProjectCategoryProvider provider = new SqlProjectCategoryProvider();
            return provider.UpdateProjectCategory(project);
        }

        public static long InsertProjectCategory(ProjectCategory project)
        {
            SqlProjectCategoryProvider provider = new SqlProjectCategoryProvider();
            return provider.InsertProjectCategory(project);
        }

        public static bool DeleteProjectCategory(long Id)
        {
            SqlProjectCategoryProvider provider = new SqlProjectCategoryProvider();
            return provider.DeleteProjectCategory(Id);
        }

        public static List<ProjectGallery> GetAllProjectGallery()
        {
            SqlProjectGalleryProvider provider = new SqlProjectGalleryProvider();
            return provider.GetAllProjectGallery();
        }

        public static List<ProjectGallery> GetProjectGalleryById(int Id)
        {
            SqlProjectGalleryProvider provider = new SqlProjectGalleryProvider();
            return provider.GetAllProjectGalleriesByProjectId(Id);
        }

        public static bool UpdateProjectGallery(ProjectGallery gallery)
        {
            SqlProjectGalleryProvider provider = new SqlProjectGalleryProvider();
            return provider.UpdateProjectGallery(gallery);
        }

        public static long InsertProjectGallery(ProjectGallery gallery)
        {
            SqlProjectGalleryProvider provider = new SqlProjectGalleryProvider();
            return provider.InsertProjectGallery(gallery);
        }

        public static bool DeleteProjectGallery(long Id)
        {
            SqlProjectGalleryProvider provider = new SqlProjectGalleryProvider();
            return provider.DeleteProjectGallery(Id);
        }
        public static List<Project> GetAllProjectsByCategoryId(int categoryId)
        {
            SqlProjectProvider provider = new SqlProjectProvider();
            return provider.GetAllProjectsByCategoryId(categoryId);
        }

        public static List<ProjectGallery> GetAllProjectGalleriesByProjectId(int projectId)
        {
            SqlProjectGalleryProvider provider = new SqlProjectGalleryProvider();
            return provider.GetAllProjectGalleriesByProjectId(projectId);
        }

        public static ProjectGallery ProjectGalleryById(int galleryId)
        {
            SqlProjectGalleryProvider provider = new SqlProjectGalleryProvider();
            return provider.GetProjectGalleryById(galleryId);
        }
    }
}
