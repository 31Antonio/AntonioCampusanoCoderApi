using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AntonioCampusanoCoderApi.Repositories;
using AntonioCampusanoCoderApi.Models;
using System.Data.SqlClient;
using static AntonioCampusanoCoderApi.Controllers.ProductosController;

namespace AntonioCampusanoCoderApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : Controller
    {
        private ProductoRepositorio repositorio = new ProductoRepositorio();
        // GET: ProductosController
        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            
            {
                try
                {
                    List<Producto> lista = repositorio.GetProductos();
                    return Ok(lista);

                }
                catch (Exception ex)
                {

                    return Problem(ex.Message);
                }

            }
        }

        private List<Producto> GetProductos()
        {
            throw new NotImplementedException();
        }
    }}
