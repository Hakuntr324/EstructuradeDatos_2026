using System;

namespace EB7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("====================================================");
            Console.WriteLine("   UNITEC - SIMULADOR DEL CALL STACK (CLASE 7)   ");
            Console.WriteLine("====================================================\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- EJERCICIO A: Iniciando Cuenta Regresiva ---");
            Console.ResetColor();
            SimuladorStack.ImprimirCuentaRegresiva(3); 
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- EJERCICIO B: Sumatoria Recursiva Dinámica ---");
            Console.ResetColor();
            
            Console.Write("Introduce un número entero positivo para calcular su sumatoria: ");
            string entrada = Console.ReadLine();

            if (Validador.ValidarEntrada(entrada, out int numeroValido))
            {
                int resultado = SimuladorStack.SumarHasta(numeroValido);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n[ÉXITO] El resultado final de la sumatoria de 1 hasta {numeroValido} es: {resultado}");
                Console.ResetColor();
            }
            
            Console.WriteLine("\n====================================================");
            Console.WriteLine("             Fin de la Simulación EB7               ");
            Console.WriteLine("====================================================");
        }
    }

    public static class SimuladorStack
    {
        public static void ImprimirCuentaRegresiva(int numero)
        {
            if (numero < 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   [BASE REACHED] Caso base alcanzado. ¡Despegue! 🚀");
                Console.ResetColor();
                return;
            }

            Console.WriteLine($"-> [APILANDO] Creando marco en Call Stack para número: {numero}");
            
            ImprimirCuentaRegresiva(numero - 1);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"<- [LIBERANDO] Destruyendo marco y liberando memoria del número: {numero}");
            Console.ResetColor();
        }

        public static int SumarHasta(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            return n + SumarHasta(n - 1);
        }
    }

    public static class Validador
    {
        public static bool ValidarEntrada(string entrada, out int numero)
        {
            if (int.TryParse(entrada, out numero) && numero > 0)
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[ERROR] Entrada inválida. Solo se aceptan números enteros positivos (mayores a 0).");
                Console.ResetColor();
                return false;
            }
        }
    }
}