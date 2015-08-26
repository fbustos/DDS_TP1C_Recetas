using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDS.Models.Security;

namespace DDS.Controllers
{
    public class BaseController : Controller
    {
        protected virtual new CustomPrincipal Current
        {
            get { return HttpContext.User as CustomPrincipal; }
        }
    }
}