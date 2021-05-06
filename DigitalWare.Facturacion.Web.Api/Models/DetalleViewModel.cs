using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.Web.Api.Models
{
    public class DetalleViewModel
    {
        public string NumeroFactura { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el código del producto")]
        public string CodigoProducto { get;set; }
        public ProductoViewModel Producto { get; set; }
        [Required(ErrorMessage = "Debe Ingresar la cantidad")]
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal PorcentajeDescuento { get; set; }
        public decimal PorcentajeIva { get; set; }
    }
}
