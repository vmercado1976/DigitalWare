using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalWare.Facturacion.AccesoDatos.Repositories;
using DigitalWare.Facturacion.AccesoDatos.Contracts;
using DigitalWare.Facturacion.Entidades;

namespace DigitalWare.Facturacion.LogicaNegocio.Services
{
    public class FacturaServices
    {
        private readonly IFacturaRepository facturaRepository;
        public FacturaServices()
        {
            facturaRepository = new FacturaRepository();
        }
        public async Task<E_Factura> Insertar(E_Factura entity)
        {
            return await facturaRepository.Insertar(entity);
        }

        public async Task<E_Factura> DevolverPorNumero(string Numero)
        {
            return await facturaRepository.DevolverPorNumero(Numero);
        }
        public async Task<int> Eliminar(string Codigo)
        {
            return await facturaRepository.Eliminar(Codigo);
        }
        public async Task<IEnumerable<E_Factura>> DevolverTodos()
        {
            return await facturaRepository.DevolverTodos();
        }

    }
}
