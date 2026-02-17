using Gestion_Productos.Clase_Abstracta;
using Gestion_Productos.Patron_Singleton;
using Gestion_Productos.Pruebas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Productos
{
    
    // Archivo: Program.cs

        class Program
        {   
            static void Main(string[] args)
            {

            Console.WriteLine("=========================================");
            Console.WriteLine("PRUEBA INTEGRAL - PATRON SINGLETON");
            Console.WriteLine("=========================================");
            Console.WriteLine();

            // =======================================================
            // PRUEBA 1: VERIFICAR QUE SOLO HAY UNA INSTANCIA
            // =======================================================
            Console.WriteLine("[PRUEBA 1] Unica instancia del Singleton");
            Console.WriteLine("-----------------------------------------");

            var gestor1 = GestorProductos.Instancia;
            var gestor2 = GestorProductos.Instancia;

            Console.WriteLine($"HashCode gestor1: {gestor1.GetHashCode()}");
            Console.WriteLine($"HashCode gestor2: {gestor2.GetHashCode()}");
            Console.WriteLine($"Son la misma instancia: {gestor1 == gestor2}");
            Console.WriteLine();

            // La salida mostrará el mismo HashCode para ambas referencias, confirmando que son la misma instancia del Singleton.
            // Interesante porque el Hashcode es un identificador único para cada objeto en memoria,
            // y al ser el mismo para ambas referencias, confirma que apuntan al mismo objeto Singleton.

            // =======================================================
            // PRUEBA 2: CARGAR LISTA INICIAL DE PRODUCTOS
            // =======================================================
            Console.WriteLine("[PRUEBA 2] Carga inicial de productos");
            Console.WriteLine("--------------------------------------");

            // Crear algunos productos directamente para demostrar constructores
            var producto1 = new ProductoPrueba("Laptop Gamer", 1200.50m);
            var producto2 = new ProductoPrueba("Mouse RGB", 45.99m, 10);  // Con 10% descuento
            var producto3 = new ProductoPrueba("Teclado Mecanico", 89.99m, 15); // Con 15% descuento

            Console.WriteLine("Productos creados correctamente:");
            Console.WriteLine($"  • {producto1}");
            Console.WriteLine($"  • {producto2}");
            Console.WriteLine($"  • {producto3}");
            Console.WriteLine();

            // =======================================================
            // PRUEBA 3: AGREGAR PRODUCTOS AL GESTOR (SOBRECARGA)
            // =======================================================
            Console.WriteLine("[PRUEBA 3] Agregar productos al gestor");
            Console.WriteLine("---------------------------------------");

            // Usando el Singleton desde cualquier referencia (son la misma)
            Console.WriteLine("Agregando productos con gestor1:");
            gestor1.AgregarProducto("Laptop Gamer", 1200.50m);           // Sin descuento
            gestor1.AgregarProducto("Mouse RGB", 45.99m, 10);            // Con 10% descuento
            gestor1.AgregarProducto("Teclado Mecanico", 89.99m, 15);     // Con 15% descuento
            Console.WriteLine();

            Console.WriteLine("Agregando productos con gestor2 (misma instancia):");
            gestor2.AgregarProducto("Monitor 24 pulgadas", 250.00m);     // Sin descuento
            gestor2.AgregarProducto("Audifonos Bluetooth", 35.50m, 5);   // Con 5% descuento
            Console.WriteLine();

            // =======================================================
            // PRUEBA 4: MOSTRAR TODOS LOS PRODUCTOS
            // =======================================================
            Console.WriteLine("[PRUEBA 4] Lista completa de productos");
            Console.WriteLine("----------------------------------------");

            gestor1.MostrarTodosLosProductos();
            Console.WriteLine();

            // =======================================================
            // PRUEBA 5: BUSCAR PRODUCTOS
            // =======================================================
            Console.WriteLine("[PRUEBA 5] Busqueda de productos");
            Console.WriteLine("----------------------------------");

            string busqueda = "Mouse RGB";
            var encontrado = gestor2.BuscarProducto(busqueda);  // Buscar con gestor2

            if (encontrado != null)
            {
                Console.WriteLine($"Producto encontrado: {encontrado}");
                Console.WriteLine("Mostrando detalles completos:");
                encontrado.MostrarDetalles();
            }
            else
            {
                Console.WriteLine($"Producto '{busqueda}' no encontrado");
            }
            Console.WriteLine();

            // =======================================================
            // PRUEBA 6: ELIMINAR UN PRODUCTO
            // =======================================================
            Console.WriteLine("[PRUEBA 6] Eliminacion de productos");
            Console.WriteLine("-------------------------------------");

            Console.WriteLine("Eliminando 'Mouse RGB'...");
            bool eliminado = gestor1.EliminarProducto("Mouse RGB");

            if (eliminado)
            {
                Console.WriteLine("Producto eliminado correctamente");
            }
            Console.WriteLine();

            // =======================================================
            // PRUEBA 7: MOSTRAR LISTA DESPUES DE ELIMINAR
            // =======================================================
            Console.WriteLine("[PRUEBA 7] Lista actualizada despues de eliminacion");
            Console.WriteLine("----------------------------------------------------");

            gestor2.MostrarTodosLosProductos();  // La lista ya no tiene el producto eliminado
            Console.WriteLine();

            // =======================================================
            // PRUEBA 8: CALCULAR TOTALES
            // =======================================================
            Console.WriteLine("[PRUEBA 8] Estadisticas");
            Console.WriteLine("------------------------");

            decimal total = gestor1.CalcularTotal();
            Console.WriteLine($"Precio total de todos los productos: ${total:F2}");
            Console.WriteLine();

            // =======================================================
            // PRUEBA 9: DEMOSTRAR QUE EL SINGLETON MANTIENE LOS DATOS
            // =======================================================
            Console.WriteLine("[PRUEBA 9] Verificacion de persistencia");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Creamos una nueva referencia al Singleton:");
            var gestor3 = GestorProductos.Instancia;

            Console.WriteLine("Mostrando productos desde gestor3 (deberian ser los mismos):");
            gestor3.MostrarTodosLosProductos();

            Console.WriteLine($"Total de productos segun gestor3: {gestor3.CalcularTotal()}");
            Console.WriteLine();

            // =======================================================
            // FINAL PRUEBAS
            // =======================================================
            Console.WriteLine("=========================================");
            
            Console.WriteLine("Presione ENTER para finalizar...");
            Console.ReadLine();

        }
        }
}
