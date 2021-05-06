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
    public class ClienteController : ControllerBase
    {
        private readonly ClienteServices clienteServices;
        public ClienteController()
        {
            clienteServices = new ClienteServices();
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<ActionResult> DevolverTodos()
        {
            try
            {
                List<ClienteViewModel> ListaClientes = new List<ClienteViewModel>();
                var clientes = await clienteServices.DevolverTodos();
                foreach (var item in clientes)
                {
                    ListaClientes.Add(new ClienteViewModel
                    {
                        Codigo = item.Codigo,
                        Identificacion = item.Identificacion,
                        Tipo_Documento = item.Tipo_Identificacion.Abreviatura,
                        NombreCompleto = item.NombreCompleto,
                        Direccion = item.Direccion,
                        Telefono = item.Telefono,
                        FechaNac = item.FechaNac.ToString("dd/MM/yyyy"),
                        Correo = item.Correo
                    });
                }
                return Ok(ListaClientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{codigo}")]
        public async Task<ActionResult> DevolverPorCodigo(string codigo)
        {
            try
            {
                ClienteViewModel clienteViewModel = new ClienteViewModel();
                var item = await clienteServices.DevolverPorCodigo(codigo);
                clienteViewModel.Codigo = item.Codigo;
                clienteViewModel.Identificacion = item.Identificacion;
                clienteViewModel.Tipo_Documento = item.Tipo_Identificacion.Abreviatura;
                clienteViewModel.NombreCompleto = item.NombreCompleto;
                clienteViewModel.Direccion = item.Direccion;
                clienteViewModel.Telefono = item.Telefono;
                clienteViewModel.FechaNac = item.FechaNac.ToString("dd/MM/yyyy");
                clienteViewModel.Correo = item.Correo;
                return Ok(clienteViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
