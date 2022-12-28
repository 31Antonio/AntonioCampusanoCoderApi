using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AntonioCampusanoCoderApi.Repositories;
using AntonioCampusanoCoderApi.Models;
using System.Data.SqlClient;
using static AntonioCampusanoCoderApi.Controllers.VentaController;
using System;

namespace AntonioCampusanoCoderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : Controller
    {
        private VentaRepositorio repositorio = new VentaRepositorio();
        // Agregar Venta
        [HttpPost]
        public ActionResult Post([FromBody] Venta venta)
        {
            try
            {
                Venta ventaCreado = repositorio.cargarVenta(venta);
                return StatusCode(StatusCodes.Status201Created, ventaCreado);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        // Eliminar Venta
        [HttpDelete]
        public ActionResult Delete([FromBody] long id)
        {
            try
            {
                bool seElimino = repositorio.eliminarVenta(id);
                if (seElimino)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
    
}
