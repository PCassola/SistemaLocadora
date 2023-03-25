using Microsoft.EntityFrameworkCore;
using ProvaTeste.DataBaseContext;
using ProvaTeste.Entities;
using ProvaTeste.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaTeste.Services
{
    public class LocacaoService
    {
        private readonly LocadoraDBContext _context;

        public LocacaoService(LocadoraDBContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateLocacao(LocacaoModel model)
        {

            var cliente = await _context.Clientes.Where(x => x.Id == model.idCliente).FirstOrDefaultAsync();

            if(cliente == null)
                return false;

            var filme = await _context.Filmes.Where(x => x.Id == model.idFilme).FirstOrDefaultAsync();

            if (filme == null)
                return false;

            var locacao = new Locacoes();

            locacao.FK_Filme = filme.Id;
            locacao.FK_Cliente = cliente.Id;
            locacao.Data_Locacao = DateTime.Now;
            locacao.Situacao = 1;
            locacao.ValorDiaria = model.ValorDiaria;

            _context.Locacoes.Add(locacao);
            var result = await _context.SaveChangesAsync();

            if (result <= 0)
                return false;

            return true;
        }




    }
}
