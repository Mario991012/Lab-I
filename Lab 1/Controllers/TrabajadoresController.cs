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
                Nuevo.HorasTrabajadas = 1.5*Nuevo.Citas + 2;
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

        [HttpPost]
        public ActionResult Resultados(string codigo, string nombre, string disp, string horas)
        {
            EstructurasLineales.ListaDoblementeEnlazada<Trabajadores> ListaAux = new EstructurasLineales.ListaDoblementeEnlazada<Trabajadores>();

            if (codigo != null)
            {
                foreach (var item in Datos.Instancia.ListaTrabajadores)
                {
                    if (item.codigo == codigo)
                    {
                        ListaAux.Agregar(item);
                    }
                }
            }
            else if (nombre != null)
            {
                foreach (var item in Datos.Instancia.ListaTrabajadores)
                {
                    if (item.Nombre == nombre)
                    {
                        ListaAux.Agregar(item);
                    }
                }
            }
            else if (disp != null)
            {
                foreach (var item in Datos.Instancia.ListaTrabajadores)
                {
                    if (item.BoolOficina == bool.Parse(disp))
                    {
                        ListaAux.Agregar(item);

                    }
                }
            }
            else if (horas != null)
            {
                foreach (var item in Datos.Instancia.ListaTrabajadores)
                {
                    if (item.HorasTrabajadas == double.Parse(horas))
                    {
                        ListaAux.Agregar(item);
                    }
                }
            }
            return View(ListaAux);
        }

        public ActionResult Entrada()
        {
            foreach (var item in Datos.Instancia.PilaTrabajadores)
            {
                item.BoolOficina = true;
            }
            foreach (var item in Datos.Instancia.ListaTrabajadores)
            {
                item.BoolOficina = true;
            }
            return RedirectToAction("Index");
        }
   
        public ActionResult Salida()
        {
            foreach(var item in Datos.Instancia.PilaTrabajadores)
            {
                item.BoolOficina = false;
            }
            foreach (var item in Datos.Instancia.ListaTrabajadores)
            {
                item.BoolOficina = false;
            }
            return RedirectToAction("Index");
        }
    }
}
