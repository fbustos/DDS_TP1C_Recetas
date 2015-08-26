using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDS.Controllers
{
    public class RecetaController : BaseController
    {
        // GET: Receta
        public ActionResult Index()
        {
            return View();
        }

        // GET: Receta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Receta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Receta/Create
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

        // GET: Receta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Receta/Edit/5
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

        // GET: Receta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Receta/Delete/5
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
    }
}
