using DigitalWare.Facturacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.AccesoDatos.Contracts
{
    public interface IFacturaRepository : IGenericRepository<E_Factura>
    {
        Task<E_Factura> DevolverPorNumero(string Numero);
    }
}
