using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.Entidades
{
    public class E_Producto: BaseEntity
    {
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private int _IdCategoria;
        private E_Categoria _Categoria;
        private E_Lista_Precio _Lista_Precio;

        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public int IdCategoria { get => _IdCategoria; set => _IdCategoria = value; }
        public E_Categoria Categoria { get => _Categoria; set => _Categoria = value; }
        public E_Lista_Precio Lista_Precio { get => _Lista_Precio; set => _Lista_Precio = value; }

    }
}
