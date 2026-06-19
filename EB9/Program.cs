using System;
using System.Diagnostics;

namespace EB9
{
    class Program
    {
        private static long[] cache = Array.Empty<long>();

        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("====================================================");
            Console.WriteLine("   UNITEC - OPTIMIZACIÓN ALGORÍTMICA (CLASE 9)      ");
            Console.WriteLine("====================================================\n");

            Console.Write("Introduce el número de término de Fibonacci a calcular (ej. 40): ");
            string? entrada = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entrada) || !int.TryParse(entrada, out int n) || n < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[ERROR] Entrada inválida. Debe ingresar un número entero mayor o igual a 0.");
                Console.ResetColor();
                return;
            }

            cache = new long[n + 1];
            for (int i = 0; i <= n; i++)
            {
                cache[i] = -1;
            }

            Stopwatch reloj = new Stopwatch();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n--- 1. Ejecutando Fibonacci Tradicional (Inseguro) ---");
            Console.ResetColor();
            
            reloj.Start();
            long resultadoInseguro = FibonacciInseguro(n);
            reloj.Stop();
            
            long tiempoInseguro = reloj.ElapsedMilliseconds;
            Console.WriteLine($"Resultado: {resultadoInseguro}");
            Console.WriteLine($"Tiempo empleado: {tiempoInseguro} ms");

            reloj.Reset();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n--- 2. Ejecutando Fibonacci Optimizado (Memoization) ---");
            Console.ResetColor();
            
            reloj.Start();
            long resultadoPro = FibonacciPro(n);
            reloj.Stop();
            
            long tiempoPro = reloj.ElapsedMilliseconds;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Resultado: {resultadoPro}");
            Console.WriteLine($"Tiempo empleado: {tiempoPro} ms");
            Console.ResetColor();

            Console.WriteLine("\n====================================================");
            Console.WriteLine($"Diferencia de rendimiento: {tiempoInseguro - tiempoPro} ms más rápido con caché.");
            Console.WriteLine("====================================================");
        }

        static long FibonacciInseguro(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            return FibonacciInseguro(n - 1) + FibonacciInseguro(n - 2);
        }

        static long FibonacciPro(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            if (cache[n] != -1)
            {
                return cache[n];
            }

            cache[n] = FibonacciPro(n - 1) + FibonacciPro(n - 2);
            return cache[n];
        }
    }
}