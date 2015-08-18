using System.Web.Security;
using DDS.Model.Models;
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
                var usuario = usuarioService.GetByUsername(model.Username);
                if (usuario != null)
                {
                    if (usuario.CheckPassword(model.Password))
                    {
                        if (usuario.ActualizarPerfil())
                        {
                            return RedirectToAction("CargarPerfil");
                        }
                        else
                        {
                            return View(model);
                        }
                    }
                    
                    ModelState.AddModelError("IncorrectPassword", "La contraseña es incorrecta.");
                }
                else
                {
                    ModelState.AddModelError("UserNotExist", "El usuario ingresado no existe.");
                }
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario { Username = model.Username };
                usuario.SetPassword(model.Password);

                usuarioService.CreateUsuario(usuario);
                usuarioService.SaveUsuario();
                TempData["RegisterSuccessMessage"] = string.Format("Usuario '{0}' creado correctamente.", usuario.Username);
            }
            return View(model);
        }

        public ActionResult CargarPerfil()
        {
            return View();
        }
    }
}
