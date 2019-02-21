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
            //Datos.Instancia.ListaTrabajadores.OrderBy(
            return View(Datos.Instancia.ListaTrabajadores);
        }

        // GET: Trabajadores/Details/5
        public ActionResult Details(FormCollection collection)
        {
            return RedirectToAction("Index", "Pila");
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

                Nuevo.Nombre = collection["Nombre"];
                Nuevo.codigo = collection["Codigo"];
                Nuevo.Citas = citas.Next(1, 5);
                Nuevo.BoolOficina = true;
                Nuevo.Llegada = Convert.ToDateTime(collection["Llegada"]);

                if (Nuevo.Llegada == DateTime.MinValue)
                {
                    Nuevo.Llegada = DateTime.Now;
                }

                Nuevo.Salida = Nuevo.HoraSalida(Nuevo.Llegada, Nuevo.Citas);
                Nuevo.sueldoFinal = Nuevo.SueldoFinal(Nuevo.Citas);

                Nuevo.AgregarALista(Nuevo); //Agregando elemento a la lista
                Nuevo.AgregarAPila(Nuevo);  //Agregando a pila

                //Regresa a Index
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }





        // GET: Trabajadores/Create
        public ActionResult Busqueda()
        {
            return View();
        }


        // POST: Trabajadores/Create
        [HttpPost]
        public ActionResult Busqueda(FormCollection collection)
        {
            try
            {
                //Instancias
                var Nuevo = new Trabajadores();
                Random citas = new Random();

                //Asignaciones

                Nuevo.Nombre = collection["Nombre"];
                Nuevo.codigo = collection["Codigo"];
                Nuevo.Citas = citas.Next(1, 5);
                Nuevo.BoolOficina = true;
                Nuevo.Llegada = Convert.ToDateTime(collection["Llegada"]);

                if (Nuevo.Llegada == DateTime.MinValue)
                {
                    Nuevo.Llegada = DateTime.Now;
                }

                Nuevo.Salida = Nuevo.HoraSalida(Nuevo.Llegada, Nuevo.Citas);
                Nuevo.sueldoFinal = Nuevo.SueldoFinal(Nuevo.Citas);

                Nuevo.AgregarALista(Nuevo); //Agregando elemento a la lista
                Nuevo.AgregarAPila(Nuevo);  //Agregando a pila

                //Regresa a Index
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
