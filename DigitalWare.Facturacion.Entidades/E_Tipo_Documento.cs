using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.Entidades
{
    public class E_Tipo_Documento: BaseEntity
    {
        private string _Abreviatura;
        private string _Descripcion;

        public string Abreviatura { get => _Abreviatura; set => _Abreviatura = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
    }
}
