using System;

namespace GestionMemoriaEB6
{
    
    public class Alumno
    {
        public string Nombre { get; set; } = string.Empty;
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== BIENVENIDO A LA PRÁCTICA 6: GESTIÓN DE MEMORIA ===");
                Console.WriteLine("1. Demostración de 'ref' (Intercambiar Valores)");
                Console.WriteLine("2. Demostración de 'out' (Calcular División y Residuo)");
                Console.WriteLine("3. Demostración de Referencias de Objetos (Heap vs Stack)");
                Console.WriteLine("4. Salir");
                Console.Write("\nSeleccione una opción: ");

                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        EjecutarModuloRef();
                        break;
                    case "2":
                        EjecutarModuloOut();
                        break;
                    case "3":
                        EjecutarModuloReferencias();
                        break;
                    case "4":
                        salir = true;
                        Console.WriteLine("\n¡Saliendo del programa!");
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Presione cualquier tecla para reintentar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

       
        static void EjecutarModuloRef()
        {
            Console.Clear();
            Console.WriteLine("--- MÓDULO 1: EL MODIFICADOR ref ---");
            
            int x = 10;
            int y = 25;

            Console.WriteLine($"Antes del intercambio: x = {x}, y = {y}");
            
            
            Intercambiar(ref x, ref y);

            Console.WriteLine($"Después del intercambio (Main): x = {x}, y = {y}");
            Console.WriteLine("\nNota: Las variables originales en el Stack fueron modificadas.");
            Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        static void Intercambiar(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        
        static void EjecutarModuloOut()
        {
            Console.Clear();
            Console.WriteLine("--- MÓDULO 2: EL MODIFICADOR out ---");
            
            Console.Write("Ingrese el dividendo (entero): ");
            if (!int.TryParse(Console.ReadLine(), out int dividendo)) return;

            Console.Write("Ingrese el divisor (entero): ");
            if (!int.TryParse(Console.ReadLine(), out int divisor) || divisor == 0)
            {
                Console.WriteLine("Error: El divisor no puede ser cero o inválido.");
                Console.ReadKey();
                return;
            }

          
            int cociente = CalcularYValidar(dividendo, divisor, out int resto);

            Console.WriteLine($"\nResultado:");
            Console.WriteLine($"Cociente: {cociente}");
            Console.WriteLine($"Residuo: {resto}");
            Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        static int CalcularYValidar(int dividendo, int divisor, out int residuo)
        {
            
            residuo = dividendo % divisor;
            return dividendo / divisor;
        }

       
        static void EjecutarModuloReferencias()
        {
            Console.Clear();
            Console.WriteLine("--- MÓDULO 3: COMPORTAMIENTO EN EL HEAP ---");

           
            Alumno alumno1 = new Alumno { Nombre = "Dany" };
            
            
            Alumno alumno2 = alumno1;

            Console.WriteLine($"Valor inicial de alumno1.Nombre: {alumno1.Nombre}");
            Console.WriteLine("Modificando alumno2.Nombre a '3Treum'...");
            
            alumno2.Nombre = "3Treum";

            Console.WriteLine($"\nResultado final:");
            Console.WriteLine($"alumno1.Nombre: {alumno1.Nombre}");
            Console.WriteLine($"alumno2.Nombre: {alumno2.Nombre}");
            Console.WriteLine("\nExplicación: Ambas variables apuntan al mismo espacio en el Heap.");
            Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
            Console.ReadKey();
        }
    }
}
