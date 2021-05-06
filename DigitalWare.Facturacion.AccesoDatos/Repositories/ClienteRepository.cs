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
    public class ClienteRepository : Repository, IClienteRepository
    {
        public Task<E_Cliente> Actualizar(E_Cliente entity)
        {
            throw new NotImplementedException();
        }

        public async Task<E_Cliente> DevolverPorCodigo(string Codigo)
        {
            using (var oConn = GetSqlConnection())
            {
                oConn.Open();
                var resul = await oConn.QueryAsync<E_Cliente, E_Tipo_Documento, E_Cliente>
                (
                    "ClienteGetAllOrSearch",
                     (c, t) =>
                     {
                         c.Tipo_Identificacion = t;
                         return c;
                     },
                    new { Codigo = Codigo },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure
                );
                return resul.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<E_Cliente>> DevolverTodos()
        {
            using (var oConn = GetSqlConnection())
            {
                oConn.Open();
                var resul = await oConn.QueryAsync<E_Cliente, E_Tipo_Documento, E_Cliente>
              (
                  "ClienteGetAllOrSearch",
                   (c, t) =>
                   {
                       c.Tipo_Identificacion = t;
                       return c;
                   },
                   splitOn: "Id",
                  commandType: CommandType.StoredProcedure
              );
                return resul.Distinct().ToList();
            }
        }

        public Task<int> Eliminar(string Codigo)
        {
            throw new NotImplementedException();
        }

        public Task<E_Cliente> Insertar(E_Cliente entity)
        {
            throw new NotImplementedException();
        }
    }
}
