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
        // MÉTODOS ABSTRACTOS (OBLIGATORIOS PARA LAS CLASES HIJAS)
        // ===================================================

        /// <summary>
        /// MÉTODO ABSTRACTO: Las clases hijas DEBEN implementarlo
        /// Muestra en consola los detalles específicos del producto
        /// </summary>
        public abstract void MostrarDetalles();

        // ===================================================
        // MÉTODOS VIRTUALES (OPCIONALES PARA LAS CLASES HIJAS)
        // ===================================================

        /// <summary>
        /// MÉTODO VIRTUAL: Las clases hijas PUEDEN sobreescribirlo
        /// Devuelve el tipo de producto (puede ser personalizado)
        /// </summary>
        /// <returns>String con el tipo de producto</returns>
        public virtual string ObtenerTipoProducto()
        {
            return "Producto Genérico";
        }

        /// <summary>
        /// MÉTODO VIRTUAL: Calcula el precio final
        /// Por defecto retorna el precio base
        /// Las clases hijas pueden agregar descuentos, impuestos, etc.
        /// </summary>
        /// <returns>Precio final del producto</returns>
        public virtual decimal CalcularPrecioFinal()
        {
            return Precio;
        }

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
