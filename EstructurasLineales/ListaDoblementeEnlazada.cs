﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EstructurasLineales
{
    public class ListaDoblementeEnlazada<T> : IEstructurasLineales<T>, IEnumerable<T> where T : IComparable
    {
        public Nodo<T> Cabeza { get; set; }
        public int tamaño { get; set; }

        public void Agregar(T valor)
        {
            var Nodo = new Nodo<T>(valor);
            if (tamaño == 0)
            {
                Cabeza = Nodo;
                tamaño++;
            }
            else
            {
                var NodoAux = Cabeza;
                while (NodoAux.Siguiente != null)
                {
                    NodoAux = NodoAux.Siguiente;
                }

                NodoAux.Siguiente = Nodo;
                Nodo.Anterior = NodoAux;
                tamaño++;
            }
            
        }


        public T Buscar(int position)
        {
            var NodoAux = Cabeza;
            for (int i = 0; i < position - 1; i++)
            {
                NodoAux = NodoAux.Siguiente;
            }

            return NodoAux.Valor;
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}