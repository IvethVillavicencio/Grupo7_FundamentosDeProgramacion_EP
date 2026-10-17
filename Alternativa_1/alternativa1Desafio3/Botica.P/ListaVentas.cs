using System;
using System.Collections.Generic;

// ==========================================
// LISTA DE VENTAS
// ==========================================

class ListaVentas
{
    private List<Venta> ventas;


    public ListaVentas()
    {
        ventas = new List<Venta>();
    }


    // ======================================
    // REGISTRAR VENTA
    // ======================================
    public void RegistrarVenta(Venta venta)
    {
        ventas.Add(venta);
    }


    // ======================================
    // OBTENER ÚLTIMA VENTA
    // ======================================
    public Venta ObtenerUltimaVenta()
    {
        if (ventas.Count == 0)
        {
            return null;
        }

        return ventas[ventas.Count - 1];
    }


    // ======================================
    // CANTIDAD DE VENTAS
    // ======================================
    public int CantidadVentas()
    {
        return ventas.Count;
    }


    // ======================================
    // MOSTRAR FACTURA
    // ======================================
    public void MostrarUltimaFactura()
    {
        if (ventas.Count == 0)
        {
            Console.WriteLine("\nNo existen ventas registradas.");
            return;
        }

        Venta venta = ventas[ventas.Count - 1];

        Console.WriteLine("\n");
        Console.WriteLine(
            "=============================================================="
        );

        Console.WriteLine(
            "                       BOTICA SALUD"
        );

        Console.WriteLine(
            "                     FACTURA DE VENTA"
        );

        Console.WriteLine(
            "=============================================================="
        );

        Console.WriteLine(
            "N° Venta: " +
            venta.Numero.ToString("D6")
        );

        Console.WriteLine(
            "Fecha: " +
            venta.Fecha.ToString("dd/MM/yyyy HH:mm")
        );

        Console.WriteLine(
            "--------------------------------------------------------------"
        );

        Console.WriteLine(
            "{0,-25}{1,-10}{2,-12}{3,-12}",
            "Producto",
            "Cantidad",
            "P.Unit.",
            "Subtotal"
        );

        Console.WriteLine(
            "--------------------------------------------------------------"
        );

        foreach (DetalleVenta detalle in venta.Detalles)
        {
            Console.WriteLine(
                "{0,-25}{1,-10}{2,-12:F2}{3,-12:F2}",
                detalle.Producto.Nombre,
                detalle.Cantidad,
                detalle.Producto.Precio,
                detalle.Subtotal
            );
        }

        Console.WriteLine(
            "--------------------------------------------------------------"
        );

        Console.WriteLine(
            "{0,49}{1,12:F2}",
            "TOTAL: S/ ",
            venta.Total
        );

        Console.WriteLine(
            "=============================================================="
        );

        Console.WriteLine(
            "                  GRACIAS POR SU COMPRA"
        );

        Console.WriteLine(
            "=============================================================="
        );
    }


    // ======================================
    // REPORTE DE VENTAS
    // ======================================
    public void ReporteVentas()
    {
        if (ventas.Count == 0)
        {
            Console.WriteLine("\nNo existen ventas registradas.");
            return;
        }

        Console.WriteLine(
            "\n=============================================================="
        );

        Console.WriteLine(
            "                     REPORTE DE VENTAS"
        );

        Console.WriteLine(
            "=============================================================="
        );

        Console.WriteLine(
            "{0,-12}{1,-22}{2,-15}",
            "N° Venta",
            "Fecha",
            "Total"
        );

        Console.WriteLine(
            "--------------------------------------------------------------"
        );

        double totalGeneral = 0;

        foreach (Venta venta in ventas)
        {
            Console.WriteLine(
                "{0,-12}{1,-22}S/ {2,-10:F2}",
                venta.Numero.ToString("D6"),
                venta.Fecha.ToString("dd/MM/yyyy HH:mm"),
                venta.Total
            );

            totalGeneral += venta.Total;
        }

        Console.WriteLine(
            "--------------------------------------------------------------"
        );

        Console.WriteLine(
            "Cantidad de ventas realizadas: " +
            ventas.Count
        );

        Console.WriteLine(
            "Total vendido: S/ " +
            totalGeneral.ToString("F2")
        );

        Console.WriteLine(
            "=============================================================="
        );
    }


    // ======================================
    // RESUMEN GENERAL
    // ======================================
    public void MostrarResumen()
    {
        double totalGeneral = 0;

        foreach (Venta venta in ventas)
        {
            totalGeneral += venta.Total;
        }

        Console.WriteLine(
            "\n=========================================="
        );

        Console.WriteLine(
            "           RESUMEN GENERAL"
        );

        Console.WriteLine(
            "=========================================="
        );

        Console.WriteLine(
            "Ventas realizadas: " +
            ventas.Count
        );

        Console.WriteLine(
            "Ingresos generados: S/ " +
            totalGeneral.ToString("F2")
        );

        Console.WriteLine(
            "=========================================="
        );
    }
}