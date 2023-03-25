using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProvaTeste.Filters;
using ProvaTeste.Models;
using ProvaTeste.Services;
using ProvaTeste.Services.Interfaces;
using System.Threading.Tasks;

namespace ProvaTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AuthorizationActionFilter]
    public class LocacaoController: ControllerBase
    {
        private readonly ILogger<LocacaoController> _logger;
        private readonly ILocacaoService _locacaoService;

        public LocacaoController(ILogger<LocacaoController> logger, ILocacaoService locacaoService)
        {
            _logger = logger;
            _locacaoService = locacaoService;
        }

        /// <summary>
        /// Fazer locação de Filme.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post(LocacaoModel model)
        {
            var result = await _locacaoService.CreateLocacao(model);

            if (result == false)
                return BadRequest();

            return Created("Ok", "Locação feita com sucesso.");
        }

        ///// <summary>
        ///// Metodo Para Devolução de Filme
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpPut]
        //public async Task<ActionResult> Put(RespondeModifyCliente model)
        //{
        //    var result = await _locacaoService.ModifyLocacao(model);

        //    if (result == false)
        //    {
        //        _logger.LogError("Não foi possivel Modificar a Locacao");
        //        return StatusCode(403, "Não foi possivel Modificar a Locacao");
        //    }


        //    return Ok("Devolução feita com sucesso!");
        //}


    }
}
