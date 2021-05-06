using DigitalWare.Facturacion.LogicaNegocio.Services;
using DigitalWare.Facturacion.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalWare.Facturacion.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaServices categoriaServices;
        public CategoriaController()
        {
            categoriaServices = new CategoriaServices();
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public async Task<ActionResult> DevolverTodos()
        {
            try
            {
                List<CategoriaViewModel> ListaCategorias= new List<CategoriaViewModel>();
                var categorias = await categoriaServices.DevolverTodos();
                foreach (var item in categorias)
                {
                    ListaCategorias.Add(new CategoriaViewModel
                    {
                        CodigoCategoria = item.Codigo,
                        NombreCategoria = item.Nombre,
                        Descripcion = item.Descripcion
                    });
                }
                return Ok(ListaCategorias);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CategoriaController>/CT0001
        [HttpGet("{codigo}")]
        public async Task<ActionResult> DevolverPorCodigo(string codigo)
        {
            try
            {
                CategoriaViewModel categoriaViewModel = new CategoriaViewModel();
                var item = await categoriaServices.DevolverPorCodigo(codigo);
                categoriaViewModel.CodigoCategoria= item.Codigo;
                categoriaViewModel.NombreCategoria = item.Nombre;
                categoriaViewModel.Descripcion = item.Descripcion;
                return Ok(categoriaViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
