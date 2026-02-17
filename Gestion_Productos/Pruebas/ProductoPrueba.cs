using Gestion_Productos.Clase_Abstracta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Productos.Pruebas
{
    /// <summary>
    /// Clase de PRUEBA que hereda de Producto
    /// Ubicada en la carpeta Pruebas para mantener organización
    /// </summary>
    public class ProductoPrueba : Producto
    {
        // Constructor: llama al constructor de la clase padre
        public ProductoPrueba(string nombre, decimal precio)
            //Utilizamos "base" para pasar los parámetros al constructor de Producto
            : base(nombre, precio)
        {
        }

        // Implementación del método abstracto
        public override void MostrarDetalles()
        {
            Console.WriteLine("[PRODUCTO DE CREADO]");
            Console.WriteLine($"   Nombre: {Nombre}");
            Console.WriteLine($"   Precio: ${Precio:F2}");
            Console.WriteLine("   --------------------");
        }

        // ToString ya viene de Producto, no necesitamos reimplementarlo
    }
}
