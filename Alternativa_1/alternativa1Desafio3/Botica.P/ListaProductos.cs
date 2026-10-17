using System;

// ==========================================
// LISTA DE PRODUCTOS
// ==========================================

class ListaProductos
{
    private Nodo cabeza;

    public ListaProductos()
    {
        cabeza = null;
    }


    // ======================================
    // REGISTRAR
    // ======================================
    public void RegistrarProducto(Producto producto)
    {
        if (BuscarProducto(producto.Codigo) != null)
        {
            Console.WriteLine("\nYa existe un producto con ese código.");
            return;
        }

        Nodo nuevo = new Nodo(producto);

        if (cabeza == null)
        {
            cabeza = nuevo;
        }
        else
        {
            Nodo actual = cabeza;

            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }

            actual.Siguiente = nuevo;
        }

        Console.WriteLine("\nProducto registrado correctamente.");
    }


    // ======================================
    // BUSCAR
    // ======================================
    public Producto BuscarProducto(int codigo)
    {
        Nodo actual = cabeza;

        while (actual != null)
        {
            if (actual.Producto.Codigo == codigo)
            {
                return actual.Producto;
            }

            actual = actual.Siguiente;
        }

        return null;
    }


    // ======================================
    // MOSTRAR
    // ======================================
    public void MostrarProductos()
    {
        if (cabeza == null)
        {
            Console.WriteLine("\nNo hay productos registrados.");
            return;
        }

        Nodo actual = cabeza;

        Console.WriteLine("\n==============================================================");
        Console.WriteLine("                  PRODUCTOS DE LA BOTICA");
        Console.WriteLine("==============================================================");

        Console.WriteLine(
            "{0,-10}{1,-25}{2,-20}{3,-12}{4,-10}",
            "Codigo",
            "Nombre",
            "Categoria",
            "Precio",
            "Stock"
        );

        Console.WriteLine("--------------------------------------------------------------");

        while (actual != null)
        {
            Console.WriteLine(
                "{0,-10}{1,-25}{2,-20}{3,-12:F2}{4,-10}",
                actual.Producto.Codigo,
                actual.Producto.Nombre,
                actual.Producto.Categoria,
                actual.Producto.Precio,
                actual.Producto.Stock
            );

            actual = actual.Siguiente;
        }

        Console.WriteLine("==============================================================");
    }


    // ======================================
    // MODIFICAR
    // ======================================
    public void ModificarProducto(int codigo)
    {
        Producto producto = BuscarProducto(codigo);

        if (producto == null)
        {
            Console.WriteLine("\nProducto no encontrado.");
            return;
        }

        Console.WriteLine("\nProducto encontrado.");
        Console.WriteLine("Nombre actual: " + producto.Nombre);
        Console.WriteLine("Categoría actual: " + producto.Categoria);
        Console.WriteLine("Precio actual: S/ " + producto.Precio);
        Console.WriteLine("Stock actual: " + producto.Stock);

        string nombre;

        do
        {
            Console.Write("\nNuevo nombre: ");
            nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre no puede estar vacío.");
            }

        } while (string.IsNullOrWhiteSpace(nombre));

        producto.Nombre = nombre.Trim();


        string categoria;

        do
        {
            Console.Write("Nueva categoría: ");
            categoria = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(categoria))
            {
                Console.WriteLine("La categoría no puede estar vacía.");
            }

        } while (string.IsNullOrWhiteSpace(categoria));

        producto.Categoria = categoria.Trim();


        double precio;

        while (true)
        {
            Console.Write("Nuevo precio: S/ ");

            if (double.TryParse(Console.ReadLine(), out precio)
                && precio > 0)
            {
                break;
            }

            Console.WriteLine("Ingrese un precio válido mayor que 0.");
        }

        producto.Precio = precio;


        int stock;

        while (true)
        {
            Console.Write("Nuevo stock: ");

            if (int.TryParse(Console.ReadLine(), out stock)
                && stock >= 0)
            {
                break;
            }

            Console.WriteLine("Ingrese un stock válido.");
        }

        producto.Stock = stock;

        Console.WriteLine("\nProducto modificado correctamente.");
    }


    // ======================================
    // ELIMINAR
    // ======================================
    public void EliminarProducto(int codigo)
    {
        if (cabeza == null)
        {
            Console.WriteLine("\nNo hay productos registrados.");
            return;
        }

        if (cabeza.Producto.Codigo == codigo)
        {
            cabeza = cabeza.Siguiente;

            Console.WriteLine("\nProducto eliminado correctamente.");
            return;
        }

        Nodo actual = cabeza;

        while (actual.Siguiente != null)
        {
            if (actual.Siguiente.Producto.Codigo == codigo)
            {
                actual.Siguiente = actual.Siguiente.Siguiente;

                Console.WriteLine("\nProducto eliminado correctamente.");
                return;
            }

            actual = actual.Siguiente;
        }

        Console.WriteLine("\nProducto no encontrado.");
    }


    // ======================================
    // BURBUJA POR NOMBRE
    // ======================================
    public void OrdenarPorNombreBurbuja()
    {
        if (cabeza == null || cabeza.Siguiente == null)
        {
            Console.WriteLine("\nNo hay suficientes productos para ordenar.");
            return;
        }

        bool intercambio;

        do
        {
            intercambio = false;

            Nodo actual = cabeza;

            while (actual.Siguiente != null)
            {
                if (string.Compare(
                    actual.Producto.Nombre,
                    actual.Siguiente.Producto.Nombre,
                    StringComparison.OrdinalIgnoreCase) > 0)
                {
                    Producto temporal = actual.Producto;

                    actual.Producto = actual.Siguiente.Producto;
                    actual.Siguiente.Producto = temporal;

                    intercambio = true;
                }

                actual = actual.Siguiente;
            }

        } while (intercambio);

        Console.WriteLine(
            "\nProductos ordenados por nombre usando Burbuja."
        );
    }


    // ======================================
    // BURBUJA POR PRECIO
    // ======================================
    public void OrdenarPorPrecioBurbuja()
    {
        if (cabeza == null || cabeza.Siguiente == null)
        {
            Console.WriteLine("\nNo hay suficientes productos para ordenar.");
            return;
        }

        bool intercambio;

        do
        {
            intercambio = false;

            Nodo actual = cabeza;

            while (actual.Siguiente != null)
            {
                if (actual.Producto.Precio >
                    actual.Siguiente.Producto.Precio)
                {
                    Producto temporal = actual.Producto;

                    actual.Producto = actual.Siguiente.Producto;
                    actual.Siguiente.Producto = temporal;

                    intercambio = true;
                }

                actual = actual.Siguiente;
            }

        } while (intercambio);

        Console.WriteLine(
            "\nProductos ordenados por precio usando Burbuja."
        );
    }


    // ======================================
    // CONSULTAR STOCK
    // ======================================
    public void ConsultarStock(int codigo)
    {
        Producto producto = BuscarProducto(codigo);

        if (producto == null)
        {
            Console.WriteLine("\nProducto no encontrado.");
            return;
        }

        Console.WriteLine("\n==========================================");
        Console.WriteLine("           CONSULTA DE STOCK");
        Console.WriteLine("==========================================");
        Console.WriteLine("Código: " + producto.Codigo);
        Console.WriteLine("Producto: " + producto.Nombre);
        Console.WriteLine("Stock disponible: " + producto.Stock);
        Console.WriteLine("==========================================");
    }


    // ======================================
    // BAJO STOCK
    // ======================================
    public void MostrarBajoStock(int limite)
    {
        if (cabeza == null)
        {
            Console.WriteLine("\nNo hay productos registrados.");
            return;
        }

        Nodo actual = cabeza;

        bool encontrados = false;

        Console.WriteLine("\n==========================================");
        Console.WriteLine("        PRODUCTOS CON BAJO STOCK");
        Console.WriteLine("==========================================");

        Console.WriteLine(
            "{0,-10}{1,-25}{2,-10}",
            "Codigo",
            "Producto",
            "Stock"
        );

        Console.WriteLine("------------------------------------------");

        while (actual != null)
        {
            if (actual.Producto.Stock <= limite)
            {
                Console.WriteLine(
                    "{0,-10}{1,-25}{2,-10}",
                    actual.Producto.Codigo,
                    actual.Producto.Nombre,
                    actual.Producto.Stock
                );

                encontrados = true;
            }

            actual = actual.Siguiente;
        }

        if (!encontrados)
        {
            Console.WriteLine("No hay productos con bajo stock.");
        }

        Console.WriteLine("==========================================");
    }
}