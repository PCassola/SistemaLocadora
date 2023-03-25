using Microsoft.EntityFrameworkCore;
using ProvaTeste.DataBaseContext;
using ProvaTeste.Entities;
using ProvaTeste.Models;
using ProvaTeste.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaTeste.Services
{
    public class ClienteService : IClienteService
    {
        private readonly LocadoraDBContext _context;


        public ClienteService(LocadoraDBContext context)
        {
            _context = context;
        }


        public async Task<bool> CreateCliente(ClienteModel model)
        {

            var cliente = new Clientes();
            cliente.Nome = model.Nome;
            cliente.Sobrenome = model.Sobrenome;
            cliente.Telefone = model.Telefone;
            cliente.Endereco = model.Endereco;
            cliente.Ativacao = true;

            _context.Clientes.Add(cliente);
            var result = await _context.SaveChangesAsync();

            if (result <= 0)
                return false;

            return true;
        }

        public async Task<bool> ModifyCliente(RespondeModifyCliente model)
        {

            var result = await _context.Clientes.Where(x => x.Id == model.Id).FirstOrDefaultAsync();

            if (result == null)
                return false;

            result.Nome = model.Nome;
            result.Sobrenome = model.Sobrenome;
            result.Telefone = model.Telefone;
            result.Endereco = model.Endereco;
            result.Ativacao = model.Ativacao;

            _context.Update(result);

            var save = await _context.SaveChangesAsync();

            if (save <= 0)
                return false;

            return true;
        }

        public async Task<bool> DeleteCliente(int Id)
        {

            var excluir = await _context.Clientes.Where(x => x.Id == Id).FirstOrDefaultAsync();

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
