using System;
using System.Collections.Generic;

// ==========================================
// CLASE VENTA
// ==========================================

class Venta
{
    public int Numero { get; set; }

    public DateTime Fecha { get; set; }

    public List<DetalleVenta> Detalles { get; set; }

    public double Total { get; set; }


    public Venta(int numero)
    {
        Numero = numero;

        Fecha = DateTime.Now;

        Detalles = new List<DetalleVenta>();

        Total = 0;
    }


    public void AgregarDetalle(
        Producto producto,
        int cantidad)
    {
        DetalleVenta detalle =
            new DetalleVenta(producto, cantidad);

        Detalles.Add(detalle);

        Total += detalle.Subtotal;
    }
}