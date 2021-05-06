using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.Entidades
{
    public class E_Factura: BaseEntity
    {
        private string _Codigo;
        private int _IdCliente;
        private E_Cliente _Cliente;
        private DateTime _Fecha;
        private decimal _SubTotal;
        private decimal _Descuento;
        private decimal _Iva;
        private decimal _Total;
        private List<E_Detalle> _Detalle;

        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public int IdCliente { get => _IdCliente; set => _IdCliente = value; }
        public E_Cliente Cliente { get => _Cliente; set => _Cliente = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public decimal SubTotal { get => _SubTotal; set => _SubTotal = value; }
        public decimal Descuento { get => _Descuento; set => _Descuento = value; }
        public decimal Iva { get => _Iva; set => _Iva = value; }
        public decimal Total { get => _Total; set => _Total = value; }
        public List<E_Detalle> Detalle { get => _Detalle; set => _Detalle = value; }
    }
}
