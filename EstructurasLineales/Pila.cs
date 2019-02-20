using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasLineales
{
    public class Pila<T> : IEstructurasLineales<T>, IEnumerable<T> where T : IComparable
    {
        public Nodo<T> Cabeza { get; set; }
        public int tamaño { get; set; }


        public void Agregar(T valor)
        {
            var NodoAux = new Nodo<T>(valor);

            if(tamaño == 0)
            {
                Cabeza = NodoAux;
                tamaño++;
            }
            else
            {
                NodoAux.Siguiente = Cabeza;
                Cabeza = NodoAux;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var NodoAux = Cabeza;
            while (NodoAux != null)
            {
                yield return NodoAux.Valor;
                NodoAux = NodoAux.Siguiente;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
