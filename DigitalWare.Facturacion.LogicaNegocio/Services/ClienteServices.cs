using DigitalWare.Facturacion.AccesoDatos.Contracts;
using DigitalWare.Facturacion.AccesoDatos.Repositories;
using DigitalWare.Facturacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.LogicaNegocio.Services
{
    public class ClienteServices
    {
        private readonly IClienteRepository clienteRepository;
        public ClienteServices()
        {
            clienteRepository = new ClienteRepository();
        }

        public async Task<E_Cliente> DevolverPorCodigo(string Codigo)
        {
            return await clienteRepository.DevolverPorCodigo(Codigo);
        }

        public async Task<IEnumerable<E_Cliente>> DevolverTodos()
        {
            return await clienteRepository.DevolverTodos();
        }
    }
}
