
using System;

class Program
{
    const int CAPACIDAD = 100;

    // Arreglo unidimensional
    static int[] codigos = new int[CAPACIDAD];

    // Arreglo bidimensional:
    // 0: codigo, 1: nombre, 2: categoria,
    // 3: precio, 4: stock
    static string[,] productos = new string[CAPACIDAD, 5];

    static int cantidad = 0;

    static void Main()
    {
        EjecutarOpciones();
    }

    // MODULO PRINCIPAL
    static void MostrarMenu()
    {
        Console.WriteLine("\n=== BOTICA SALUD TOTAL ===");
        Console.WriteLine("1. Registrar producto");
        Console.WriteLine("2. Mostrar productos");
        Console.WriteLine("3. Buscar por codigo");
        Console.WriteLine("4. Ordenar por burbuja");
        Console.WriteLine("5. Modificar producto");
        Console.WriteLine("6. Eliminar producto");
        Console.WriteLine("7. Consultar inventario");
        Console.WriteLine("8. Buscar por nombre");
        Console.WriteLine("9. Ordenar por seleccion");
        Console.WriteLine("10. Registrar venta");
        Console.WriteLine("11. Salir");
        Console.Write("Seleccione una opcion: ");
    }

    static void EjecutarOpciones()
    {
        int opcion;

        do
        {
            MostrarMenu();

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Ingrese una opcion numerica.");
                opcion = 0;
                continue;
            }

            switch (opcion)
            {
                case 1: RegistrarProducto(); break;
                case 2: MostrarProductos(); break;
                case 3: BuscarPorCodigo(); break;
                case 4: OrdenarBurbuja(); break;
                case 5: ModificarProducto(); break;
                case 6: EliminarProducto(); break;
                case 7: ConsultarInventario(); break;
                case 8: BuscarPorNombre(); break;
                case 9: OrdenarSeleccion(); break;
                case 10:RegistrarVenta(); break;
                case 11: 
                    Console.WriteLine("Sistema finalizado.");
                    break;
                default:
                    Console.WriteLine("Opcion incorrecta.");
                    break;
            }

        } while (opcion != 11);
    }

    // MODULO DE VALIDACIONES
    static bool ValidarCodigo(int codigo)
    {
        for (int i = 0; i < cantidad; i++)
        {
            if (codigos[i] == codigo)
                return false;
        }

        return true;
    }
    static bool ValidarPrecio(decimal precio)
    {
        if (precio < 0)
        {
            Console.WriteLine("El precio no puede ser negativo.");
            return false;
        }

        return true;
    }

    static bool ValidarStock(int stock)
    {
        if (stock < 0)
        {
            Console.WriteLine("El stock no puede ser negativo.");
            return false;
        }

        return true;
    }

    static bool ValidarDatos(
        string nombre, string categoria, decimal precio, int stock)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("El nombre es obligatorio.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(categoria))
        {
            Console.WriteLine("La categoria es obligatoria.");
            return false;
        }

        if (!ValidarPrecio(precio))
            return false;

        if (!ValidarStock(stock))
            return false;

        return true;
    }


    // MODULO DE REGISTRO
    static void RegistrarProducto()
    {
        if (cantidad >= CAPACIDAD)
        {
            Console.WriteLine("Inventario lleno.");
            return;
        }

        Console.Write("Codigo del producto: ");

        if (!int.TryParse(Console.ReadLine(), out int codigo) ||
            codigo <= 0)
        {
            Console.WriteLine("Codigo invalido.");
            return;
        }

        if (!ValidarCodigo(codigo))
        {
            Console.WriteLine("El codigo ya existe.");
            return;
        }

        Console.Write("Nombre del producto: ");
        string nombre = Console.ReadLine() ?? "";

        Console.Write("Categoria: ");
        string categoria = Console.ReadLine() ?? "";

        Console.Write("Precio: ");

        if (!decimal.TryParse(Console.ReadLine(), out decimal precio))
        {
            Console.WriteLine("Precio invalido.");
            return;
        }

        Console.Write("Cantidad en stock: ");

        if (!int.TryParse(Console.ReadLine(), out int stock))
        {
            Console.WriteLine("Stock invalido.");
            return;
        }

        if (!ValidarDatos(nombre, categoria, precio, stock))
            return;

        codigos[cantidad] = codigo;
        productos[cantidad, 0] = codigo.ToString();
        productos[cantidad, 1] = nombre;
        productos[cantidad, 2] = categoria;
        productos[cantidad, 3] = precio.ToString("F2");
        productos[cantidad, 4] = stock.ToString();

        cantidad++;

        Console.WriteLine("Producto registrado correctamente.");
    }

    // MODULO DE VISUALIZACION
    static void MostrarProductos()
    {
        if (cantidad == 0)
        {
            Console.WriteLine("No hay productos registrados.");
            return;
        }

        for (int i = 0; i < cantidad; i++)
        {
            MostrarProducto(i);
        }
    }

    static void MostrarProducto(int i)
    {
        Console.WriteLine(
            $"Codigo: {productos[i, 0]} | " +
            $"Nombre: {productos[i, 1]} | " +
            $"Categoria: {productos[i, 2]} | " +
            $"Precio: S/ {productos[i, 3]} | " +
            $"Stock: {productos[i, 4]}"
        );
    }

    // BUSQUEDA LINEAL POR CODIGO
    static void BuscarPorCodigo()
    {
        Console.Write("Codigo a buscar: ");

        if (!int.TryParse(Console.ReadLine(), out int codigo))
        {
            Console.WriteLine("Codigo invalido.");
            return;
        }

        for (int i = 0; i < cantidad; i++)
        {
            if (codigos[i] == codigo)
            {
                Console.WriteLine("Producto encontrado:");
                MostrarProducto(i);
                return;
            }
        }

        Console.WriteLine("Producto no encontrado.");
    }

    // BUSQUEDA LINEAL POR NOMBRE

    static void BuscarPorNombre()
    {
        Console.Write("Nombre del producto: ");
        string nombre = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("Ingrese un nombre para buscar.");
            return;
        }

        bool encontrado = false;

        for (int i = 0; i < cantidad; i++)
        {
            if (productos[i, 1].Contains(
                nombre, StringComparison.OrdinalIgnoreCase))
            {
                MostrarProducto(i);
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontraron productos.");
        }
    }


    // ORDENAMIENTO BURBUJA
    static void OrdenarBurbuja()
    {
        for (int i = 0; i < cantidad - 1; i++)
        {
            for (int j = 0; j < cantidad - 1 - i; j++)
            {
                if (codigos[j] > codigos[j + 1])
                {
                    int temporal = codigos[j];
                    codigos[j] = codigos[j + 1];
                    codigos[j + 1] = temporal;

                    IntercambiarFilas(j, j + 1);
                }
            }
        }

        Console.WriteLine("Productos ordenados por burbuja.");
        MostrarProductos();
    }

    // ORDENAMIENTO POR SELECCION
    static void OrdenarSeleccion()
    {
        for (int i = 0; i < cantidad - 1; i++)
        {
            int menor = i;

            for (int j = i + 1; j < cantidad; j++)
            {
                if (codigos[j] < codigos[menor])
                    menor = j;
            }

            if (menor != i)
            {
                int temporal = codigos[i];
                codigos[i] = codigos[menor];
                codigos[menor] = temporal;

                IntercambiarFilas(i, menor);
            }
        }

        Console.WriteLine("Productos ordenados por seleccion.");
        MostrarProductos();
    }

    // INTERCAMBIO DE FILAS DEL ARREGLO BIDIMENSIONAL
    static void IntercambiarFilas(int fila1, int fila2)
    {
        for (int k = 0; k < 5; k++)
        {
            string temporal = productos[fila1, k];
            productos[fila1, k] = productos[fila2, k];
            productos[fila2, k] = temporal;
        }
    }

    // MODIFICACION DE PRODUCTOS
    static void ModificarProducto()
    {
        Console.Write("Codigo del producto a modificar: ");

        if (!int.TryParse(Console.ReadLine(), out int codigo))
        {
            Console.WriteLine("Codigo invalido.");
            return;
        }

        for (int i = 0; i < cantidad; i++)
        {
            if (codigos[i] == codigo)
            {
                Console.WriteLine("Producto encontrado.");
                MostrarProducto(i);

                Console.Write("Nuevo nombre: ");
                string nombre = Console.ReadLine() ?? "";

                Console.Write("Nueva categoria: ");
                string categoria = Console.ReadLine() ?? "";

                Console.Write("Nuevo precio: ");

                if (!decimal.TryParse(
                    Console.ReadLine(), out decimal precio))
                {
                    Console.WriteLine("Precio invalido.");
                    return;
                }

                Console.Write("Nuevo stock: ");

                if (!int.TryParse(
                    Console.ReadLine(), out int stock))
                {
                    Console.WriteLine("Stock invalido.");
                    return;
                }

                if (!ValidarDatos(nombre, categoria, precio, stock))
                    return;

                productos[i, 1] = nombre;
                productos[i, 2] = categoria;
                productos[i, 3] = precio.ToString("F2");
                productos[i, 4] = stock.ToString();

                Console.WriteLine("Producto modificado correctamente.");
                return;
            }
        }

        Console.WriteLine("Producto no encontrado.");
    }

    // ELIMINACION DE PRODUCTOS
    static void EliminarProducto()
    {
        Console.Write("Codigo del producto a eliminar: ");

        if (!int.TryParse(Console.ReadLine(), out int codigo))
        {
            Console.WriteLine("Codigo invalido.");
            return;
        }

        for (int i = 0; i < cantidad; i++)
        {
            if (codigos[i] == codigo)
            {
                for (int j = i; j < cantidad - 1; j++)
                {
                    codigos[j] = codigos[j + 1];

                    for (int k = 0; k < 5; k++)
                        productos[j, k] = productos[j + 1, k];
                }

                cantidad--;

                codigos[cantidad] = 0;

                for (int k = 0; k < 5; k++)
                    productos[cantidad, k] = "";

                Console.WriteLine("Producto eliminado correctamente.");
                return;
            }
        }

        Console.WriteLine("Producto no encontrado.");
    }

    // CONSULTA DE INVENTARIO
    static void ConsultarInventario()
    {
        decimal valorInventario = 0;
        int unidades = 0;
        int productosAgotados = 0;

        for (int i = 0; i < cantidad; i++)
        {
            if (int.TryParse(productos[i, 4], out int stock))
            {
                unidades += stock;

                if (stock == 0)
                    productosAgotados++;
                if (decimal.TryParse(productos[i, 3], out decimal precio))
                {
                    valorInventario += precio * stock;
                }

            }
        }

        Console.WriteLine("\n=== RESUMEN DE INVENTARIO ===");
        Console.WriteLine($"Tipos de productos: {cantidad}");
        Console.WriteLine($"Unidades disponibles: {unidades}");
        Console.WriteLine($"Productos agotados: {productosAgotados}");
        Console.WriteLine($"Valor del inventario: S/ {valorInventario:F2}");
    }
    static void RegistrarVenta()
    {
        Console.Write("Codigo del producto: ");

        if (!int.TryParse(Console.ReadLine(), out int codigo))
        {
            Console.WriteLine("Codigo invalido.");
            return;
        }

        int posicion = -1;

        // Buscar producto por codigo
        for (int i = 0; i < cantidad; i++)
        {
            if (codigos[i] == codigo)
            {
                posicion = i;
                break;
            }
        }

        if (posicion == -1)
        {
            Console.WriteLine("Producto no encontrado.");
            return;
        }

        MostrarProducto(posicion);

        Console.Write("Cantidad a vender: ");

        if (!int.TryParse(Console.ReadLine(), out int unidades) ||
            unidades <= 0)
        {
            Console.WriteLine("Cantidad invalida.");
            return;
        }

        int stockActual;

        if (!int.TryParse(productos[posicion, 4], out stockActual))
        {
            Console.WriteLine("El stock del producto es invalido.");
            return;
        }

        if (unidades > stockActual)
        {
            Console.WriteLine("Stock insuficiente.");
            return;
        }


        decimal precio;

        if (!decimal.TryParse(productos[posicion, 3], out precio))
        {
            Console.WriteLine("El precio del producto es invalido.");
            return;
        }

        decimal total = precio * unidades;

        stockActual -= unidades;
        productos[posicion, 4] = stockActual.ToString();

        Console.WriteLine("\n=== RESUMEN DE VENTA ===");
        Console.WriteLine("Producto: " + productos[posicion, 1]);
        Console.WriteLine("Precio unitario: S/ " + precio.ToString("F2"));
        Console.WriteLine("Cantidad vendida: " + unidades);
        Console.WriteLine("Importe total: S/ " + total.ToString("F2"));
        Console.WriteLine("Stock restante: " + stockActual);
        Console.WriteLine("Venta registrada correctamente.");

    }
}

