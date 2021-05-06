using DigitalWare.Facturacion.AccesoDatos.Contracts;
using DigitalWare.Facturacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace DigitalWare.Facturacion.AccesoDatos.Repositories
{
    public class ProductoRepository : Repository, IProductoRepository
    {
        public async Task<E_Producto> Insertar(E_Producto entity)
        {
            using (var oConn = GetSqlConnection())
            {
                oConn.Open();
                var resul = await oConn.QueryAsync<E_Producto, E_Categoria, E_Producto>
                (
                    "ProductoAddOrEdit",
                      (p, c) =>
                      {
                          p.Categoria = c;
                          return p;
                      },
                    new { Nombre = entity.Nombre, Descripcion = entity.Descripcion, IdCategoria = entity.IdCategoria },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure
                );
                return resul.FirstOrDefault();
            }
        }

        public async Task<E_Producto> Actualizar(E_Producto entity)
        {
            using (var oConn = GetSqlConnection())
            {
                oConn.Open();
                var resul = await oConn.QueryAsync<E_Producto, E_Categoria, E_Producto>
                (
                    "ProductoAddOrEdit",
                     (p, c) =>
                     {
                         p.Categoria = c;
                         return p;
                     },
                    new { Id = entity.Id, Codigo = entity.Codigo, Nombre = entity.Nombre, Descripcion = entity.Descripcion, IdCategoria = entity.IdCategoria },
                     splitOn: "Id",
                    commandType: CommandType.StoredProcedure
                );
                return resul.FirstOrDefault();
            }
        }

        public async Task<int> Eliminar(string Codigo)
        {
            using (var oConn = GetSqlConnection())
            {
                oConn.Open();
                var resul = await oConn.ExecuteAsync
                (
                    "ProductoDel",
                    new { Codigo=Codigo },
                    commandType: CommandType.StoredProcedure
                );
                return resul;
            }
        }

        public async Task<E_Producto> DevolverPorCodigo(string Codigo)
        {
            using (var oConn = GetSqlConnection())
            {
                oConn.Open();
                var resul = await oConn.QueryAsync<E_Producto, E_Categoria, E_Lista_Precio, E_Producto>
                (
                "ProductoGetAllOrSeach",
                (p, c, l) =>
                {
                    p.Categoria = c;
                    p.Lista_Precio = l;
                    return p;
                },
                new { Codigo = Codigo },
                splitOn: "Id",
                commandType: CommandType.StoredProcedure
                );

                return resul.Distinct().ToList().FirstOrDefault();
            }
        }
        public async Task<IEnumerable<E_Producto>> DevolverTodos()
        {
            using (var oConn = GetSqlConnection())
            {
                oConn.Open();
                var resul = await oConn.QueryAsync<E_Producto, E_Categoria, E_Lista_Precio, E_Producto>
                (
                "ProductoGetAllOrSeach",
                (p, c, l) =>
                {
                    p.Categoria = c;
                    p.Lista_Precio = l;
                    return p;
                },
                splitOn: "Id",
                commandType: CommandType.StoredProcedure
                );

                return resul.Distinct().ToList();
            }
        }
    }
}
