using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_1.Singleton;
using System.ComponentModel;

namespace Lab_1.Models
{
    public class Trabajadores : IComparable
    {
        [DisplayName("Nombre de Empleado")]
        public string Nombre { get; set; }
        [DisplayName("Codigo de Empleado")]
        public string codigo { get; set; }
        
        [DisplayName("Sueldo del dia")]
        public double sueldoFinal { get; set; }
        [DisplayName("Cantidad de Citas")]
        public int Citas { get; set; }

        
        [DisplayName("Hora de Llegada (Formato: AA/MM/DD HH:MM:SS)")]
        public DateTime Llegada { get; set; }

        [DisplayName("Hora de Salida")]
        public DateTime Salida { get; set; }
        
        [DisplayName("Estado: En oficina")]
        public bool BoolOficina { get; set; } //TODO FALSO

        //METODOS A LLAMAR EN CONTROLLER
        public void AgregarALista(Trabajadores Trabajador)
        {
            //Lista donde se almacena a cada trabajador
            Datos.Instancia.ListaTrabajadores.Agregar(Trabajador);
        }


        public void AgregarAPila(Trabajadores Trabajador)
        {
            //Lista donde se almacena a cada trabajador
            Datos.Instancia.PilaTrabajadores.Agregar(Trabajador);
        }

        public double SueldoFinal(int NumeroCitas)
        {
            //Retorna (2 horas trabajadas dentro de oficina + 1.5 horas por cada cita) donde cada hora vale 38
            return (2 + 1.5 * NumeroCitas)*38;
        }

        //Para que IComparable e IEnumerable funcionen correctamente
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public DateTime HoraSalida (DateTime Entrada, int citas)
        {
            //Suma las horas totales a la hora inicial
            return Entrada.AddHours(2+1.5*citas);
        }

        public void SimularSalida()
        {
            BoolOficina = false;
        }

    }
}
