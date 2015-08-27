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

        public GrupoController(IGrupoService grupoService)
        {
            this.grupoService = grupoService;
        }

        // GET: Grupo/MisGrupos
        public ActionResult MisGrupos()
        {
            var grupos = this.grupoService.GetGruposByUserId(this.Current.User.Id);
            var model = Mapper.Map<IEnumerable<Grupo>, IList<GrupoViewModel>>(grupos);
            return View(model);
        }

        // POST: Grupo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Grupo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Grupo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Grupo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Grupo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Grupo/Delete/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
