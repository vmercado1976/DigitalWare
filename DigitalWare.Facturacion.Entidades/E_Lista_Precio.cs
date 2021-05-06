using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.Entidades
{
    public class E_Lista_Precio: BaseEntity
    {
        private decimal _Precio;
        private DateTime _Fecha;
        private int _IdProducto;

        public decimal Precio { get => _Precio; set => _Precio = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public int IdProducto { get => _IdProducto; set => _IdProducto = value; }

    }
}
