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
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteService _clienteService;

        public ClienteController(ILogger<ClienteController> logger, IClienteService clienteService)
        {
            _logger = logger;
            _clienteService = clienteService;
        }

        /// <summary>
        /// Cadastrar Cliente.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post(ClienteModel model)
        {
            var result = await _clienteService.CreateCliente(model);

            if (result == false)
                return BadRequest();

            return Created("Ok", "Cliente criado com sucesso.");
        }

        /// <summary>
        /// Metodo Alterar Cliente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put(RespondeModifyCliente model)
        {
            var result = await _clienteService.ModifyCliente(model);

            if (result == false)
            {
                _logger.LogError("Não foi possivel Modificar o Cliente");
                return StatusCode(403, "Não foi possivel Modificar o Cliente");
            }


            return Ok("Modificação feita com sucesso!");
        }

        /// <summary>
        /// Metodo Excluir Cliente.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            var result = await _clienteService.DeleteCliente(Id);

            if (result == false)
                return BadRequest();

            return Ok("Cliente Deletado com sucesso!");
        }

    }
}
