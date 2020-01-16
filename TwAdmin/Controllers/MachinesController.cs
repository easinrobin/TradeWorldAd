using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TwAdmin.Controllers
{
    public class MachinesController : Controller
    {
        // GET: Machines
        public ActionResult Index()
        {
            return View();
        }
    }
}