using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_1.Models;
using Lab_1.Singleton;

namespace Lab_1.Controllers
{
    public class PilaController : Controller
    {
        // GET: Pila
        public ActionResult Index()
        {
            return View(Datos.Instancia.PilaTrabajadores);
        }

        // GET: Pila/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pila/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pila/Create
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

        // GET: Pila/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pila/Edit/5
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

        // GET: Pila/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pila/Delete/5
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
