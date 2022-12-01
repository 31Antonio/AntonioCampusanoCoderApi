using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AntonioCampusanoCoderApi.Repositories;
using AntonioCampusanoCoderApi.Models;
using System.Data.SqlClient;
using static AntonioCampusanoCoderApi.Controllers.ProductoVendidoController;

namespace AntonioCampusanoCoderApi.Controllers
{
    public class ProductoVendidoController1 : Controller
    {
        [ApiController]
        [Route("[controller]")]
        public class ProductoVendidoController : Controller
        {
            private ProductoVendidoRepositorio repositorio = new ProductoVendidoRepositorio();

            public ActionResult<List<ProductoVendido>> Get()
            {
                try
                {
                    List<ProductoVendido> lista = repositorio.GetProductoVendido();
                    return Ok(lista);
                }
                catch (Exception ex)
                {

                    return Problem(ex.Message);
                }
            }

            private List<ProductoVendido> GetProductosVendidos()
            {
                throw new NotImplementedException();
            }
        }
    }
