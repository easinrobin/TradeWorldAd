using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TwAdmin.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult CompanySettings()
        {
            return View();
        }
    }
}