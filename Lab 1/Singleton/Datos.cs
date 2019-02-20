using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_1.Models;

namespace Lab_1.Singleton
{
    public class Datos
    {
        private static Datos instancia = null;
        public static Datos Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new Datos();
                }
                return instancia;
            }
        }

        //Lista y pila utilizada que pertenece a la libreria de clases
        public EstructurasLineales.ListaDoblementeEnlazada<Trabajadores> ListaTrabajadores = new EstructurasLineales.ListaDoblementeEnlazada<Trabajadores>();
        public EstructurasLineales.Pila<Trabajadores> PilaTrabajadores = new EstructurasLineales.Pila<Trabajadores>();
    }
}
