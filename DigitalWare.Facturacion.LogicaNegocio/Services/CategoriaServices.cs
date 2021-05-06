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
    public class CategoriaServices
    {
        private readonly ICategoriaRepository categoriaRepository;
        public CategoriaServices()
        {
            categoriaRepository = new CategoriaRepository();
        }

        public async Task<E_Categoria> DevolverPorCodigo(string Codigo)
        {
            return await categoriaRepository.DevolverPorCodigo(Codigo);
        }

        public async Task<IEnumerable<E_Categoria>> DevolverTodos()
        {
            return await categoriaRepository.DevolverTodos();
        }
    }
}
