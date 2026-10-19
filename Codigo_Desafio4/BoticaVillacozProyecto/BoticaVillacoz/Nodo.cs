namespace BoticaVillacoz
{
    class Nodo
    {
        public Producto Dato;
        public Nodo Siguiente;

        public Nodo(Producto dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }
}
