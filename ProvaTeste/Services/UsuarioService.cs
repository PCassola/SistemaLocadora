using Microsoft.EntityFrameworkCore;
using ProvaTeste.DataBaseContext;
using ProvaTeste.Entities;
using ProvaTeste.Models;
using ProvaTeste.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaTeste.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly LocadoraDBContext _context;


        public UsuarioService(LocadoraDBContext context)
        {
            _context = context;
        }


        public async Task<bool> CreateUser(UsuarioModel model)
        {

            var usuario = new Usuarios();
            usuario.Login = model.Login;
            usuario.Senha = model.Senha;

            _context.Usuarios.Add(usuario);
            var result = await _context.SaveChangesAsync();

            if (result <= 0)
                return false;

            return true;
        }

        public async Task<bool> ModifyUser(RespondeModifyUsuario model)
        {

            var result = await _context.Usuarios.Where(x => x.Id == model.Id).FirstOrDefaultAsync();

            if (result == null)
                return false;

            result.Login = model.Login;
            result.Senha = model.Senha;

            _context.Update(result);

            var save = await _context.SaveChangesAsync();

            if (save <= 0)
                return false;

            return true;
        }

        public async Task<bool> DeleteUsuario(int Id)
        {

            var excluir = await _context.Usuarios.Where(x => x.Id == Id).FirstOrDefaultAsync();

            if (excluir == null)
                return false;


            _context.Remove(excluir);

            var result = await _context.SaveChangesAsync();

            if (result <= 0)
                return false;

            return true;
        }
    }
}
