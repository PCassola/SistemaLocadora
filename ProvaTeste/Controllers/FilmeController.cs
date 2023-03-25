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
    public class FilmeController : ControllerBase
    {
        private readonly ILogger<FilmeController> _logger;
        private readonly IFilmeService _filmeService;

        public FilmeController(ILogger<FilmeController> logger, IFilmeService filmeService)
        {
            _logger = logger;
            _filmeService = filmeService;
        }

            /// <summary>
            /// Cadastrar Filme.
            /// </summary>
            /// <param name="model"></param>
            /// <returns></returns>
            [HttpPost]
            public async Task<ActionResult> Post(FilmeModel model)
            {
                var result = await _filmeService.CreateFilme(model);

                if (result == false)
                    return BadRequest();

                return Created("Ok", "Filme criado com sucesso.");
            }

            /// <summary>
            /// Metodo Alterar Filme
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            [HttpPut]
            public async Task<ActionResult> Put(RespondeModifyFilme model)
            {
                var result = await _filmeService.ModifyFilme(model);

                if (result == false)
                {
                    _logger.LogError("Não foi possivel Modificar o Filme");
                    return StatusCode(403, "Não foi possivel Modificar o Filme");
                }


                return Ok("Modificação feita com sucesso!");
            }

            /// <summary>
            /// Metodo Excluir Filme.
            /// </summary>
            /// <param name="Id"></param>
            /// <returns></returns>
            [HttpDelete]
            public async Task<ActionResult> Delete(int Id)
            {
                var result = await _filmeService.DeleteFilme(Id);

                if (result == false)
                    return BadRequest();

                return Ok("Filme Deletado com sucesso!");
            }

        }
    }
