using Dapper;
using DigitalWare.Facturacion.AccesoDatos.Contracts;
using DigitalWare.Facturacion.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DigitalWare.Facturacion.AccesoDatos.Repositories
{
    public class FacturaRepository : Repository, IFacturaRepository
    {
        public async Task<E_Factura> DevolverPorNumero(string Numero)
        {
            using (var oConn = GetSqlConnection())
            {
                oConn.Open();
                var oDictionary = new Dictionary<int, E_Factura>();
                var resul = await oConn.QueryAsync<E_Factura, E_Detalle, E_Producto, E_Lista_Precio, E_Cliente, E_Factura>
                (
                "FacturaGetAllOrSearch",
                (f, d, p, l, c) =>
                {
                    E_Factura Entity;

                    if (!oDictionary.TryGetValue(p.Id, out Entity))
                    {
                        Entity = f;
                        Entity.Detalle = new List<E_Detalle>();
                        oDictionary.Add(Entity.Id, Entity);
                    }
                    f.Cliente = c;
                    d.Producto = p;
                    d.Lista_Precio = l;
                    Entity.Detalle.Add(d);
                    
                    return Entity;
                },
                new { Codigo = Numero },
                splitOn: "Id",
                commandType: CommandType.StoredProcedure
                );

                return resul.Distinct().ToList().FirstOrDefault();
            }
        }

       

        public async Task<E_Factura> Insertar(E_Factura entity)
        {
            using (var oConn = GetSqlConnection())
            {
                oConn.Open();
                var result = await oConn.QueryAsync<E_Factura>
                (
                    "FacturaAddOrEdit",
                    new
                    {
                        IdCliente = entity.IdCliente,
                        Subtotal = entity.SubTotal,
                        Descuento = entity.Descuento,
                        Iva = entity.Iva
                    },
                    commandType: CommandType.StoredProcedure
                );

                var factura = result.Distinct().FirstOrDefault();

                foreach (var item in entity.Detalle)
                {
                    var detalle = await oConn.QueryAsync<E_Detalle>
                    (
                    "DetalleAddOrEdit",
                    new
                    {
                        IdFactura = factura.Id,
                        IdProducto = item.IdProducto,
                        Cantidad = item.Cantidad,
                        Descuento = item.Descuento,
                        Iva = item.Iva
                    },
                    commandType: CommandType.StoredProcedure
                    );
                }

                return await DevolverPorNumero(factura.Codigo);
            }
        }

        public Task<E_Factura> Actualizar(E_Factura entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<E_Factura>> DevolverTodos()
        {
            using (var oConn = GetSqlConnection())
            {
                oConn.Open();
                var oDictionary = new Dictionary<int, E_Factura>();
                var resul = await oConn.QueryAsync<E_Factura, E_Detalle, E_Producto, E_Lista_Precio, E_Cliente, E_Factura>
                (
                "FacturaGetAllOrSearch",
                (f, d, p, l, c) =>
                {
                    E_Factura Entity;

                    if (!oDictionary.TryGetValue(p.Id, out Entity))
                    {
                        Entity = f;
                        Entity.Detalle = new List<E_Detalle>();
                        oDictionary.Add(Entity.Id, Entity);
                    }
                    f.Cliente = c;
                    d.Producto = p;
                    d.Lista_Precio = l;
                    Entity.Detalle.Add(d);

                    return Entity;
                },
                splitOn: "Id",
                commandType: CommandType.StoredProcedure
                );

                return resul.Distinct().ToList();
            }
        }

        public async Task<int> Eliminar(string Codigo)
        {
            using (var oConn = GetSqlConnection())
            {
                oConn.Open();
                var resul = await oConn.ExecuteAsync
                (
                    "FacturaDel",
                    new { Codigo = Codigo },
                    commandType: CommandType.StoredProcedure
                );
                return resul;
            }
        }
    }
}
