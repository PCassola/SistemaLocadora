using ProvaTeste.Models;
using System.Threading.Tasks;

namespace ProvaTeste.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseAuthModel> User(AuthModel model);
    }
}
