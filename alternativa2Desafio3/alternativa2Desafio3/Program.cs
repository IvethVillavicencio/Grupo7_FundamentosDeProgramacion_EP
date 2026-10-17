using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alternativa2Desafio3
{

    public class GestorMedicamento
    {
        public string[] facturas = new string[10];
        public string[] nombres = new string[10];
        public string[] lotes = new string[10];
        public string[] fechasVenc = new string[10];
        public int[] cantidades = new int[10];

        public int cantidad = 0; 

        public void Registrar()
        {
            if (cantidad < facturas.Length)
            {
                Console.WriteLine("N° de Factura: ");
                facturas[cantidad] = Console.ReadLine();

                Console.WriteLine("Nombre del Medicamento: ");
                nombres[cantidad] = Console.ReadLine();

                Console.WriteLine("Codigo de Lote: ");
                lotes[cantidad] = Console.ReadLine();

                Console.WriteLine("Fecha de Vencimiento (MM/AAAA): ");
                string fecha = Console.ReadLine();

                while (fecha.Length != 7 || fecha[2] != '/')
                {
                    Console.WriteLine("Formato incorrecto. Ingrese como MM/AAAA (ejemplo: 01/2027): ");
                    fecha = Console.ReadLine();
                }
                fechasVenc[cantidad] = fecha;

                Console.WriteLine("Cantidad recibida: ");
                cantidades[cantidad] = Convert.ToInt32(Console.ReadLine());

                cantidad++;
                Console.WriteLine("Medicamento registrado correctamente.");
            }
            else
            {
                Console.WriteLine("Inventario lleno.");
            }
        }

        public void Mostrar()
        {
            if (cantidad == 0)
            {
                Console.WriteLine("No hay medicamentos registrados.");
                return;
            }

            Console.WriteLine("\n*** Lista de Medicamentos en Recepcion ***");
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"\nMedicamento [{i + 1}]");
                Console.WriteLine($"Factura: {facturas[i]}");
                Console.WriteLine($"Nombre: {nombres[i]}");
                Console.WriteLine($"Lote: {lotes[i]}");
                Console.WriteLine($"Fecha de Vencimiento: {fechasVenc[i]}");
                Console.WriteLine($"Cantidad: {cantidades[i]}");
            }
        }

        public void BuscarPorLote(string loteBuscado)
        {
            for (int i = 0; i < cantidad; i++)
            {
                if (lotes[i].Equals(loteBuscado))
                {
                    Console.WriteLine("\nMedicamento encontrado:");
                    Console.WriteLine($"Factura: {facturas[i]}");
                    Console.WriteLine($"Nombre: {nombres[i]}");
                    Console.WriteLine($"Lote: {lotes[i]}");
                    Console.WriteLine($"Fecha de Vencimiento: {fechasVenc[i]}");
                    Console.WriteLine($"Cantidad: {cantidades[i]}");
                    return;
                }
            }
            Console.WriteLine("Medicamento no encontrado.");
        }

        public void Buscar()
        {
            Console.WriteLine("Ingresar el codigo de lote que desea buscar: ");
            string lote = Console.ReadLine();
            BuscarPorLote(lote);
        }

        public void OrdenamientoSeleccion()
        {
            for (int i = 0; i < cantidad - 1; i++)
            {
                int menor = i;

                for (int j = i + 1; j < cantidad; j++)
                {
                    if (cantidades[j] < cantidades[menor])
                    {
                        menor = j;
                    }
                }

                if (menor != i)
                {
                    int auxCant = cantidades[i];
                    cantidades[i] = cantidades[menor];
                    cantidades[menor] = auxCant;

                    string auxFac = facturas[i];
                    facturas[i] = facturas[menor];
                    facturas[menor] = auxFac;

                    string auxNom = nombres[i];
                    nombres[i] = nombres[menor];
                    nombres[menor] = auxNom;

                    string auxLote = lotes[i];
                    lotes[i] = lotes[menor];
                    lotes[menor] = auxLote;

                    string auxFec = fechasVenc[i];
                    fechasVenc[i] = fechasVenc[menor];
                    fechasVenc[menor] = auxFec;
                }
            }
            Console.WriteLine("Medicamentos ordenados por Seleccion segun cantidad.");
        }

        public void MedicamentoMayorCantidad()
        {
            if (cantidad == 0)
            {
                Console.WriteLine("No hay medicamentos registrados.");
                return;
            }

            int posMayor = 0;
            for (int i = 1; i < cantidad; i++)
            {
                if (cantidades[i] > cantidades[posMayor])
                {
                    posMayor = i;
                }
            }

            Console.WriteLine("\n*** MEDICAMENTO CON MAYOR INGRESO ***");
            Console.WriteLine($"Medicamento: {nombres[posMayor]} (Lote: {lotes[posMayor]}) - Cantidad: {cantidades[posMayor]} unidades");
        }

        public void MedicamentoMenorCantidad()
        {
            if (cantidad == 0)
            {
                Console.WriteLine("No hay medicamentos registrados.");
                return;
            }

            int posMenor = 0;
            for (int i = 1; i < cantidad; i++)
            {
                if (cantidades[i] < cantidades[posMenor])
                {
                    posMenor = i;
                }
            }

            Console.WriteLine("\n*** MEDICAMENTO CON MENOR INGRESO ***");
            Console.WriteLine($"Medicamento: {nombres[posMenor]} (Lote: {lotes[posMenor]}) - Cantidad: {cantidades[posMenor]} unidades");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            GestorMedicamento gestor = new GestorMedicamento();
            int opcion = 0;

            do
            {
                Console.WriteLine("\n**************** REGISTRO DE MEDICAMENTOS VILLACOZ ****************");
                Console.WriteLine("1. Registrar recepcion de medicamento.");
                Console.WriteLine("2. Mostrar todos los medicamentos registrados.");
                Console.WriteLine("3. Ordenar medicamentos por cantidad utilizando el metodo Seleccion.");
                Console.WriteLine("4. Buscar medicamento por codigo de lote.");
                Console.WriteLine("5. Mostrar medicamento con mayor cantidad recibida.");
                Console.WriteLine("6. Mostrar medicamento con menor cantidad recibida.");
                Console.WriteLine("7. SALIR");
                Console.WriteLine("Escoger una de las opciones 1-7: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        gestor.Registrar();
                        break;
                    case 2:
                        gestor.Mostrar();
                        break;
                    case 3:
                        gestor.OrdenamientoSeleccion();
                        gestor.Mostrar();
                        break;
                    case 4:
                        gestor.Buscar();
                        break;
                    case 5:
                        gestor.MedicamentoMayorCantidad();
                        break;
                    case 6:
                        gestor.MedicamentoMenorCantidad();
                        break;
                    case 7:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opcion invalida.");
                        break;
                }

            } while (opcion != 7);
        }
    }
}
