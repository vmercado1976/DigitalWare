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
    public class FacturaController : ControllerBase
    {
        private readonly FacturaServices facturaServices;
        private readonly ClienteServices clienteServices;
        private readonly ProductoServices productoServices;

        public FacturaController()
        {
            facturaServices = new FacturaServices();
            clienteServices = new ClienteServices();
            productoServices = new ProductoServices();
        }

        // GET: api/<FacturaController>
        [HttpGet]
        public async Task<ActionResult> DevolverTodos()
        {
            try
            {
                List<FacturaViewModel> Listafacturas = new List<FacturaViewModel>();
                var facturas = await facturaServices.DevolverTodos();

                foreach (var fac in facturas)
                {
                    FacturaViewModel factura = new FacturaViewModel();
                    factura.NumeroFactura = fac.Codigo;
                    factura.CodCliente = fac.Cliente.Codigo;
                    var resultcli = await clienteServices.DevolverPorCodigo(fac.Cliente.Codigo);

                    ClienteViewModel cliente = new ClienteViewModel();
                    cliente.Codigo = resultcli.Codigo;
                    cliente.Identificacion = resultcli.Identificacion;
                    cliente.Tipo_Documento = resultcli.Tipo_Identificacion.Abreviatura;
                    cliente.NombreCompleto = resultcli.NombreCompleto;
                    cliente.Direccion = resultcli.Direccion;
                    cliente.Telefono = resultcli.Telefono;
                    cliente.FechaNac = resultcli.FechaNac.ToString("dd/MM/yyyy");
                    cliente.Correo = resultcli.Correo;
                    factura.Cliente = cliente;

                    factura.Fecha = fac.Fecha.ToString("dd/MM/yyyy");
                    factura.SubTotal = fac.SubTotal;
                    factura.TotalDescuento = fac.Descuento;
                    factura.TotalIva = fac.Iva;
                    factura.TotalGeneral = fac.Total;

                    List<DetalleViewModel> listaDetalle = new List<DetalleViewModel>();

                    foreach (var item in fac.Detalle)
                    {
                        DetalleViewModel detalle = new DetalleViewModel();
                        detalle.NumeroFactura = fac.Codigo;
                        detalle.CodigoProducto = item.Producto.Codigo;

                        ProductoViewModel Producto = new ProductoViewModel();
                        Producto.CodigoProducto = item.Producto.Codigo;
                        Producto.NombreProducto = item.Producto.Nombre;
                        Producto.Descripcion = item.Producto.Descripcion;
                        Producto.Precio = item.Lista_Precio.Precio;
                        detalle.Producto = Producto;

                        detalle.Cantidad = item.Cantidad;
                        detalle.Precio = item.Lista_Precio.Precio;
                        detalle.PorcentajeDescuento = item.Descuento;
                        detalle.PorcentajeIva = item.Iva;
                        listaDetalle.Add(detalle);
                    }

                    factura.Detalle = listaDetalle;
                    Listafacturas.Add(factura);
                }

                return Ok(Listafacturas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET api/<FacturaController>/5
        [HttpGet("{numero}")]
        public async Task<ActionResult> DevolverPorCodigo(string numero)
        {
            try
            {
                var fac = await facturaServices.DevolverPorNumero(numero);
                FacturaViewModel factura = new FacturaViewModel();
                factura.NumeroFactura = fac.Codigo;
                factura.CodCliente = fac.Cliente.Codigo;

                var resultcli = await clienteServices.DevolverPorCodigo(fac.Cliente.Codigo);

                ClienteViewModel cliente = new ClienteViewModel();
                cliente.Codigo = resultcli.Codigo;
                cliente.Identificacion = resultcli.Identificacion;
                cliente.Tipo_Documento = resultcli.Tipo_Identificacion.Abreviatura;
                cliente.NombreCompleto = resultcli.NombreCompleto;
                cliente.Direccion = resultcli.Direccion;
                cliente.Telefono = resultcli.Telefono;
                cliente.FechaNac = resultcli.FechaNac.ToString("dd/MM/yyyy");
                cliente.Correo = resultcli.Correo;
                factura.Cliente = cliente;

                factura.Fecha = fac.Fecha.ToString("dd/MM/yyyy");
                factura.SubTotal = fac.SubTotal;
                factura.TotalDescuento = fac.Descuento;
                factura.TotalIva = fac.Iva;
                factura.TotalGeneral = fac.Total;

                List<DetalleViewModel> listaDetalle = new List<DetalleViewModel>();

                foreach (var item in fac.Detalle)
                {
                    DetalleViewModel detalle = new DetalleViewModel();
                    detalle.NumeroFactura = fac.Codigo;
                    detalle.CodigoProducto = item.Producto.Codigo;

                    ProductoViewModel Producto = new ProductoViewModel();
                    Producto.CodigoProducto = item.Producto.Codigo;
                    Producto.NombreProducto = item.Producto.Nombre;
                    Producto.Descripcion = item.Producto.Descripcion;
                    Producto.Precio = item.Lista_Precio.Precio;
                    detalle.Producto = Producto;

                    detalle.Cantidad = item.Cantidad;
                    detalle.Precio = item.Lista_Precio.Precio;
                    detalle.PorcentajeDescuento = item.Descuento;
                    detalle.PorcentajeIva = item.Iva;
                    listaDetalle.Add(detalle);
                }

                factura.Detalle = listaDetalle;
                return Ok(factura);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<FacturaController>
        [HttpPost]
        public async Task<ActionResult> Insertar(FacturaViewModel model)
        {
            try
            {
                E_Factura factura = new E_Factura();
                var cliente = await clienteServices.DevolverPorCodigo(model.CodCliente);
                factura.IdCliente = cliente.Id;
                factura.SubTotal = model.SubTotal;
                factura.Descuento = model.TotalDescuento;
                factura.Iva = model.TotalIva;

                if (model.Detalle != null)
                {
                    factura.Detalle = new List<E_Detalle>();

                    foreach (var item in model.Detalle)
                    {
                        E_Detalle detalle = new E_Detalle();
                        var producto = await productoServices.DevolverPorCodigo(item.CodigoProducto);
                        detalle.IdProducto = producto.Id;
                        detalle.Cantidad = item.Cantidad;
                        detalle.Descuento = item.PorcentajeDescuento;
                        detalle.Iva = item.PorcentajeIva;
                        factura.Detalle.Add(detalle);
                    }
                }

                E_Factura fac = await facturaServices.Insertar(factura);
                FacturaViewModel facturaViewModel = new FacturaViewModel();
                facturaViewModel.NumeroFactura = fac.Codigo;
                facturaViewModel.CodCliente = fac.Cliente.Codigo;

                var resultcli = await clienteServices.DevolverPorCodigo(fac.Cliente.Codigo);

                ClienteViewModel clienteViewModel = new ClienteViewModel();
                clienteViewModel.Codigo = resultcli.Codigo;
                clienteViewModel.Identificacion = resultcli.Identificacion;
                clienteViewModel.Tipo_Documento = resultcli.Tipo_Identificacion.Abreviatura;
                clienteViewModel.NombreCompleto = resultcli.NombreCompleto;
                clienteViewModel.Direccion = resultcli.Direccion;
                clienteViewModel.Telefono = resultcli.Telefono;
                clienteViewModel.FechaNac = resultcli.FechaNac.ToString("dd/MM/yyyy");
                clienteViewModel.Correo = resultcli.Correo;
                facturaViewModel.Cliente = clienteViewModel;

                facturaViewModel.Fecha = fac.Fecha.ToString("dd/MM/yyyy");
                facturaViewModel.SubTotal = fac.SubTotal;
                facturaViewModel.TotalDescuento = fac.Descuento;
                facturaViewModel.TotalIva = fac.Iva;
                facturaViewModel.TotalGeneral = fac.Total;

                List<DetalleViewModel> listaDetalle = new List<DetalleViewModel>();

                foreach (var item in fac.Detalle)
                {
                    DetalleViewModel detalle = new DetalleViewModel();
                    detalle.NumeroFactura = fac.Codigo;
                    detalle.CodigoProducto = item.Producto.Codigo;

                    ProductoViewModel Producto = new ProductoViewModel();
                    Producto.CodigoProducto = item.Producto.Codigo;
                    Producto.NombreProducto = item.Producto.Nombre;
                    Producto.Descripcion = item.Producto.Descripcion;
                    Producto.Precio = item.Lista_Precio.Precio;
                    detalle.Producto = Producto;

                    detalle.Cantidad = item.Cantidad;
                    detalle.Precio = item.Lista_Precio.Precio;
                    detalle.PorcentajeDescuento = item.Descuento;
                    detalle.PorcentajeIva = item.Iva;
                    listaDetalle.Add(detalle);
                }

                facturaViewModel.Detalle = listaDetalle;
                return Ok(facturaViewModel);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE api/<FacturaController>/5
        [HttpDelete("{codigo}")]
        public async Task<ActionResult> Eliminar(string codigo)
        {
            try
            {
                var result = await facturaServices.Eliminar(codigo);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
