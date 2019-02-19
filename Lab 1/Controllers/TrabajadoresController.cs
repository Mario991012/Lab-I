using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_1.Models;
using Lab_1.Singleton;

namespace Lab_1.Controllers
{
    public class TrabajadoresController : Controller
    {
        // GET: Trabajadores
        public ActionResult Index()
        {
            //Retorna la lista unicamente
            return View(Datos.Instancia.ListaTrabajadores);
        }

        // GET: Trabajadores/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Trabajadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trabajadores/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                //Instancias
                var Nuevo = new Trabajadores();
                Random citas = new Random();

                //Asignaciones

                Nuevo.AgregarALista(Nuevo); //Agregando elemento a la lista
                
                Nuevo.Nombre = collection["Nombre"];
                Nuevo.codigo = collection["Codigo"];
                Nuevo.Citas = citas.Next(1, 5);
                Nuevo.BoolOficina = true;
                Nuevo.Salida = Nuevo.HoraSalida(Nuevo.Llegada, Nuevo.Citas);
                Nuevo.sueldoFinal = Nuevo.SueldoFinal(Nuevo.Citas);

                if(collection["Llegada"] == " ")
                {
                    Nuevo.Llegada = DateTime.Now;
                }
                else
                {
                    Nuevo.Llegada = Convert.ToDateTime(collection["Llegada"]);
                }

                //Regresa a Index
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Trabajadores/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Trabajadores/Edit/5
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

        // GET: Trabajadores/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Trabajadores/Delete/5
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
