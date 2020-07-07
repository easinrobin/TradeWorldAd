using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TW.BusinessLayer;
using TW.Models;
using Vereyon.Web;

namespace TwAdmin.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult Index()
        {
            AdminViewModel av = new AdminViewModel();
            av.ProjectList = ProjectManager.GetAllProject();
            return View(av);
        }

        public ActionResult Create()
        {
            AdminViewModel av = new AdminViewModel();
            av.Project = new Project();
            _loadProjects();
            return View(av);
        }

        public ActionResult GalleryList(int? id)
        {
            AdminViewModel av = new AdminViewModel();
            if (!string.IsNullOrEmpty(id.ToString()))
            {
                var isProjectExists = ProjectManager.GetProjectById(id ?? 0);
                if (isProjectExists != null)
                {
                    av.ProjectGalleryList = ProjectManager.GetProjectGalleryById(id ?? 0);
                    if (av.ProjectGalleryList != null)
                    {
                        ViewBag.ProjectId = id;
                        return View(av);
                    }
                }
            }
            FlashMessage.Danger("Project not found.");
            return RedirectToAction("Index");
        }

        public ActionResult CreateGallery(int? id)
        {
            AdminViewModel av = new AdminViewModel();
            if (!string.IsNullOrEmpty(id.ToString()))
            {
                var isProjectExists = ProjectManager.GetProjectById(id ?? 0);
                if (isProjectExists != null)
                {
                    ProjectGallery gallery = new ProjectGallery
                    {
                        ProjectId = id ?? 0
                    };
                    av.ProjectGallery = gallery;

                    return View(av);
                }
            }
            FlashMessage.Danger("Could not add gallery item for this project.");
            return RedirectToAction("Index");
        }

        public ActionResult DeleteGalleryItem(int id, int projectId)
        {
            if (!string.IsNullOrEmpty(id.ToString()))
            {
                var isGalleryExists = ProjectManager.GetGalleryById(id);
                if (isGalleryExists != null)
                {
                    ProjectManager.DeleteProjectGallery(id);
                    FlashMessage.Info("Image deleted successfully.");
                    return RedirectToAction("GalleryList", new
                    {
                        id = projectId
                    });
                }
            }

            FlashMessage.Danger("Something went wrong. Could not delete image.");
            return RedirectToAction("Index");
        }

        public ActionResult UpdateProject(long? id)
        {
            AdminViewModel av = new AdminViewModel();
            if (!string.IsNullOrEmpty(id.ToString()))
            {
                var categoryList = _loadProjects();
                ViewData["CategoryList"] = categoryList;

                av.Project = ProjectManager.GetProjectById(id ?? 0);
                if (av.Project != null)
                {
                    return View("~/Views/Projects/UpdateProject.cshtml", av);
                }
            }

            FlashMessage.Danger("Something went wrong. Could not update this project.");
            return RedirectToAction("Index");
        }

        public ActionResult UpdateProjectG(int Id)
        {
            if (Id > 0)
            {
                AdminViewModel av = new AdminViewModel();
                av.ProjectGallery = ProjectManager.GetGalleryById(Id);
                if (av.ProjectGallery != null)
                {
                    return View("~/Views/Projects/UpdateGalleryItem.cshtml", av);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteProject(long Id)
        {
            ProjectManager.DeleteProject(Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(AdminViewModel av, HttpPostedFileBase image)
        {
            av.Project.ImageUrl = _UploadSingleImage(av, image);
            av.Project.IsActive = true;
            av.Project.CreatedBy = "Admin";
            av.Project.CreatedDate = DateTime.Today;
            av.Project.ImageUrl = _UploadSingleImage(av, image);

            var projectId = ProjectManager.InsertProject(av.Project);

            if (projectId > 0)
            {
                //av.ProjectCategory.ImageUrl = _UploadSingleImage(av, image);
                //av.ProjectCategory.IsActive = true;
                //var categoryId = ProjectManager.InsertProjectCategory(av.ProjectCategory);

                _Gallery(projectId, av);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateProject(AdminViewModel av, long id, HttpPostedFileBase image)
        {
            av.Project.IsActive = true;
            av.Project.CreatedBy = "Admin";
            av.Project.CreatedDate = DateTime.Today;
            av.Project.ImageUrl = _UploadSingleImage(av, image);

            bool isUpdateProject = ProjectManager.UpdateProject(av.Project);
            bool isUpdateProjectCategoty = ProjectManager.UpdateProjectCategory(av.ProjectCategory);

            FlashMessage.Danger("Project Updated Successfully.");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateProjectG(AdminViewModel av)
        {
            av.ProjectGallery.IsActive = true;
            av.ProjectGallery.CreatedBy = "Admin";
            av.ProjectGallery.CreatedDate = DateTime.Today;
           

            bool isUpdateProject = ProjectManager.UpdateProjectGallery(av.ProjectGallery);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateGallery(AdminViewModel av, HttpPostedFileBase image)
        {
            if (av != null)
            {
                foreach (var file in av.Files)
                {
                    if (Request.Url != null)
                    {
                        string pathUrl = "";

                        if (file.ContentLength > 0)
                        {
                            string savepath, savefile;
                            var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
                            savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/Offices/");
                            if (!Directory.Exists(savepath))
                                Directory.CreateDirectory(savepath);
                            savefile = Path.Combine(savepath, filename);
                            file.SaveAs(savefile);
                            pathUrl = "/img/Offices/" + filename;
                        }

                        var gallery = new ProjectGallery
                        {
                            ImageUrl = pathUrl,
                            ProjectId = av.ProjectGallery.ProjectId,
                            CreatedBy = "Admin",
                            CreatedDate = DateTime.Now,
                            IsActive = true
                        };
                        var galleryId = ProjectManager.InsertProjectGallery(gallery);
                    }
                }
            }
            FlashMessage.Confirmation("Image added successfully");
            return RedirectToAction("GalleryList", new
            {
                Id = av.ProjectGallery.ProjectId
            });
        }

        private void _Gallery(long projectId, AdminViewModel av)
        {
            if (av != null)
            {
                foreach (var file in av.Files)
                {
                    string pathUrl = "";

                    if (file.ContentLength > 0)
                    {
                        string savepath, savefile;
                        var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
                        savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/Offices/");
                        if (!Directory.Exists(savepath))
                            Directory.CreateDirectory(savepath);
                        savefile = Path.Combine(savepath, filename);
                        file.SaveAs(savefile);
                        pathUrl = "/img/Offices/" + filename;
                    }

                    var gallery = new ProjectGallery
                    {
                        ImageUrl = pathUrl,
                        ProjectId = projectId,
                        IsActive = true,
                        CreatedBy = "Admin",
                        CreatedDate = DateTime.Now
                    };
                    var galleryId = ProjectManager.InsertProjectGallery(gallery);
                }
            }
        }

        private string _UploadSingleImage(AdminViewModel adminVwModel, HttpPostedFileBase images)
        {
            var file = adminVwModel.File;
            string pathUrl = "";
            string savepath, savefile;
            var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
            savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/Images/");
            if (!Directory.Exists(savepath))
                Directory.CreateDirectory(savepath);
            savefile = Path.Combine(savepath, filename);
            file.SaveAs(savefile);
            pathUrl = "/img/Images/" + filename;
            return pathUrl;
        }

        //public void _loadProjects()
        //{
        //    List<ProjectCategory> dataList = ProjectManager.GetAllProjectCategory();
        //    ViewBag.CategoryList = new SelectList(dataList, "Id", "Name");
        //}

        public SelectList _loadProjects()
        {
            AdminViewModel av = new AdminViewModel();
            var categoryData = new SelectList("", "");
            try
            {
                var category = ProjectManager.GetAllProjectCategory();
                if (!string.IsNullOrEmpty(category.ToString()))
                {
                    av.ProjectCategoryList = new List<ProjectCategory>();
                    av.ProjectCategoryList = category.OrderBy(x => x.Id).ToList();
                    categoryData = new SelectList(av.ProjectCategoryList, "Id", "Name");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return categoryData;
        }

       
    }
}