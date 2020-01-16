using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TW.BusinessLayer;
using TW.Models;

namespace TwAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Banner()
        {
            List<Banner> allBanners = HomeManager.GetAllBanners();
            return View(allBanners);
        }

        public ActionResult InsertBanner()
        {
            AdminViewModel av = new AdminViewModel();
            av.Banner=new Banner();
            return View(av);
        }

        public ActionResult UpdateBanner(AdminViewModel av,long Id)
        {
            av.Banner = HomeManager.GetBannerDetails(Id);
            return View("~/Views/Home/InsertBanner.cshtml",av);
        }

        public ActionResult DeleteBanner(long Id)
        {
            HomeManager.DeleteBanner(Id);
            return RedirectToAction("Banner");
        }

        [HttpPost]
        public ActionResult InsertBanner(AdminViewModel av, HttpPostedFileBase image)
        {
            if (av.Banner != null && av.Banner.Id > 0)
            {
                HomeManager.UpdateBanner(av.Banner);
            }
            else
            {
                _UploadImage(av, image);
                av.Banner.IsActive = true;
                HomeManager.InsertBanner(av.Banner);
            }

            return RedirectToAction("Banner");
        }

        private void _UploadImage(AdminViewModel adminVwModel, HttpPostedFileBase images)
        {
            foreach (var file in adminVwModel.Files.Take(1))
            {
                string pathUrl = "";

                if (file.ContentLength > 0)
                {
                    string savepath, savefile;
                    var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
                    savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/Images/");
                    if (!Directory.Exists(savepath))
                        Directory.CreateDirectory(savepath);
                    savefile = Path.Combine(savepath, filename);
                    file.SaveAs(savefile);
                    pathUrl = "/img/Images/" + filename;
                    adminVwModel.Banner.ImageUrl = pathUrl;
                }
            }
        }
    }
}