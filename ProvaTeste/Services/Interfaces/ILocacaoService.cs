using ProvaTeste.Models;
using System.Threading.Tasks;

namespace ProvaTeste.Services.Interfaces
{
    public interface ILocacaoService
    {
        Task<bool> CreateLocacao(LocacaoModel model);
    }
}
