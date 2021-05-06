using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.Web.Api.Models
{
    public class ClienteViewModel
    {
        public string Codigo { get; set; }
        public string Identificacion { get; set; }
        public string Tipo_Documento { get; set; }
        public string NombreCompleto { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string FechaNac { get; set; }
        public string Correo { get; set; }
    }
}
