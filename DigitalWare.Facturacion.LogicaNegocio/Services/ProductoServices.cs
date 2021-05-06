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
    public class ProductoServices
    {
        private readonly IProductoRepository productoRepository;
        public ProductoServices()
        {
            productoRepository = new ProductoRepository();
        }

        public async Task<E_Producto> Insertar(E_Producto entity)
        {
            return await productoRepository.Insertar(entity);
        }

        public async Task<E_Producto> Actualizar(E_Producto entity)
        {
            return await productoRepository.Actualizar(entity);
        }

        public async Task<int> Eliminar(string Codigo)
        {
            return await productoRepository.Eliminar(Codigo);
        }

        public async Task<E_Producto> DevolverPorCodigo(string Codigo)
        {
            return await productoRepository.DevolverPorCodigo(Codigo);
        }

        public async Task<IEnumerable<E_Producto>> DevolverTodos()
        {
            return await productoRepository.DevolverTodos();
        }
    }
}
