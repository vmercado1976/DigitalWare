using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.Web.Api.Models
{
    public class FacturaViewModel
    {
        public string NumeroFactura { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el código del cliente")]
        public string CodCliente { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public string Fecha { get; set; }
        [Required(ErrorMessage = "Debe Ingresar un valor para el subtotal")]
        public decimal SubTotal { get; set; }
        [Required(ErrorMessage = "Debe Ingresar un valor para el descuento")]
        public decimal TotalDescuento { get; set; }
        [Required(ErrorMessage = "Debe Ingresar un valor para el iva")]
        public decimal TotalIva { get; set; }
        public decimal TotalGeneral { get; set; }
        public List<DetalleViewModel> Detalle { get; set; }
    }
}
