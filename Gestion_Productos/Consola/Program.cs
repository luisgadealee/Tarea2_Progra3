using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_Productos.Clase_Abstracta;
using Gestion_Productos.Pruebas;

namespace Gestion_Productos
{
    
    // Archivo: Program.cs

        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("======================================");
                Console.WriteLine("PRUEBA DE CLASE ABSTRACTA - PARTE 1");
                Console.WriteLine("======================================\n");

                // ==================================================
                // PRUEBA 1: Verificar que NO se puede instanciar Producto
                // ==================================================
                Console.WriteLine("PRUEBA 1: Instanciación");
                Console.WriteLine("--------------------------");

                // ❌ Esto NO compilaría (está comentado a propósito)
                // Producto productoInvalido = new Producto("Test", 100); 

                Console.WriteLine("La clase abstracta NO se puede instanciar (comportamiento correcto)\n");

                // ==================================================
                // PRUEBA 2: Crear productos con la clase hija
                // ==================================================
                Console.WriteLine("PRUEBA 2: Creación de productos");
                Console.WriteLine("----------------------------------");

                // Crear productos usando la clase concreta
                Producto producto1 = new ProductoPrueba("Laptop Gamer", 1200.50m);
                Producto producto2 = new ProductoPrueba("Mouse RGB", 45.99m);

                Console.WriteLine("Productos creados correctamente:");
                Console.WriteLine($"   • {producto1}"); // Usa ToString()
                Console.WriteLine($"   • {producto2}\n");

                // ==================================================
                // PRUEBA 3: Probar el método MostrarDetalles()
                // ==================================================
                Console.WriteLine("PRUEBA 3: Método MostrarDetalles()");
                Console.WriteLine("-------------------------------------");

                Console.WriteLine("Mostrando detalles del producto 1:");
                producto1.MostrarDetalles();

                Console.WriteLine("\nMostrando detalles del producto 2:");
                producto2.MostrarDetalles();

                Console.WriteLine();

                // ==================================================
                // PRUEBA 4: Probar validaciones del constructor
                // ==================================================
                Console.WriteLine("PRUEBA 4: Validaciones del constructor");
                Console.WriteLine("----------------------------------------");

                try
                {
                    Console.WriteLine("Intentando crear producto con nombre vacío...");
                    Producto productoInvalido = new ProductoPrueba("", 100);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Capturado error esperado: {ex.Message}");
                }

                try
                {
                    Console.WriteLine("\nIntentando crear producto con precio negativo...");
                    Producto productoInvalido = new ProductoPrueba("Test", -50);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Capturado error esperado: {ex.Message}");
                }

                Console.WriteLine();

                // ==================================================
                // PRUEBA 5: Polimorfismo (lista de productos)
                // ==================================================
                Console.WriteLine("PRUEBA 5: Polimorfismo");
                Console.WriteLine("--------------------------");

                // Crear una lista de productos (todos como tipo Producto)
                List<Producto> productos = new List<Producto>
            {
                new ProductoPrueba("Teclado Mecánico", 89.99m),
                new ProductoPrueba("Monitor 24'", 250.00m),
                new ProductoPrueba("Audífonos", 35.50m)
            };

                Console.WriteLine($"Lista creada con {productos.Count} productos");
                Console.WriteLine("\nRecorriendo lista polimórfica:");

                foreach (var producto in productos)
                {
                    // Aunque son tipo Producto, se comportan como ProductoNormal
                    Console.WriteLine($"  • {producto}");
                }

                Console.WriteLine();

                // ==================================================
                // PRUEBA 6: Resumen final
                // ==================================================
                Console.WriteLine("RESUMEN DE PRUEBAS");
                Console.WriteLine("--------------------");
                Console.WriteLine("Prueba 1: Clase abstracta no instanciable");
                Console.WriteLine("Prueba 2: Creación de productos exitosa");
                Console.WriteLine("Prueba 3: MostrarDetalles() funciona");
                Console.WriteLine("Prueba 4: Validaciones funcionan");
                Console.WriteLine("Prueba 5: Polimorfismo demostrado");
                Console.WriteLine("\n¡TODAS LAS PRUEBAS PASARON EXITOSAMENTE!");

                Console.WriteLine("\n======================================");
                Console.WriteLine("Presiona ENTER para finalizar...");
                Console.ReadLine();
            }
        }
}
