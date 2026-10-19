using System;
using System.Globalization;

namespace BoticaVillacoz
{
    // Validacion de los datos que escribe el usuario
    static class Entrada
    {
        public static int LeerEntero(string mensaje, int minimo, int maximo = int.MaxValue)
        {
            while (true)
            {
                Console.Write(mensaje);
                string texto = Console.ReadLine();
                if (int.TryParse(texto, out int valor) && valor >= minimo && valor <= maximo)
                    return valor;
                Console.WriteLine("Error: ingrese un numero entero valido" +
                    (maximo == int.MaxValue ? $" (minimo {minimo})." : $" entre {minimo} y {maximo}."));
            }
        }

        public static decimal LeerPrecio(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string texto = (Console.ReadLine() ?? "").Replace(',', '.');
                if (decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal valor)
                    && valor > 0)
                    return valor;
                Console.WriteLine("Error: el precio debe ser un numero mayor a 0.");
            }
        }

        public static string LeerTexto(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string texto = (Console.ReadLine() ?? "").Trim();
                if (texto.Length > 0) return texto;
                Console.WriteLine("Error: el texto no puede estar vacio.");
            }
        }

        public static bool LeerSiNo(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string r = (Console.ReadLine() ?? "").Trim().ToUpper();
                if (r == "S") return true;
                if (r == "N") return false;
                Console.WriteLine("Error: responda S o N.");
            }
        }
    }
}
