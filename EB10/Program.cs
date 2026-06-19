using System;

namespace EB10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("====================================================");
            Console.WriteLine("   UNITEC - TELEMETRÍA GPS CON STRUCTS (CLASE 10)   ");
            Console.WriteLine("====================================================\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- 1. Intentando registrar una coordenada VÁLIDA ---");
            Console.ResetColor();

            try
            {
                CoordenadaGPS puntoValido = new CoordenadaGPS(19.4326, -99.1332);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[ÉXITO] Coordenada creada correctamente:");
                Console.WriteLine($"Latitud: {puntoValido.Latitud}° | Longitud: {puntoValido.Longitud}°");
                Console.ResetColor();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ERROR INESPERADO]: {ex.Message}");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n--- 2. Intentando registrar una coordenada INVÁLIDA ---");
            Console.ResetColor();

            try
            {
                CoordenadaGPS puntoInvalido = new CoordenadaGPS(105.0, -200.5);
                Console.WriteLine($"Latitud: {puntoInvalido.Latitud} | Longitud: {puntoInvalido.Longitud}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[CAPTURADO] Excepción de rango controlada con éxito:");
                Console.WriteLine(ex.ParamName + " -> " + ex.Message.Split('\n')[0]);
                Console.ResetColor();
            }

            Console.WriteLine("\n====================================================");
            Console.WriteLine("             Fin de la Simulación EB10              ");
            Console.WriteLine("====================================================");
        }
    }

    public readonly struct CoordenadaGPS
    {
        public double Latitud { get; }
        public double Longitud { get; }

        public CoordenadaGPS(double latitud, double longitud)
        {
            if (latitud < -90.0 || latitud > 90.0)
            {
                throw new ArgumentOutOfRangeException(nameof(latitud), "La latitud debe estar estrictamente entre -90 y 90 grados.");
            }

            if (longitud < -180.0 || longitud > 180.0)
            {
                throw new ArgumentOutOfRangeException(nameof(longitud), "La longitud debe estar estrictamente entre -180 y 180 grados.");
            }

            Latitud = latitud;
            Longitud = longitud;
        }
    }
}
