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
        public decimal Descuento { get; set; }

        // Constructor: llama al constructor de la clase padre
        //Sobrecargamos el constructor para incluir el descuento, pero también permitimos usarlo sin descuento (valor por defecto)
        public ProductoPrueba(string nombre, decimal precio, decimal descuento)
            //Utilizamos "base" para pasar los parámetros al constructor de Producto
            : base(nombre, precio)
        {
            Descuento = descuento;
        }

        public ProductoPrueba(string nombre, decimal precio)
            : base(nombre, precio)
        {
            Descuento = 0; // Sin descuento por defecto
        }

        // Método para calcular el precio final después de aplicar el descuento
        public decimal CalcularPrecioFinal()
        {
            return Precio - (Precio * Descuento / 100);
        }

        // Implementación del método abstracto
        public override void MostrarDetalles()
        {
            Console.WriteLine("[PRODUCTO DE CREADO]");
            Console.WriteLine($"   Nombre: {Nombre}");
            Console.WriteLine($"   Precio: ${Precio:F2}");
            if (Descuento >= 0)
                Console.WriteLine($"   Descuento: {Descuento}%");
                Console.WriteLine($"Precio final: ${CalcularPrecioFinal():F2}");
            Console.WriteLine("   --------------------");
        }

        // Sobrescribimos ToString para mostrar información del producto de forma clara
        public override string ToString()
        {
            if (Descuento > 0)
            {
                return $"{Nombre} - ${Precio:F2} ({Descuento}% descuento) - Final: ${CalcularPrecioFinal():F2}";
            }
            else
            {
                return $"{Nombre} - ${Precio:F2}";
            }
        }
    }
}
