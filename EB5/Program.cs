using System;

namespace ArbolBinarioBusqueda
{
   
    public class Nodo
    {
        
        public int ID { get; set; }

        
        public string Dato { get; set; } = string.Empty;

        
        public Nodo? HijoIzquierdo { get; set; }
        public Nodo? HijoDerecho { get; set; }

        
        public Nodo(int id, string dato)
        {
            ID = id;
            Dato = dato;
        }
    }

    
    public class ArbolBinario
    {
        
        public static Nodo InsertarNodo(Nodo? raiz, Nodo nuevoNodo)
        {
            
            if (raiz == null)
                return nuevoNodo;

            
            if (nuevoNodo.ID < raiz.ID)
            {
               
                raiz.HijoIzquierdo = InsertarNodo(raiz.HijoIzquierdo, nuevoNodo);
            }
            else if (nuevoNodo.ID > raiz.ID)
            {
           
                raiz.HijoDerecho = InsertarNodo(raiz.HijoDerecho, nuevoNodo);
            }

           
            return raiz; 
        }

       
        public static string? BuscarNodo(Nodo? raiz, int idTarget)
        {
            
            if (raiz == null)
                return null;

            
            if (idTarget == raiz.ID)
                return raiz.Dato;

            
            if (idTarget < raiz.ID)
            {
                
                return BuscarNodo(raiz.HijoIzquierdo, idTarget);
            }
            else
            {
               
                return BuscarNodo(raiz.HijoDerecho, idTarget);
            }
        }

        
        public static void ImprimirArbol(Nodo? raiz, string prefijo = "", bool esIzquierdo = true)
        {
            if (raiz == null) return;

            Console.WriteLine(prefijo + (esIzquierdo ? "├── " : "└── ") + $"[ID: {raiz.ID}] {raiz.Dato}");

            ImprimirArbol(raiz.HijoIzquierdo, prefijo + (esIzquierdo ? "│   " : "    "), true);
            ImprimirArbol(raiz.HijoDerecho, prefijo + (esIzquierdo ? "│   " : "    "), false);
        }
    }

   
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BIENVENIDO AL ÁRBOL DE BÚSQUEDA BINARIA (BST) ===");

            
            Nodo raiz = new Nodo(5, "Raíz (Cinco)");

           
            raiz = ArbolBinario.InsertarNodo(raiz, new Nodo(3, "Nodo Izquierda (Tres)"));
            raiz = ArbolBinario.InsertarNodo(raiz, new Nodo(7, "Nodo Derecha (Siete)"));
            raiz = ArbolBinario.InsertarNodo(raiz, new Nodo(2, "Nodo Extremo Izquierdo (Dos)"));
            raiz = ArbolBinario.InsertarNodo(raiz, new Nodo(4, "Nodo Intermedio (Cuatro)"));

           
            Console.WriteLine("\nEstructura actual del Árbol:");
            ArbolBinario.ImprimirArbol(raiz);
            Console.WriteLine("---------------------------------------------------");

           
            Console.WriteLine("\nEjecutando pruebas de búsqueda...");

            
            int idExistente = 3;
            string? resultado1 = ArbolBinario.BuscarNodo(raiz, idExistente);
            Console.WriteLine($"Buscar ID {idExistente}: {(resultado1 != null ? $"¡Encontrado! -> {resultado1}" : "No encontrado")}");

            
            int idExistente2 = 7;
            string? resultado2 = ArbolBinario.BuscarNodo(raiz, idExistente2);
            Console.WriteLine($"Buscar ID {idExistente2}: {(resultado2 != null ? $"¡Encontrado! -> {resultado2}" : "No encontrado")}");

            
            int idFalso = 99;
            string? resultado3 = ArbolBinario.BuscarNodo(raiz, idFalso);
            Console.WriteLine($"Buscar ID {idFalso}: {(resultado3 != null ? $"¡Encontrado! -> {resultado3}" : "No encontrado")}");

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
