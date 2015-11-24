using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DDS.Model.Models;
using DDS.Models.Security;
using DDS.Models.ViewModels;
using DDS.Service;

namespace DDS.Controllers
{
    [CustomAuthorize]
    public class GrupoController : BaseController
    {
        private readonly IGrupoService grupoService;
        private readonly IUsuarioService usuarioService;

        public GrupoController(IGrupoService grupoService, IUsuarioService usuarioService)
        {
            this.grupoService = grupoService;
            this.usuarioService = usuarioService;
        }

        // GET: Grupo/MisGrupos
        public ActionResult MisGrupos()
        {
            var grupos = this.grupoService.GetGruposByUserId(this.Current.User.Id);
            var model = Mapper.Map<IEnumerable<Grupo>, IList<GrupoViewModel>>(grupos);
            return View(model);
        }

        public ActionResult VerGrupos()
        {
            var grupos = this.grupoService.GetGruposPorUsuarioUnido(this.Current.User.Id);
            var model = Mapper.Map<IEnumerable<Grupo>, IList<GrupoViewModel>>(grupos);
            return View(model);
        }

        // GET: Grupo/Create
        public ActionResult Create()
        {
            return View(new GrupoViewModel());
        }

        // POST: Grupo/Create
        [HttpPost]
        public ActionResult Create(GrupoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var grupo = Mapper.Map<GrupoViewModel, Grupo>(model);
                    grupo.CreadoPor = Current.User.Id;
                    grupo.Usuarios = new List<Usuario> { usuarioService.GetByUsername(Current.User.Username) };
                    grupoService.CreateGrupo(grupo);
                    grupoService.SaveGrupo();
                    TempData["SuccessMessage"] = string.Format("Grupo '{0}' fue creado correctamente.", grupo.Nombre);
                }

                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: Grupo/Edit/5
        public ActionResult Edit(int id)
        {
            var grupo = Mapper.Map<Grupo, GrupoViewModel>(grupoService.GetGrupo(id));
            return View(grupo);
        }

        // POST: Grupo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, GrupoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var grupo = Mapper.Map<GrupoViewModel, Grupo>(model);
                    grupoService.UpdateGrupo(grupo);
                    grupoService.SaveGrupo();
                    TempData["SuccessMessage"] = string.Format("Grupo '{0}' fue modificado correctamente.", grupo.Nombre);
                }

                return View(model);
            }
            catch
            {
                return View();
            }
        }


        // GET: Grupo/Delete/5
        public ActionResult Delete(int id)
        {
            var grupo = grupoService.GetGrupo(id);
            grupoService.DeleteGrupo(grupo);
            grupoService.SaveGrupo();

            return RedirectToAction("MisGrupos");
        }

        public ActionResult Abandonar(int id)
        {
            var grupo = grupoService.GetGrupo(id);
            if (grupo.CreadoPor == this.Current.User.Id)
            {
                return Delete(id);
            }
            else
            {
                grupo.Usuarios.Remove(grupo.Usuarios.First(g => g.Id == this.Current.User.Id));
                grupoService.UpdateGrupo(grupo);
                grupoService.SaveGrupo();
                return RedirectToAction("VerGrupos");
            }
        }

        public ActionResult Unirme(int id)
        {
            var grupo = grupoService.GetGrupo(id);
            if (grupo.CreadoPor != this.Current.User.Id && !grupo.Usuarios.Any(g => g.Id==this.Current.User.Id))
            {
                grupo.Usuarios.Add(usuarioService.GetUsuario(this.Current.User.Id));
                grupoService.UpdateGrupo(grupo);
                grupoService.SaveGrupo();
            }

            return RedirectToAction("Buscar");
        }


        public ActionResult Buscar()
        {
            var grupos = this.grupoService.GetGruposByName("", this.Current.User.Id);
            var model = Mapper.Map<IEnumerable<Grupo>, IList<GrupoViewModel>>(grupos);
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var grupos = this.grupoService.GetGruposPorUsuarioUnido(this.Current.User.Id);
            var model = Mapper.Map<IEnumerable<Grupo>, IList<GrupoViewModel>>(grupos);
            return View(model);
        }
    }
}
