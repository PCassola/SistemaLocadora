using ProvaTeste.Models;
using System.Threading.Tasks;

namespace ProvaTeste.Services.Interfaces
{
    public interface IFilmeService
    {
        Task<bool> CreateFilme(FilmeModel model);

        Task<bool> ModifyFilme(RespondeModifyFilme model);

        Task<bool> DeleteFilme(int Id);
    }
}
