// ==========================================
// CLASE NODO
// ==========================================

class Nodo
{
    public Producto Producto { get; set; }
    public Nodo Siguiente { get; set; }

    public Nodo(Producto producto)
    {
        Producto = producto;
        Siguiente = null;
    }
}