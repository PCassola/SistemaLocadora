using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProvaTeste.Filters;
using ProvaTeste.Models;
using ProvaTeste.Services.Interfaces;
using System.Threading.Tasks;

namespace ProvaTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AuthorizationActionFilter]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService userService)
        {
            _logger = logger;
            _usuarioService = userService;
        }

        /// <summary>
        /// Cadastrar Cliente.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post(UsuarioModel model)
        {
            var result = await _usuarioService.CreateUser(model);

            if (result == false)
                return BadRequest();

            return Created("Ok", "Usuario criado com sucesso.");
        }

        /// <summary>
        /// Metodo Alterar Cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put(RespondeModifyUsuario model)
        {
            var result = await _usuarioService.ModifyUser(model);

            if (result == false)
            {
                _logger.LogError("Não foi possivel Modificar Usuario");
                return StatusCode(403, "Não foi possivel Modificar Usuario");
            }


            return Ok("Modificação feita com sucesso!");
        }

        /// <summary>
        /// Metodo Excluir Usuario.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            var result = await _usuarioService.DeleteUsuario(Id);

            if (result == false)
                return BadRequest();

            return Ok("Usuario Deletado com sucesso!");
        }

    }
}
