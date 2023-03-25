using Microsoft.EntityFrameworkCore;
using ProvaTeste.DataBaseContext;
using ProvaTeste.Entities;
using ProvaTeste.Models;
using ProvaTeste.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaTeste.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly LocadoraDBContext _context;

        public FilmeService(LocadoraDBContext context)
        {
            _context = context;
        }


        public async Task<bool> CreateFilme(FilmeModel model)
        {

            var filme = new Filmes();

            filme.Nome = model.Nome;
            filme.Diretor = model.Diretor;
            filme.Sinopsia = model.Sinopsia;
            filme.Situacao = 0;

            _context.Filmes.Add(filme);
            var result = await _context.SaveChangesAsync();

            if (result <= 0)
                return false;

            return true;
        }

        public async Task<bool> ModifyFilme(RespondeModifyFilme model)
        {

            var result = await _context.Filmes.Where(x => x.Id == model.Id).FirstOrDefaultAsync();

            if (result == null)
                return false;

            result.Nome = model.Nome;
            result.Diretor = model.Diretor;
            result.Sinopsia = model.Sinopsia;
            result.Situacao = model.Situacao;

            _context.Update(result);

            var save = await _context.SaveChangesAsync();

            if (save <= 0)
                return false;

            return true;
        }

        public async Task<bool> DeleteFilme(int Id)
        {

            var excluir = await _context.Filmes.Where(x => x.Id == Id).FirstOrDefaultAsync();

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
