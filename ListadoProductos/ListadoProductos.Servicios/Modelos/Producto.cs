using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ListadoProductos.Servicios.Modelos
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre no puede superar 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [MaxLength(250, ErrorMessage = "La descripción no puede superar 250 caracteres.")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0.01, 999999, ErrorMessage = "El precio debe ser mayor a 0.")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio.")]
        [Range(0, 9999, ErrorMessage = "El stock debe estar entre 0 y 9999.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        [MaxLength(50, ErrorMessage = "La categoría no puede superar 50 caracteres.")]
        public string Categoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de ingreso es obligatoria.")]
        public DateTime FechaIngreso { get; set; } = DateTime.Today;
    }
}
