using PracticeCoreWebApi.Model;

namespace PracticeCoreWebApi.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(LogInRequest ResLogin);
    }
}
