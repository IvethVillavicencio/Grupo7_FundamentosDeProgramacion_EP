using System;
using System.Collections.Generic;

namespace BoticaVillacoz
{
    class ListaProductos
    {
        private Nodo cabeza;
        public int Cantidad { get; private set; }

        public bool Existe(int codigo)
        {
            return Buscar(codigo) != null;
        }

        public void Agregar(Producto p)
        {
            Nodo nuevo = new Nodo(p);
            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null) actual = actual.Siguiente;
                actual.Siguiente = nuevo;
            }
            Cantidad++;
        }

        public Producto Buscar(int codigo)
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                if (actual.Dato.Codigo == codigo) return actual.Dato;
                actual = actual.Siguiente;
            }
            return null;
        }

        public bool Eliminar(int codigo)
        {
            if (cabeza == null) return false;

            if (cabeza.Dato.Codigo == codigo)
            {
                cabeza = cabeza.Siguiente;
                Cantidad--;
                return true;
            }

            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Dato.Codigo == codigo)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    Cantidad--;
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }

        public List<Producto> ObtenerTodos()
        {
            List<Producto> lista = new List<Producto>();
            Nodo actual = cabeza;
            while (actual != null)
            {
                lista.Add(actual.Dato);
                actual = actual.Siguiente;
            }
            return lista;
        }

        // Ordenamiento Burbuja por nombre (intercambia los datos de los nodos)
        public void OrdenarPorNombre()
        {
            if (cabeza == null || cabeza.Siguiente == null) return;
            bool huboCambio;
            do
            {
                huboCambio = false;
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    if (string.Compare(actual.Dato.Nombre, actual.Siguiente.Dato.Nombre,
                                       StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        Intercambiar(actual, actual.Siguiente);
                        huboCambio = true;
                    }
                    actual = actual.Siguiente;
                }
            } while (huboCambio);
        }

        // Ordenamiento Burbuja por precio (menor a mayor)
        public void OrdenarPorPrecio()
        {
            if (cabeza == null || cabeza.Siguiente == null) return;
            bool huboCambio;
            do
            {
                huboCambio = false;
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    if (actual.Dato.Precio > actual.Siguiente.Dato.Precio)
                    {
                        Intercambiar(actual, actual.Siguiente);
                        huboCambio = true;
                    }
                    actual = actual.Siguiente;
                }
            } while (huboCambio);
        }

        private void Intercambiar(Nodo a, Nodo b)
        {
            Producto aux = a.Dato;
            a.Dato = b.Dato;
            b.Dato = aux;
        }
    }
}
