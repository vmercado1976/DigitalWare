using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.Entidades
{
    public class E_Categoria : BaseEntity
    {
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;

        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
    }
}
