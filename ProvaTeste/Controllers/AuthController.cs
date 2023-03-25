using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProvaTeste.Models;
using ProvaTeste.Services.Interfaces;
using System.Threading.Tasks;
using System;

namespace ProvaTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _service;

        public AuthController(ILogger<AuthController> logger, IAuthService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Autenticação com usuário e senha.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseAuthModel>> Post(AuthModel model)
        {
            try
            {
                var result = await _service.User(model);

                if (result == null || result.CodUsuario == 0 )
                    return Unauthorized("Credenciais inválidas.");

                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError($"Ocorreu um erro: {e}");
                return StatusCode(500, "Ocorreu um erro.");
            }
        }
    }
}
