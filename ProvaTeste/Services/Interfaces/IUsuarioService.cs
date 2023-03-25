using ProvaTeste.Models;
using System.Threading.Tasks;

namespace ProvaTeste.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> CreateUser(UsuarioModel model);

        Task<bool> ModifyUser(RespondeModifyUsuario model);

        Task<bool> DeleteUsuario(int Id);
    }
}
