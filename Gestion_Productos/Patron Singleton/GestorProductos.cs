using Gestion_Productos.Clase_Abstracta;
using Gestion_Productos.Pruebas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Productos.Patron_Singleton
{
    // Archivo: Patron_Singleton/GestorProductos.cs
    // Según el patrón Singleton, esta clase solo puede tener UNA ÚNICA INSTANCIA en toda la aplicación.
    // Una instancia global que se comparte en todo el sistema para gestionar los productos de manera centralizada.
    // Características del Singleton:
    // 1. Instancia única: Solo se crea UNA instancia de la clase (private static readonly)
    // 2. Lista de productos: La clase mantiene una lista interna de productos (private List<Producto>)
    // 3. Constructor privado: El constructor es privado para evitar que se creen instancias desde fuera de la clase
    // 4. Propiedad de acceso público: Se proporciona una propiedad pública para acceder a la instancia única (public static GestorProductos Instancia)
    // Importante usar sealed para evitar que alguien herede de esta clase y cree múltiples instancias a través de subclases

    //=======================================================================================
    public sealed class GestorProductos
    {
        //=======================================================================================
        //1. Instancia única (private static readonly)
        /// <summary>
        ///El guion bajo `_`
        ///1. Identifica campos privados**: `_productos` es un campo de clase, no una variable local
        ///2. Evita confusiones**: Diferencia claramente entre campos(`_edad`) y parámetros(`edad`)
        ///3. Estándar profesional**: Usado por Microsoft y en código profesional C#
        ///4. Mejora legibilidad**: A simple vista sabes qué pertenece a la clase
        ///5. No es obligatorio pero recomendado**: El código funciona sin él, pero es más claro con él
        /// </summary>
        //=======================================================================================

        private static readonly GestorProductos _instancia = new GestorProductos();

        //=======================================================================================
        // 2. Lista de productos con readonly
        // Se marca como readonly porque solo se asigna una vez en el constructor, pero el contenido de la lista puede cambiar
        // (agregar productos)
        // Ventaja de readonly: garantiza que la referencia a la lista no se pueda cambiar después de la inicialización,
        // lo que es ideal para un Singleton
        //=======================================================================================

        private readonly List<Producto> _productos;

        //=======================================================================================
        // 3. Constructor PRIVADO (clave del Singleton)
        // El constructor es privado para evitar que se creen instancias desde fuera de la clase
        //=======================================================================================

        private GestorProductos()
        {
            _productos = new List<Producto>();
            Console.WriteLine("Singleton creado");
        }

        //=======================================================================================
        // 4. Propiedad de acceso público
        // Proporciona una forma de acceder a la instancia única del Singleton
        //=======================================================================================
        public static GestorProductos Instancia
        {
            get { return _instancia; }
        }

        //=======================================================================================
        // 5. Métodos para gestionar productos
        //=======================================================================================

        /// Agrega un producto sin descuento
        public void AgregarProducto(string nombre, decimal precio)
        {
            // 1. Crear el producto usando ProductoPrueba
            var producto = new ProductoPrueba(nombre, precio);

            // 2. Agregarlo a la lista
            _productos.Add(producto);

            // 3. Mensaje de confirmación
            Console.WriteLine($"Producto agregado: {producto}");
        }
        //=======================================================================================

        /// Agrega un producto con descuento (SOBRECARGA)
        public void AgregarProducto(string nombre, decimal precio, decimal descuento)
        {
            // 1. Crear el producto con descuento
            var producto = new ProductoPrueba(nombre, precio, descuento);

            // 2. Agregarlo a la lista
            _productos.Add(producto);

            // 3. Mensaje de confirmación
            Console.WriteLine($"Producto agregado: {producto} (con {descuento}% descuento)");
        }
        //=======================================================================================

        // Muestra todos los productos en consola
        public void MostrarTodosLosProductos()
        {
            Console.WriteLine("\n===== LISTA DE PRODUCTOS =====");

            // 1. Verificar si hay productos
            if (_productos.Count == 0)
            {
                Console.WriteLine("No hay productos en el gestor");
            }
            else
            {
                // 2. Recorrer y mostrar cada producto
                foreach (var producto in _productos)
                {
                    producto.MostrarDetalles();
                    Console.WriteLine();  // Línea en blanco entre productos
                }

                // 3. Mostrar total
                Console.WriteLine($"   Total de productos: {_productos.Count}");
            }

            Console.WriteLine("================================");
        }
        //=======================================================================================

        // Busca un producto por nombre
        public Producto BuscarProducto(string nombre)
        {
            // Buscar en la lista (ignorando mayúsculas/minúsculas)
            return _productos.Find(p =>
                p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }
        //=======================================================================================


        // Elimina un producto por nombre
        public bool EliminarProducto(string nombre)
        {
            // 1. Buscar el producto
            var producto = BuscarProducto(nombre);

            // 2. Si existe, eliminarlo
            if (producto != null)
            {
                _productos.Remove(producto);
                Console.WriteLine($"Producto eliminado: {producto}");
                return true;
            }

            // 3. Si no existe
            Console.WriteLine($"Producto '{nombre}' no encontrado");
            return false;
        }
        //=======================================================================================

        // Calcula el precio total de todos los productos
        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var p in _productos)
            {
                total += p.Precio;
            }
            return total;
        }
        //=======================================================================================
    }
}
