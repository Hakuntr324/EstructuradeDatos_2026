using System;

namespace SimulacroBimestral
{
    public class UsuarioSeguro
    {
        public int Id { get; }
        public string Nombre { get; }
        private string Password { get; set; }
        public double BalanceCuenta { get; private set; }

        public UsuarioSeguro(int id, string nombre, string password, double balance)
        {
            Id = id;
            Nombre = nombre;
            Password = password;
            BalanceCuenta = balance;
        }

        public bool Debitar(double monto)
        {
            if (monto > 0 && BalanceCuenta >= monto)
            {
                BalanceCuenta -= monto;
                return true;
            }
            return false;
        }
    }

    public interface IPersistencia
    {
        void GuardarPedido(string registro);
    }

    public class BaseDatosMySQL : IPersistencia
    {
        public void GuardarPedido(string registro)
        {
            Console.WriteLine($"[DB MySQL] Transacción registrada con éxito: {registro}");
        }
    }

    public class ProcesadorPedidoMejorado
    {
        private readonly IPersistencia _persistencia;

        public ProcesadorPedidoMejorado(IPersistencia persistencia)
        {
            _persistencia = persistencia ?? throw new ArgumentNullException(nameof(persistencia));
        }

        public void Procesar(UsuarioSeguro usuario, double monto)
        {
            if (usuario.Debitar(monto))
            {
                _persistencia.GuardarPedido($"Pedido de {usuario.Nombre} por un monto de ${monto}");
                Console.WriteLine("[Procesador] Solicitud completada exitosamente.");
            }
            else
            {
                Console.WriteLine($"[Error] La transacción falló. Fondos insuficientes para el usuario: {usuario.Nombre}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== INICIANDO SISTEMA REFACTORIZADO (C# - VS CODE) ===\n");

            IPersistencia baseDatos = new BaseDatosMySQL();
            ProcesadorPedidoMejorado procesador = new ProcesadorPedidoMejorado(baseDatos);

            UsuarioSeguro cliente = new UsuarioSeguro(101, "Ricky", "passwordSegura123", 300.0);
            Console.WriteLine($"[Estado Inicial] Usuario: {cliente.Nombre} | Balance: ${cliente.BalanceCuenta}");

            Console.WriteLine("\n--- Ejecutando pedido válido de $100.00 ---");
            procesador.Procesar(cliente, 100.0);
            Console.WriteLine($"[Estado Actual] Balance: ${cliente.BalanceCuenta}");

            Console.WriteLine("\n--- Ejecutando pedido inválido de $500.00 ---");
            procesador.Procesar(cliente, 500.0);
            Console.WriteLine($"[Estado Final] Balance intacto: ${cliente.BalanceCuenta}");
            
            Console.WriteLine("\n=== FIN DE LA SIMULACIÓN DE EJECUCIÓN ===");
        }
    }
}
