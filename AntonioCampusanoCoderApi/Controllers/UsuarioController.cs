using Microsoft.AspNetCore.Mvc;
using AntonioCampusanoCoderApi.Repositories;
using AntonioCampusanoCoderApi.Models;


namespace AntonioCampusanoCoderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private UsuarioRepositorio repository = new UsuarioRepositorio();
        [HttpPost]//Crear Usuario
        public ActionResult Post([FromBody] Usuario user)
        {
            try
            {
                Usuario usuarioCreado = repository.crearUsuario(user);
                return StatusCode(StatusCodes.Status201Created, usuarioCreado);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]//Modificar Usuario
        public ActionResult<Usuario> Put(int id, [FromBody] Usuario usuarioAModificar)
        {
            try
            {
                Usuario? usuarioActualizado = repository.actualizarUsuario(id, usuarioAModificar);
                return Ok(usuarioActualizado);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]//Traer usuario desde  NombreUsuario
        public ActionResult<Usuario> Get(string nombreUser)
        {
            try
            {
                Usuario userMostrar = repository.obtenerUsuario(nombreUser);
                return Ok(userMostrar);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]//Eliminar Usuario
        public ActionResult Delete([FromBody] int id)
        {
            try
            {
                bool seElimino = repository.eliminarUsuario(id);
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