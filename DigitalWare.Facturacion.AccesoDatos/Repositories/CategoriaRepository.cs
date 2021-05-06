using Dapper;
using DigitalWare.Facturacion.AccesoDatos.Contracts;
using DigitalWare.Facturacion.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.AccesoDatos.Repositories
{
    public class CategoriaRepository : Repository, ICategoriaRepository
    {
        public Task<E_Categoria> Actualizar(E_Categoria entity)
        {
            throw new NotImplementedException();
        }

        public async Task<E_Categoria> DevolverPorCodigo(string Codigo)
        {
            using (var oConn = GetSqlConnection())
            {
                oConn.Open();
                var resul = await oConn.QueryAsync<E_Categoria>
                (
                    "CategoriaGetAllOrSearch",
                    new { Codigo=Codigo },
                    commandType: CommandType.StoredProcedure
                );
                return resul.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<E_Categoria>> DevolverTodos()
        {
            using (var oConn = GetSqlConnection())
            {
                oConn.Open();
                var resul = await oConn.QueryAsync<E_Categoria>
                (
                    "CategoriaGetAllOrSearch",
                    commandType: CommandType.StoredProcedure
                );
                return resul.Distinct().ToList();
            }
        }

        public Task<int> Eliminar(string Codigo)
        {
            throw new NotImplementedException();
        }

        public Task<E_Categoria> Insertar(E_Categoria entity)
        {
            throw new NotImplementedException();
        }
    }
}
