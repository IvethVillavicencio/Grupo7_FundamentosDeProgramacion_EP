// ==========================================
// DETALLE DE VENTA
// ==========================================

class DetalleVenta
{
    public Producto Producto { get; set; }
    public int Cantidad { get; set; }
    public double Subtotal { get; set; }

    public DetalleVenta(Producto producto, int cantidad)
    {
        Producto = producto;
        Cantidad = cantidad;

        Subtotal = producto.Precio * cantidad;
    }
}