using ProvaTeste.Models;
using System.Threading.Tasks;

namespace ProvaTeste.Services.Interfaces
{
    public interface IClienteService
    {
        Task<bool> CreateCliente(ClienteModel model);

        Task<bool> ModifyCliente(RespondeModifyCliente model);

        Task<bool> DeleteCliente(int Id);
    }
}
