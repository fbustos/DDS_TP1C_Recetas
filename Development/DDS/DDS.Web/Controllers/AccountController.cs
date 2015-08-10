using DDS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDS.Service;

namespace DDS.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsuarioService usuarioService;

        public AccountController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuarios = usuarioService.GetUsuarios();
            }
            return View();
        }
    }
}
