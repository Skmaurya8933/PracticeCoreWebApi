using PracticeCoreWebApi.Model;

namespace PracticeCoreWebApi.Repo
{
    public interface ISignupRepository
    {
        Task<CommonResponseStatus> Register(SignupDetail signupDetail);
        Task<Login> Login(LogInRequest ResLogin);
    }
}
