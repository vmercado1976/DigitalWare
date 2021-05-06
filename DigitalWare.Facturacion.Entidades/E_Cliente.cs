using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.Entidades
{
    public class E_Cliente: BaseEntity
    {
        private string _Codigo;
        private string _Identificacion;
        private int _Tipo_Documento;
        private E_Tipo_Documento _Tipo_Identificacion;
        private string _NombreCompleto;
        private string _Direccion;
        private string _Telefono;
        private DateTime _FechaNac;
        private string _Correo;

        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Identificacion { get => _Identificacion; set => _Identificacion = value; }
        public int Tipo_Documento { get => _Tipo_Documento; set => _Tipo_Documento = value; }
        public E_Tipo_Documento Tipo_Identificacion { get => _Tipo_Identificacion; set => _Tipo_Identificacion = value; }
        public string NombreCompleto { get => _NombreCompleto; set => _NombreCompleto = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public DateTime FechaNac { get => _FechaNac; set => _FechaNac = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
    }
}
