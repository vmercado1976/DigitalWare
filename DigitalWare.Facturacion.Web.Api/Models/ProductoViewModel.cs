using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.Web.Api.Models
{
    public class ProductoViewModel
    {
        public string CodigoProducto { get; set; }
        [Required(ErrorMessage = "Debe Ingresar Un nombre de Producto")]
        [StringLength(maximumLength: 50)]
        public string NombreProducto { get; set; }
        [Required(ErrorMessage = "Debe Ingresar una descripción del Producto")]
        [StringLength(maximumLength: 50)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Debe Ingresar un código de categoría")]
        [StringLength(maximumLength: 6)]
        public string CodigoCategoria { get; set; }
        public CategoriaViewModel Categoria { get; set; }
        public decimal Precio { get; set; } 
    }
}
