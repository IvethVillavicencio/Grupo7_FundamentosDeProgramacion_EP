using System;
using System.Collections.Generic;

namespace BoticaVillacoz
{
    // Clase que contiene la logica del sistema (menu, productos, stock, ventas y reportes)
    class Botica
    {
        private ListaProductos productos = new ListaProductos();
        private List<Venta> ventas = new List<Venta>();
        private int contadorVentas = 0;
        private const int STOCK_MINIMO_DEFECTO = 10;

        public void Ejecutar()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int opcion;
            do
            {
                MostrarMenu();
                opcion = Entrada.LeerEntero("Seleccione una opcion: ", 0, 12);
                Console.WriteLine();
                EjecutarOpcion(opcion);
                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey(true);
                }
            } while (opcion != 0);
        }

        private void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("=== BOTICA VILLACOZ ===");
            Console.WriteLine(" 1. Registrar producto");
            Console.WriteLine(" 2. Buscar producto por codigo");
            Console.WriteLine(" 3. Modificar producto");
            Console.WriteLine(" 4. Eliminar producto");
            Console.WriteLine(" 5. Mostrar productos");
            Console.WriteLine(" 6. Ordenar por nombre (burbuja)");
            Console.WriteLine(" 7. Ordenar por precio (burbuja)");
            Console.WriteLine(" 8. Consultar stock de un producto");
            Console.WriteLine(" 9. Productos con bajo stock");
            Console.WriteLine("10. Registrar venta");
            Console.WriteLine("11. Mostrar factura de la ultima venta");
            Console.WriteLine("12. Reportes");
            Console.WriteLine(" 0. Salir");
        }

        private void EjecutarOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1: RegistrarProducto(); break;
                case 2: BuscarProducto(); break;
                case 3: ModificarProducto(); break;
                case 4: EliminarProducto(); break;
                case 5: MostrarProductos(); break;
                case 6:
                    productos.OrdenarPorNombre();
                    Console.WriteLine("Productos ordenados por nombre (burbuja).");
                    MostrarProductos();
                    break;
                case 7:
                    productos.OrdenarPorPrecio();
                    Console.WriteLine("Productos ordenados por precio (burbuja).");
                    MostrarProductos();
                    break;
                case 8: ConsultarStock(); break;
                case 9: MostrarBajoStock(); break;
                case 10: RegistrarVenta(); break;
                case 11: MostrarFactura(); break;
                case 12: MenuReportes(); break;
                case 0: Console.WriteLine("Saliendo del sistema..."); break;
            }
        }

        // ---------- GESTION DE PRODUCTOS ----------
        private void RegistrarProducto()
        {
            Console.WriteLine("--- REGISTRAR PRODUCTO ---");
            int codigo = Entrada.LeerEntero("Codigo del producto: ", 1);
            if (productos.Existe(codigo))
            {
                Console.WriteLine("Error: el codigo ya existe.");
                return;
            }
            string nombre = Entrada.LeerTexto("Nombre del producto: ");
            string categoria = Entrada.LeerTexto("Categoria: ");
            decimal precio = Entrada.LeerPrecio("Precio (S/): ");
            int stock = Entrada.LeerEntero("Cantidad en stock: ", 0);

            productos.Agregar(new Producto
            {
                Codigo = codigo,
                Nombre = nombre,
                Categoria = categoria,
                Precio = precio,
                Stock = stock
            });
            Console.WriteLine("Producto registrado correctamente.");
        }

        private void BuscarProducto()
        {
            Console.WriteLine("--- BUSCAR PRODUCTO ---");
            int codigo = Entrada.LeerEntero("Codigo a buscar: ", 1);
            Producto p = productos.Buscar(codigo);
            if (p == null)
                Console.WriteLine("Producto no encontrado.");
            else
            {
                Console.WriteLine("Producto encontrado:");
                Console.WriteLine(p);
            }
        }

        private void ModificarProducto()
        {
            Console.WriteLine("--- MODIFICAR PRODUCTO ---");
            int codigo = Entrada.LeerEntero("Codigo del producto a modificar: ", 1);
            Producto p = productos.Buscar(codigo);
            if (p == null)
            {
                Console.WriteLine("Producto no encontrado.");
                return;
            }
            Console.WriteLine("Datos actuales: " + p);
            p.Nombre = Entrada.LeerTexto("Nuevo nombre: ");
            p.Categoria = Entrada.LeerTexto("Nueva categoria: ");
            p.Precio = Entrada.LeerPrecio("Nuevo precio (S/): ");
            p.Stock = Entrada.LeerEntero("Nuevo stock: ", 0);
            Console.WriteLine("Producto modificado correctamente.");
        }

        private void EliminarProducto()
        {
            Console.WriteLine("--- ELIMINAR PRODUCTO ---");
            int codigo = Entrada.LeerEntero("Codigo del producto a eliminar: ", 1);
            Producto p = productos.Buscar(codigo);
            if (p == null)
            {
                Console.WriteLine("Producto no encontrado.");
                return;
            }
            Console.WriteLine(p);
            if (Entrada.LeerSiNo("¿Seguro que desea eliminarlo? (S/N): "))
            {
                productos.Eliminar(codigo);
                Console.WriteLine("Producto eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Operacion cancelada.");
            }
        }

        private void MostrarProductos()
        {
            Console.WriteLine("--- LISTA DE PRODUCTOS ---");
            if (productos.Cantidad == 0)
            {
                Console.WriteLine("No hay productos registrados.");
                return;
            }
            foreach (Producto p in productos.ObtenerTodos())
                Console.WriteLine(p);
        }

        // ---------- STOCK ----------
        private void ConsultarStock()
        {
            Console.WriteLine("--- CONSULTAR STOCK ---");
            int codigo = Entrada.LeerEntero("Codigo del producto: ", 1);
            Producto p = productos.Buscar(codigo);
            if (p == null)
                Console.WriteLine("Producto no encontrado.");
            else
                Console.WriteLine($"Producto: {p.Nombre} | Stock disponible: {p.Stock} unidades");
        }

        private void MostrarBajoStock()
        {
            Console.WriteLine("--- PRODUCTOS CON BAJO STOCK ---");
            int limite = Entrada.LeerEntero($"Limite de stock minimo (ej. {STOCK_MINIMO_DEFECTO}): ", 0);
            ImprimirBajoStock(limite);
        }

        private void ImprimirBajoStock(int limite)
        {
            bool hay = false;
            foreach (Producto p in productos.ObtenerTodos())
            {
                if (p.Stock <= limite)
                {
                    Console.WriteLine(p);
                    hay = true;
                }
            }
            if (!hay)
                Console.WriteLine($"No hay productos con stock igual o menor a {limite}.");
        }

        // ---------- VENTAS ----------
        private void RegistrarVenta()
        {
            Console.WriteLine("--- REGISTRAR VENTA ---");
            if (productos.Cantidad == 0)
            {
                Console.WriteLine("No hay productos registrados para vender.");
                return;
            }

            Venta venta = new Venta { Fecha = DateTime.Now };
            bool agregarOtro;
            do
            {
                int codigo = Entrada.LeerEntero("Codigo del producto: ", 1);
                Producto p = productos.Buscar(codigo);

                if (p == null)
                {
                    Console.WriteLine("Producto no encontrado.");
                }
                else if (p.Stock == 0)
                {
                    Console.WriteLine("Producto sin stock.");
                }
                else
                {
                    Console.WriteLine(p);
                    int cantidad = Entrada.LeerEntero("Cantidad a vender: ", 1);
                    if (cantidad > p.Stock)
                    {
                        Console.WriteLine($"Error: stock insuficiente (disponible: {p.Stock}).");
                    }
                    else
                    {
                        p.Stock -= cantidad; // descuenta el stock vendido
                        venta.Detalles.Add(new DetalleVenta
                        {
                            Codigo = p.Codigo,
                            Nombre = p.Nombre,
                            PrecioUnitario = p.Precio,
                            Cantidad = cantidad
                        });
                        Console.WriteLine($"Subtotal: S/ {p.Precio * cantidad:F2} | Stock restante: {p.Stock}");
                    }
                }
                agregarOtro = Entrada.LeerSiNo("¿Desea agregar otro producto? (S/N): ");
            } while (agregarOtro);

            if (venta.Detalles.Count == 0)
            {
                Console.WriteLine("No se registro ninguna venta.");
                return;
            }

            contadorVentas++;
            venta.Numero = contadorVentas;
            ventas.Add(venta);
            Console.WriteLine($"\nVenta N° {venta.Numero} registrada correctamente. Total: S/ {venta.Total:F2}");
        }

        private void MostrarFactura()
        {
            Console.WriteLine("--- FACTURA DE LA ULTIMA VENTA ---");
            if (ventas.Count == 0)
            {
                Console.WriteLine("Aun no se han registrado ventas.");
                return;
            }
            Venta v = ventas[ventas.Count - 1];
            Console.WriteLine("====================================");
            Console.WriteLine("         BOTICA VILLACOZ");
            Console.WriteLine("====================================");
            Console.WriteLine($"Venta N°: {v.Numero}");
            Console.WriteLine($"Fecha:    {v.Fecha:dd/MM/yyyy HH:mm}");
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"{"Producto",-18}{"Cant",5}{"P.Unit",8}{"Subtotal",10}");
            foreach (DetalleVenta d in v.Detalles)
                Console.WriteLine($"{d.Nombre,-18}{d.Cantidad,5}{d.PrecioUnitario,8:F2}{d.Subtotal,10:F2}");
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"TOTAL: S/ {v.Total:F2}");
            Console.WriteLine("====================================");
        }

        // ---------- REPORTES ----------
        private void MenuReportes()
        {
            Console.WriteLine("--- REPORTES ---");
            Console.WriteLine("1. Reporte de productos");
            Console.WriteLine("2. Reporte de bajo stock");
            Console.WriteLine("3. Reporte de ventas");
            Console.WriteLine("4. Resumen general");
            int op = Entrada.LeerEntero("Seleccione un reporte: ", 1, 4);
            Console.WriteLine();

            switch (op)
            {
                case 1: MostrarProductos(); break;
                case 2:
                    Console.WriteLine("--- REPORTE DE BAJO STOCK ---");
                    ImprimirBajoStock(Entrada.LeerEntero($"Limite de stock minimo (ej. {STOCK_MINIMO_DEFECTO}): ", 0));
                    break;
                case 3: ReporteVentas(); break;
                case 4: ResumenGeneral(); break;
            }
        }

        private void ReporteVentas()
        {
            Console.WriteLine("--- REPORTE DE VENTAS ---");
            if (ventas.Count == 0)
            {
                Console.WriteLine("Aun no se han registrado ventas.");
                return;
            }
            decimal acumulado = 0;
            foreach (Venta v in ventas)
            {
                Console.WriteLine($"Venta N° {v.Numero} | {v.Fecha:dd/MM/yyyy HH:mm} | Items: {v.Detalles.Count} | Total: S/ {v.Total:F2}");
                acumulado += v.Total;
            }
            Console.WriteLine($"\nTotal de ventas: {ventas.Count} | Monto acumulado: S/ {acumulado:F2}");
        }

        private void ResumenGeneral()
        {
            Console.WriteLine("=== RESUMEN GENERAL ===");
            int unidades = 0, agotados = 0;
            decimal valorInventario = 0;
            foreach (Producto p in productos.ObtenerTodos())
            {
                unidades += p.Stock;
                valorInventario += p.Precio * p.Stock;
                if (p.Stock == 0) agotados++;
            }
            decimal totalVendido = 0;
            foreach (Venta v in ventas) totalVendido += v.Total;

            Console.WriteLine($"Tipos de productos: {productos.Cantidad}");
            Console.WriteLine($"Unidades disponibles: {unidades}");
            Console.WriteLine($"Productos agotados: {agotados}");
            Console.WriteLine($"Valor del inventario: S/ {valorInventario:F2}");
            Console.WriteLine($"Ventas realizadas: {ventas.Count}");
            Console.WriteLine($"Total vendido: S/ {totalVendido:F2}");
        }
    }
}
