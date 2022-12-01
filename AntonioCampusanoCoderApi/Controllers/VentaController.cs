using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AntonioCampusanoCoderApi.Repositories;
using AntonioCampusanoCoderApi.Models;
using System.Data.SqlClient;
using static AntonioCampusanoCoderApi.Controllers.VentaController;
using System;
namespace AntonioCampusanoCoderApi.Controllers
{
    public class VentaController : Controller
    {
        private VentaRepositorio repositorio = new VentaRepositorio();

        [HttpGet]
        public ActionResult<List<Venta>> Get()
        {
            try
            {
                List<Venta> lista = repositorio.GetVenta();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        private List<Venta> GetVenta()
        {
            throw new NotImplementedException();
        }
    }
}
