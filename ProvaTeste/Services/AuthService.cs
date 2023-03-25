using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProvaTeste.DataBaseContext;
using ProvaTeste.Models;
using System.Threading.Tasks;
using System;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProvaTeste.Services.Interfaces;

namespace ProvaTeste.Services
{
    public class AuthService : IAuthService
    {
        private readonly LocadoraDBContext _context;
        //private readonly IUserService _userService;
        private readonly ILogger<AuthService> _logger;


        public AuthService(LocadoraDBContext context, ILogger<AuthService> logger)
        {
            _context = context;
            //_userService = userService;
            _logger = logger;
        }

        //logar com autenticação de usuario.
        public async Task<ResponseAuthModel> User(AuthModel model)
        {
            try
            {
                var response = new ResponseAuthModel();

                //faz a consulta no banco
                var result = await _context.Usuarios.Where(x => x.Login == model.LoginModel && x.Senha == model.SenhaModel).SingleOrDefaultAsync();

                if (result != null)
                {
                    response.CodUsuario = result.Id;
                    response.Name = result.Login;
                    response.Token = Token(model.LoginModel, "Vannon", 60 * 60 * 5);
                }

                return response;
            }
            catch (Exception e)
            {
                _logger.LogError($"Ocorreu um erro: {e.InnerException.Message}");
                return null;
            }
        }

        private string Token(string login, string empresa, int time)
        {
            var token = JwtServices.GenerateAccessToken(login, empresa, time);
            var accessToken = JwtServices.EncodeJson(JsonConvert.SerializeObject(token));

            return accessToken;
        }
    }
}
