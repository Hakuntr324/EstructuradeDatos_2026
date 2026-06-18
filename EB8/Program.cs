using System;
using System.Numerics; 

namespace EB8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("====================================================");
            Console.WriteLine("   UNITEC - GESTIÓN DE DESBORDAMIENTO (CLASE 8)     ");
            Console.WriteLine("====================================================\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- PARTE A: Enfoques Tradicionales (int de 32 bits) ---");
            Console.ResetColor();
            Console.WriteLine("Nota: Observe cómo a partir de n=13 el resultado se corrompe por completo.\n");

            for (int i = 1; i <= 20; i++)
            {
                int resRecursivo = FactorialInt(i);
                int resIterativo = FactorialIterativo(i);
                Console.WriteLine($"n={i:D2} | Recursivo: {resRecursivo,15} | Iterativo: {resIterativo,15}");
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- PARTE B: Enfoque Profesional (BigInteger) ---");
            Console.ResetColor();
            Console.WriteLine("Calculando el factorial de 100 con precisión arbitraria:\n");

            BigInteger resultadoProfesional = FactorialProfesional(100);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"100! = {resultadoProfesional}");
            Console.ResetColor();

            Console.WriteLine("\n====================================================");
            Console.WriteLine("             Fin de la Simulación EB8               ");
            Console.WriteLine("====================================================");
        }

        static int FactorialInt(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            return n * FactorialInt(n - 1);
        }

        static int FactorialIterativo(int n)
        {
            int resultado = 1;
            for (int i = 2; i <= n; i++)
            {
                resultado *= i;
            }
            return resultado;
        }

        static BigInteger FactorialProfesional(BigInteger n)
        {
            if (n == 0 || n == 1)
            {
                return BigInteger.One;
            }
            return n * FactorialProfesional(n - 1);
        }
    }
}
