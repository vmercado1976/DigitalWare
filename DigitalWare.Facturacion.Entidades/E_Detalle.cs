using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.Entidades
{
    public class E_Detalle: BaseEntity
    {
        private int _IdFactura;
        private int _IdProducto;
        private E_Producto _Producto;
        private int _Cantidad;
        private int _IdPrecio;
        private E_Lista_Precio _Lista_Precio;
        private decimal _Descuento;
        private decimal _Iva;

        public int IdFactura { get => _IdFactura; set => _IdFactura = value; }
        public int IdProducto { get => _IdProducto; set => _IdProducto = value; }
        public E_Producto Producto { get => _Producto; set => _Producto = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public int IdPrecio { get => _IdPrecio; set => _IdPrecio = value; }
        public E_Lista_Precio Lista_Precio { get => _Lista_Precio; set => _Lista_Precio = value; }
        public decimal Descuento { get => _Descuento; set => _Descuento = value; }
        public decimal Iva { get => _Iva; set => _Iva = value; }
        
    }
}
