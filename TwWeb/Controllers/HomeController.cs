using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TW.BusinessLayer;
using TW.Models;

namespace TwWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                publicViewModel.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                publicViewModel.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }

            publicViewModel.OurClients = ClientManager.GetAllClients();
            publicViewModel.Banners = HomeManager.GetAllBanners();
            publicViewModel.OurMachines = MachineManager.GetAllMachines();
            publicViewModel.ProjectCategories = ProjectManager.GetAllProjectCategory();
            return View(publicViewModel);
        }

        public ActionResult About()
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            publicViewModel.OurClients = ClientManager.GetAllClients();
            publicViewModel.AboutUs = HomeManager.GetAboutUs(1);
            return View(publicViewModel);
        }
        public ActionResult Services()
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                publicViewModel.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                publicViewModel.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }
            publicViewModel.OurClients = ClientManager.GetAllClients();
            publicViewModel.OurServices = ServiceManager.GetAllService();
            return View(publicViewModel);
        }
        public ActionResult Ourprojects()
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                publicViewModel.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                publicViewModel.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }
            publicViewModel.ProjectCategories = ProjectManager.GetAllProjectCategory();
            publicViewModel.OurClients = ClientManager.GetAllClients();
            return View(publicViewModel);
        }
        public ActionResult Projectdetails(int id)
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                publicViewModel.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                publicViewModel.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }
            publicViewModel.ProjectCategory = ProjectManager.GetProjectCategoryById(id);
            publicViewModel.Projects = ProjectManager.GetAllProjectsByCategoryId(id);
            publicViewModel.OurClients = ClientManager.GetAllClients();
            return View(publicViewModel);
        }

        public ActionResult Gallery(int id)
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                publicViewModel.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                publicViewModel.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }
            publicViewModel.ProjectGalleries = ProjectManager.GetAllProjectGalleriesByProjectId(id);
            publicViewModel.Project = ProjectManager.GetProjectById(id);
            return View(publicViewModel);
        }

        public ActionResult Contact()
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                publicViewModel.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                publicViewModel.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }

            return View(publicViewModel);
        }

        public ActionResult Clients()
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                publicViewModel.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                publicViewModel.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }

            return View(publicViewModel);
        }

        [HttpPost]
        public ActionResult Contact(PublicViewModel pv)
        {
         
            if (Session["CompanySetting"] != null)
            {
                pv.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                pv.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }
            FeedbackManager.InsertFeedback(pv.Feedback);
            return View(pv);
        }
    }
}