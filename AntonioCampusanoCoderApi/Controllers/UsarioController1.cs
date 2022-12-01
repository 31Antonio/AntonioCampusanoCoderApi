using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AntonioCampusanoCoderApi.Repository;
using AntonioCampusanoCoderApi.Models;
using System.Data.SqlClient;
using static AntonioCampusanoCoderApi.Controllers.UsuarioController;

namespace AntonioCampusanoCoderApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsarioController1 : Controller
    {
        private UsuarioRepositorio repositorio = new UsuarioRepositorio();

        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            try
            {
                List<Usuario> lista = repositorio.GetUsuario();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        private List<Usuario> GetUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
