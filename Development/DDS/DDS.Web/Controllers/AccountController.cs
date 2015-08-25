using System.Web.Security;
using AutoMapper;
using DDS.Model.Models;
using DDS.Models.Security;
using DDS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDS.Service;
using Newtonsoft.Json;

namespace DDS.Controllers
{
    public class AccountController : BaseController
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
                        this.IniciarSesion(usuario);

                        if (usuario.ActualizarPerfil())
                        {
                            return RedirectToAction("CargarPerfil");
                        }
                        else
                        {
                            return RedirectToAction("Home", "Home");
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

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);

            return RedirectToAction("Login", "Account", null);
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
                TempData["SuccessMessage"] = string.Format("Usuario '{0}' creado correctamente.", usuario.Username);
            }
            return View(model);
        }

        [CustomAuthorize]
        public ActionResult CargarPerfil()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CargarPerfil(PerfilViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = this.Current.User;
                var perfil = Mapper.Map<PerfilViewModel, Perfil>(model);
                usuario.Perfil = perfil;
                usuarioService.UpdateUsuario(usuario);
                usuarioService.SaveUsuario();
                TempData["SuccessMessage"] = string.Format("Perfil '{0}' cargado correctamente.", usuario.Username);
            }

            return View(model);
        }

        private void IniciarSesion(Usuario usuario)
        {
            string userData = JsonConvert.SerializeObject(usuario);
            var authTicket = new FormsAuthenticationTicket(
                     1,
                     usuario.Username,
                     DateTime.Now,
                     DateTime.Now.AddMinutes(20),
                     false,
                     userData);

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            Response.Cookies.Add(faCookie);
        }
    }
}
