using DigitalWare.Facturacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.AccesoDatos.Contracts
{
    public interface ICategoriaRepository : IGenericRepository<E_Categoria>
    {
        Task<E_Categoria> DevolverPorCodigo(string Codigo);
    }
}
