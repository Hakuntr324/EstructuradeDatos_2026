using System;

class Program
{
    static void CambiarValor(int x)
    {
        x = 100;
        Console.WriteLine("Dentro de CambiarValor: " + x);
    }

    static void CambiarReferencia(int[] arr)
    {
        arr[0] = 100;
        Console.WriteLine("Dentro de CambiarReferencia: " + arr[0]);
    }

    static void Main()
    {
        int numero = 5;
        int[] arreglo = { 1, 2, 3 };

        Console.WriteLine("Antes de CambiarValor: " + numero);
        CambiarValor(numero);
        Console.WriteLine("Despues de CambiarValor: " + numero);

        Console.WriteLine();

        Console.WriteLine("Antes de CambiarReferencia: " + arreglo[0]);
        CambiarReferencia(arreglo);
        Console.WriteLine("Despues de CambiarReferencia: " + arreglo[0]);
    }
}
