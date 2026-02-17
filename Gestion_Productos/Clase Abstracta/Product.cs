// ===================================================
// CLASE ABSTRACTA: Producto
// ===================================================
// Propósito: Servir como plantilla/base para todos los 
// tipos de productos del sistema.
// 
// Características:
// - Es abstracta → No se puede instanciar directamente
// - Define la estructura que TODOS los productos deben tener
// ===================================================

using System;

namespace Gestion_Productos.Clase_Abstracta
{
    /// Clase abstracta que representa un producto genérico.
    /// Define las propiedades y métodos que todos los productos deben implementar.

    public abstract class Producto
    {
        // ===================================================
        // ATRIBUTOS (PROPIEDADES)
        // ===================================================

        /// Nombre del producto (ej: "Laptop", "Mouse", "Teclado")
        public string Nombre { get; set; }

        /// Precio base del producto sin descuentos
        public decimal Precio { get; set; }

        // ===================================================
        // CONSTRUCTOR
        // ===================================================
        /// Constructor protegido (solo accesible desde clases hijas)
        /// Inicializa las propiedades básicas del producto

        ///   protected = "Solo visible para la clase y sus hijas"
        ///   Es como un "permiso familiar": solo la clase y sus descendientes pueden usarlo

        protected Producto(string nombre, decimal precio)
        {
            //Control de errores: Validaciones para asegurar que el producto tenga datos válidos
            // Caso 1: El nombre es NULL
            if (nombre == null)
                throw new ArgumentNullException(nameof(nombre), "Debes proporcionar un nombre");

            // Caso 2: El nombre está vacío o son solo espacios
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío", nameof(nombre));

            // Caso 3: El nombre es demasiado largo
            if (nombre.Length > 100)
                throw new ArgumentOutOfRangeException(nameof(nombre), "El nombre es demasiado largo");

            // Caso 4: Precio negativo
            if (precio < 0)
                throw new ArgumentOutOfRangeException(nameof(precio), "El precio no puede ser negativo");

            // Caso 5: Precio cero o muy bajo (según reglas de negocio)
            if (precio < 0.01m)
                throw new ArgumentException("El precio debe ser mayor a cero", nameof(precio));

            Nombre = nombre;
            Precio = precio;
        }

        // ===================================================
        // MÉTODOS ABSTRACTOS (OBLIGATORIOS PARA LAS CLASES QUE VAN A HEREDAR)
        // ===================================================

        /// <summary>
        /// MÉTODO ABSTRACTO: Las clases que van a heredar DEBEN implementarlo
        /// Muestra en consola los detalles específicos del producto
        /// La idea de este metodo es que si o si exista cuando se herede la clase, 
        /// pero cada clase hija puede moldearlo a su manera dependiendo del tipo de producto
        /// (ej: una laptop puede mostrar RAM y procesador, mientras que un mouse puede mostrar tipo de conexión)
        /// </summary>
        public abstract void MostrarDetalles();

        // ===================================================
        // MÉTODOS DE UTILIDAD
        // ===================================================

        /// <summary>
        /// Sobrescribe el método ToString() para mostrar información básica
        /// Útil para debugging
        /// </summary>
        public override string ToString()
        {
            return $"{Nombre} - ${Precio}";
        }
    }
}
