using DigitalWare.Facturacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.AccesoDatos.Contracts
{
    public interface IClienteRepository : IGenericRepository<E_Cliente>
    {
        Task<E_Cliente> DevolverPorCodigo(string Codigo);
    }
}
