// ==========================================
// CLASE PRODUCTO
// ==========================================

class Producto
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public string Categoria { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }

    public Producto(
        int codigo,
        string nombre,
        string categoria,
        double precio,
        int stock)
    {
        Codigo = codigo;
        Nombre = nombre;
        Categoria = categoria;
        Precio = precio;
        Stock = stock;
    }
}