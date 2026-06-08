using System;

class Program
{
   
    static int SeleccionarPoligono()
    {
        int opcion;

        while (true)
        {
            Console.WriteLine("Selecciona un poligono:");
            Console.WriteLine("1. Pentagono");
            Console.WriteLine("2. Hexagono");
            Console.WriteLine("3. Heptagono");

            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        return 5;

                    case 2:
                        return 6;

                    case 3:
                        return 7;
                }
            }

            Console.WriteLine("Error: Ingresa una opcion valida.\n");
        }
    }

    
    static double LeerNumeroPositivo(string mensaje)
    {
        double valor;

        while (true)
        {
            Console.Write(mensaje);

            string? entrada = Console.ReadLine();

            if (entrada != null && double.TryParse(entrada, out valor) && valor > 0)
            {
                return valor;
            }

            Console.WriteLine("Error: Ingresa un numero decimal positivo.\n");
        }
    }

    
    static void PedirDatos(out double lado, out double apotema)
    {
        lado = LeerNumeroPositivo("Ingresa la medida del lado: ");

        apotema = LeerNumeroPositivo("Ingresa la apotema: ");
    }

    
    static double CalcularArea(int lados, double lado, double apotema)
    {
        double perimetro = lados * lado;

        double area = (perimetro * apotema) / 2;

        return area;
    }

    
    static void Main()
    {
        int lados = SeleccionarPoligono();

        double lado, apotema;

        PedirDatos(out lado, out apotema);

        double area = CalcularArea(lados, lado, apotema);

        Console.WriteLine("\nEl area del poligono es: " + area);
    }
}
