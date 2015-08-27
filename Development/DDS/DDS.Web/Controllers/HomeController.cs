using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDS.Models.Security;

namespace DDS.Controllers
{
    [CustomAuthorize]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }
    }
}