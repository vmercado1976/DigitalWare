using DigitalWare.Facturacion.Entidades;
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
    public class ProductoController : ControllerBase
    {
        private readonly ProductoServices productoServices;
        private readonly CategoriaServices categoriaServices;

        public ProductoController()
        {
            productoServices = new ProductoServices();
            categoriaServices = new CategoriaServices();
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<ActionResult> DevolverTodos()
        {
            try
            {
                List<ProductoViewModel> ListaProductos = new List<ProductoViewModel>();
                var productos = await productoServices.DevolverTodos();
                foreach (var item in productos)
                {
                    decimal precio=0;
                    if (item.Lista_Precio != null)
                        precio = item.Lista_Precio.Precio;

                    CategoriaViewModel categoria = new CategoriaViewModel();

                    if (item.Categoria != null) 
                    {
                        categoria.CodigoCategoria = item.Categoria.Codigo;
                        categoria.NombreCategoria = item.Categoria.Nombre;
                        categoria.Descripcion = item.Categoria.Descripcion;
                    }

                    ListaProductos.Add(new ProductoViewModel
                    {
                        CodigoProducto = item.Codigo,
                        NombreProducto = item.Nombre,
                        Descripcion = item.Descripcion,
                        CodigoCategoria = item.Categoria.Codigo,
                        Categoria = categoria,
                        Precio = precio
                    });
                }
                return Ok(ListaProductos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProductoController>/PR0001
        [HttpGet("{codigo}")]
        public async Task<ActionResult> DevolverPorCodigo(string codigo)
        {
            try
            {
               ProductoViewModel productoViewModel = new ProductoViewModel();
                var item = await productoServices.DevolverPorCodigo(codigo);
                productoViewModel.CodigoProducto = item.Codigo;
                productoViewModel.NombreProducto = item.Nombre;
                productoViewModel.Descripcion = item.Descripcion;
                productoViewModel.CodigoCategoria = item.Categoria.Codigo;

                decimal precio = 0;
                if (item.Lista_Precio != null)
                    precio = item.Lista_Precio.Precio;

                productoViewModel.Precio = precio;

                CategoriaViewModel categoria = new CategoriaViewModel();

                if (item.Categoria != null)
                {
                    categoria.CodigoCategoria = item.Categoria.Codigo;
                    categoria.NombreCategoria = item.Categoria.Nombre;
                    categoria.Descripcion = item.Categoria.Descripcion;
                }

                productoViewModel.Categoria = categoria;
                
                return Ok(productoViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<ActionResult> Insertar(ProductoViewModel model)
        {
            try
            {
                var item = new E_Producto();
                item.Nombre = model.NombreProducto;
                item.Descripcion = model.Descripcion;
                var categoria = await categoriaServices.DevolverPorCodigo(model.CodigoCategoria);
                item.IdCategoria = categoria.Id;
                var result = await productoServices.Insertar(item);
                model.CodigoProducto = result.Codigo;
                CategoriaViewModel categoriaViewModel = new CategoriaViewModel();
                categoriaViewModel.CodigoCategoria = result.Categoria.Codigo;
                categoriaViewModel.NombreCategoria = result.Categoria.Nombre;
                categoriaViewModel.Descripcion = result.Categoria.Descripcion;
                model.Categoria = categoriaViewModel;

                return Ok(model);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductoController>
        [HttpPut]
        public async Task<ActionResult> Actualizar(ProductoViewModel model)
        {
            try
            {
                var item = new E_Producto();
                item.Codigo = model.CodigoProducto;
                item.Nombre = model.NombreProducto;
                item.Descripcion = model.Descripcion;
                var categoria = await categoriaServices.DevolverPorCodigo(model.CodigoCategoria);
                item.IdCategoria = categoria.Id;
                var result = await productoServices.Actualizar(item);
                model.CodigoProducto = result.Codigo;
                CategoriaViewModel categoriaViewModel = new CategoriaViewModel();
                categoriaViewModel.CodigoCategoria = result.Categoria.Codigo;
                categoriaViewModel.NombreCategoria = result.Categoria.Nombre;
                categoriaViewModel.Descripcion = result.Categoria.Descripcion;
                model.Categoria = categoriaViewModel;
                return Ok(model);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductoController>/PR0001
        [HttpDelete("{codigo}")]
        public async Task<ActionResult> Eliminar(string codigo)
        {
            try
            {
                var result = await productoServices.Eliminar(codigo);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
