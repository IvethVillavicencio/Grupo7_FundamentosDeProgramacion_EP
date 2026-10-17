using System;

// ==========================================
// PROGRAMA PRINCIPAL
// ==========================================

class Program
{
    // ======================================
    // LEER ENTERO POSITIVO
    // ======================================
    static int LeerEnteroPositivo(string mensaje)
    {
        int valor;

        while (true)
        {
            Console.Write(mensaje);

            if (int.TryParse(Console.ReadLine(), out valor)
                && valor > 0)
            {
                return valor;
            }

            Console.WriteLine(
                "Error: ingrese un número entero mayor que 0."
            );
        }
    }


    // ======================================
    // LEER ENTERO NO NEGATIVO
    // ======================================
    static int LeerEnteroNoNegativo(string mensaje)
    {
        int valor;

        while (true)
        {
            Console.Write(mensaje);

            if (int.TryParse(Console.ReadLine(), out valor)
                && valor >= 0)
            {
                return valor;
            }

            Console.WriteLine(
                "Error: ingrese un número entero válido."
            );
        }
    }


    // ======================================
    // LEER PRECIO
    // ======================================
    static double LeerPrecio(string mensaje)
    {
        double valor;

        while (true)
        {
            Console.Write(mensaje);

            if (double.TryParse(
                Console.ReadLine(),
                out valor)
                && valor > 0)
            {
                return valor;
            }

            Console.WriteLine(
                "Error: el precio debe ser mayor que 0."
            );
        }
    }


    // ======================================
    // LEER TEXTO
    // ======================================
    static string LeerTexto(string mensaje)
    {
        string texto;

        while (true)
        {
            Console.Write(mensaje);

            texto = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(texto))
            {
                return texto.Trim();
            }

            Console.WriteLine(
                "Error: este campo no puede estar vacío."
            );
        }
    }


    // ======================================
    // MAIN
    // ======================================
    static void Main()
    {
        ListaProductos lista =
            new ListaProductos();

        ListaVentas listaVentas =
            new ListaVentas();

        int numeroVenta = 1;

        int opcion;


        do
        {
            Console.Clear();

            Console.WriteLine(
                "=================================================="
            );

            Console.WriteLine(
                "              SISTEMA DE BOTICA"
            );

            Console.WriteLine(
                "=================================================="
            );


            Console.WriteLine(
                "\n              GESTIÓN DE PRODUCTOS"
            );

            Console.WriteLine(
                "--------------------------------------------------"
            );

            Console.WriteLine(
                "1. Registrar producto"
            );

            Console.WriteLine(
                "2. Buscar producto por código"
            );

            Console.WriteLine(
                "3. Modificar producto"
            );

            Console.WriteLine(
                "4. Eliminar producto"
            );

            Console.WriteLine(
                "5. Mostrar productos"
            );

            Console.WriteLine(
                "6. Ordenar productos por nombre"
            );

            Console.WriteLine(
                "7. Ordenar productos por precio"
            );


            Console.WriteLine(
                "\n              GESTIÓN DE INVENTARIO"
            );

            Console.WriteLine(
                "--------------------------------------------------"
            );

            Console.WriteLine(
                "8. Consultar stock"
            );

            Console.WriteLine(
                "9. Productos con bajo stock"
            );


            Console.WriteLine(
                "\n              GESTIÓN DE VENTAS"
            );

            Console.WriteLine(
                "--------------------------------------------------"
            );

            Console.WriteLine(
                "10. Registrar venta"
            );

            Console.WriteLine(
                "11. Mostrar factura"
            );


            Console.WriteLine(
                "\n              REPORTES"
            );

            Console.WriteLine(
                "--------------------------------------------------"
            );

            Console.WriteLine(
                "12. Reportes"
            );


            Console.WriteLine(
                "\n0. Salir"
            );

            Console.WriteLine(
                "=================================================="
            );


            Console.Write(
                "\nSeleccione una opción: "
            );


            if (!int.TryParse(
                Console.ReadLine(),
                out opcion))
            {
                opcion = -1;
            }


            switch (opcion)
            {
                // ==================================
                // REGISTRAR
                // ==================================
                case 1:

                    Console.Clear();

                    Console.WriteLine(
                        "=========================================="
                    );

                    Console.WriteLine(
                        "          REGISTRAR PRODUCTO"
                    );

                    Console.WriteLine(
                        "=========================================="
                    );

                    int codigo =
                        LeerEnteroPositivo("Código: ");

                    string nombre =
                        LeerTexto("Nombre: ");

                    string categoria =
                        LeerTexto("Categoría: ");

                    double precio =
                        LeerPrecio("Precio: S/ ");

                    int stock =
                        LeerEnteroNoNegativo("Stock: ");


                    Producto nuevoProducto =
                        new Producto(
                            codigo,
                            nombre,
                            categoria,
                            precio,
                            stock
                        );


                    lista.RegistrarProducto(
                        nuevoProducto
                    );

                    Console.ReadKey();

                    break;


                // ==================================
                // BUSCAR
                // ==================================
                case 2:

                    Console.Clear();

                    Console.WriteLine(
                        "=========================================="
                    );

                    Console.WriteLine(
                        "          BUSCAR PRODUCTO"
                    );

                    Console.WriteLine(
                        "=========================================="
                    );

                    int codigoBuscar =
                        LeerEnteroPositivo(
                            "Ingrese código: "
                        );


                    Producto encontrado =
                        lista.BuscarProducto(
                            codigoBuscar
                        );


                    if (encontrado != null)
                    {
                        Console.WriteLine(
                            "\nProducto encontrado:"
                        );

                        Console.WriteLine(
                            "Código: " +
                            encontrado.Codigo
                        );

                        Console.WriteLine(
                            "Nombre: " +
                            encontrado.Nombre
                        );

                        Console.WriteLine(
                            "Categoría: " +
                            encontrado.Categoria
                        );

                        Console.WriteLine(
                            "Precio: S/ " +
                            encontrado.Precio.ToString("F2")
                        );

                        Console.WriteLine(
                            "Stock: " +
                            encontrado.Stock
                        );
                    }
                    else
                    {
                        Console.WriteLine(
                            "\nProducto no encontrado."
                        );
                    }

                    Console.ReadKey();

                    break;


                // ==================================
                // MODIFICAR
                // ==================================
                case 3:

                    Console.Clear();

                    Console.WriteLine(
                        "=========================================="
                    );

                    Console.WriteLine(
                        "          MODIFICAR PRODUCTO"
                    );

                    Console.WriteLine(
                        "=========================================="
                    );

                    int codigoModificar =
                        LeerEnteroPositivo(
                            "Ingrese código: "
                        );

                    lista.ModificarProducto(
                        codigoModificar
                    );

                    Console.ReadKey();

                    break;


                // ==================================
                // ELIMINAR
                // ==================================
                case 4:

                    Console.Clear();

                    Console.WriteLine(
                        "=========================================="
                    );

                    Console.WriteLine(
                        "          ELIMINAR PRODUCTO"
                    );

                    Console.WriteLine(
                        "=========================================="
                    );

                    int codigoEliminar =
                        LeerEnteroPositivo(
                            "Ingrese código: "
                        );

                    lista.EliminarProducto(
                        codigoEliminar
                    );

                    Console.ReadKey();

                    break;


                // ==================================
                // MOSTRAR
                // ==================================
                case 5:

                    Console.Clear();

                    lista.MostrarProductos();

                    Console.ReadKey();

                    break;


                // ==================================
                // ORDENAR NOMBRE
                // ==================================
                case 6:

                    Console.Clear();

                    lista.OrdenarPorNombreBurbuja();

                    lista.MostrarProductos();

                    Console.ReadKey();

                    break;


                // ==================================
                // ORDENAR PRECIO
                // ==================================
                case 7:

                    Console.Clear();

                    lista.OrdenarPorPrecioBurbuja();

                    lista.MostrarProductos();

                    Console.ReadKey();

                    break;


                // ==================================
                // CONSULTAR STOCK
                // ==================================
                case 8:

                    Console.Clear();

                    int codigoStock =
                        LeerEnteroPositivo(
                            "Ingrese código: "
                        );

                    lista.ConsultarStock(
                        codigoStock
                    );

                    Console.ReadKey();

                    break;


                // ==================================
                // BAJO STOCK
                // ==================================
                case 9:

                    Console.Clear();

                    lista.MostrarBajoStock(10);

                    Console.ReadKey();

                    break;


                // ==================================
                // REGISTRAR VENTA
                // ==================================
                case 10:

                    Console.Clear();

                    Console.WriteLine(
                        "=========================================="
                    );

                    Console.WriteLine(
                        "             REGISTRAR VENTA"
                    );

                    Console.WriteLine(
                        "=========================================="
                    );


                    Venta nuevaVenta =
                        new Venta(numeroVenta);


                    bool continuarVenta = true;


                    while (continuarVenta)
                    {
                        Console.Write(
                            "\nIngrese código del producto: "
                        );


                        if (!int.TryParse(
                            Console.ReadLine(),
                            out int codigoVenta))
                        {
                            Console.WriteLine(
                                "Código inválido."
                            );

                            continue;
                        }


                        Producto productoVenta =
                            lista.BuscarProducto(
                                codigoVenta
                            );


                        if (productoVenta == null)
                        {
                            Console.WriteLine(
                                "\nProducto no encontrado."
                            );

                            continue;
                        }


                        Console.WriteLine(
                            "\nProducto encontrado:"
                        );

                        Console.WriteLine(
                            "Nombre: " +
                            productoVenta.Nombre
                        );

                        Console.WriteLine(
                            "Precio: S/ " +
                            productoVenta.Precio.ToString("F2")
                        );

                        Console.WriteLine(
                            "Stock disponible: " +
                            productoVenta.Stock
                        );


                        Console.Write(
                            "\nIngrese cantidad: "
                        );


                        if (!int.TryParse(
                            Console.ReadLine(),
                            out int cantidad))
                        {
                            Console.WriteLine(
                                "Cantidad inválida."
                            );

                            continue;
                        }


                        if (cantidad <= 0)
                        {
                            Console.WriteLine(
                                "La cantidad debe ser mayor que cero."
                            );

                            continue;
                        }


                        if (cantidad >
                            productoVenta.Stock)
                        {
                            Console.WriteLine(
                                "\nNo hay suficiente stock."
                            );

                            Console.WriteLine(
                                "Stock disponible: " +
                                productoVenta.Stock
                            );

                            continue;
                        }


                        double subtotal =
                            productoVenta.Precio *
                            cantidad;


                        Console.WriteLine(
                            "\nSubtotal: S/ " +
                            subtotal.ToString("F2")
                        );


                        productoVenta.Stock -= cantidad;


                        nuevaVenta.AgregarDetalle(
                            productoVenta,
                            cantidad
                        );


                        Console.WriteLine(
                            "\nProducto agregado a la venta."
                        );

                        Console.WriteLine(
                            "Stock restante: " +
                            productoVenta.Stock
                        );


                        Console.Write(
                            "\n¿Desea agregar otro producto? (S/N): "
                        );


                        string respuesta =
                            Console.ReadLine();


                        if (respuesta.ToUpper() != "S")
                        {
                            continuarVenta = false;
                        }
                    }


                    if (nuevaVenta.Detalles.Count > 0)
                    {
                        listaVentas.RegistrarVenta(
                            nuevaVenta
                        );

                        Console.WriteLine(
                            "\n=========================================="
                        );

                        Console.WriteLine(
                            "          VENTA REGISTRADA"
                        );

                        Console.WriteLine(
                            "=========================================="
                        );

                        Console.WriteLine(
                            "Número de venta: " +
                            nuevaVenta.Numero
                        );

                        Console.WriteLine(
                            "Total: S/ " +
                            nuevaVenta.Total.ToString("F2")
                        );

                        numeroVenta++;
                    }
                    else
                    {
                        Console.WriteLine(
                            "\nNo se registró ninguna venta."
                        );
                    }

                    Console.ReadKey();

                    break;


                // ==================================
                // FACTURA
                // ==================================
                case 11:

                    Console.Clear();

                    listaVentas.MostrarUltimaFactura();

                    Console.ReadKey();

                    break;


                // ==================================
                // REPORTES
                // ==================================
                case 12:

                    int opcionReporte;

                    do
                    {
                        Console.Clear();

                        Console.WriteLine(
                            "=========================================="
                        );

                        Console.WriteLine(
                            "               REPORTES"
                        );

                        Console.WriteLine(
                            "=========================================="
                        );

                        Console.WriteLine(
                            "1. Reporte de productos"
                        );

                        Console.WriteLine(
                            "2. Reporte de productos con bajo stock"
                        );

                        Console.WriteLine(
                            "3. Reporte de ventas"
                        );

                        Console.WriteLine(
                            "4. Resumen general"
                        );

                        Console.WriteLine(
                            "0. Regresar"
                        );


                        Console.Write(
                            "\nSeleccione una opción: "
                        );


                        if (!int.TryParse(
                            Console.ReadLine(),
                            out opcionReporte))
                        {
                            opcionReporte = -1;
                        }


                        switch (opcionReporte)
                        {
                            case 1:

                                Console.Clear();

                                lista.MostrarProductos();

                                Console.ReadKey();

                                break;


                            case 2:

                                Console.Clear();

                                lista.MostrarBajoStock(10);

                                Console.ReadKey();

                                break;


                            case 3:

                                Console.Clear();

                                listaVentas.ReporteVentas();

                                Console.ReadKey();

                                break;


                            case 4:

                                Console.Clear();

                                listaVentas.MostrarResumen();

                                Console.ReadKey();

                                break;


                            case 0:

                                break;


                            default:

                                Console.WriteLine(
                                    "\nOpción no válida."
                                );

                                Console.ReadKey();

                                break;
                        }

                    } while (opcionReporte != 0);

                    break;


                // ==================================
                // SALIR
                // ==================================
                case 0:

                    Console.WriteLine(
                        "\nSaliendo del sistema..."
                    );

                    break;


                default:

                    Console.WriteLine(
                        "\nOpción no válida."
                    );

                    Console.ReadKey();

                    break;
            }

        } while (opcion != 0);
    }
}