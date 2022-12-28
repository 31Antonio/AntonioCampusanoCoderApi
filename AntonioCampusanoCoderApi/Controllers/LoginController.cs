
using Microsoft.AspNetCore.Mvc;
using AntonioCampusanoCoderApi.Repositories;
using AntonioCampusanoCoderApi.Models;


namespace AntonioCampusanoCoderApi.Controllers
{



    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        public LoginRepositorio repositorio = new LoginRepositorio();

        [HttpPost]
        public ActionResult<Usuario> Login(Usuario usuario)
        {
            try
            {
                bool usuarioExiste = repositorio.verficarUsuario(usuario);
                return usuarioExiste ? Ok() : NotFound();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
       

