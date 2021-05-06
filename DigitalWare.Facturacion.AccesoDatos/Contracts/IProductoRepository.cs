using DigitalWare.Facturacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.AccesoDatos.Contracts
{
    public interface IProductoRepository : IGenericRepository<E_Producto>
    {
        Task<E_Producto> DevolverPorCodigo(string Codigo);
    }
}
