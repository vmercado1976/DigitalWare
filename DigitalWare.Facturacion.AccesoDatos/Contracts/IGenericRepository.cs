using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.AccesoDatos.Contracts
{
    public interface IGenericRepository<T> where T:class
    {
        Task<T> Insertar(T entity);
        Task<T> Actualizar(T entity);
        Task<int> Eliminar(string Codigo);
        Task<IEnumerable<T>> DevolverTodos();
    }
}
