using Microsoft.EntityFrameworkCore;
using PracticeCoreWebApi.Data;
using PracticeCoreWebApi.Model;
using PracticeCoreWebApi.Services;

namespace PracticeCoreWebApi.Repo
{
    public class SignupRepository : ISignupRepository
    {
        private readonly DataContext _datacontext;
        private readonly ITokenService _tokenService;
        public SignupRepository(DataContext dataContext,ITokenService tokenService)
        {
            _datacontext = dataContext;
            _tokenService = tokenService;
        }

        public async Task<Login> Login(LogInRequest ResLogin)
        {
            try
            {
                Login obj = new Login();
                var token = await _tokenService.CreateToken(ResLogin);
                if (token == null)
                {
                    obj.CommonResponseStatus.Message = "Unauthorized";
                    obj.CommonResponseStatus.Status = false;
                    return obj;
                }
                else
                {                                                         
                   obj.CommonResponseStatus.Message = "Login Success !";
                   obj.CommonResponseStatus.Status = true;
                   obj.token = token;                                          
                   return obj;
                }              
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<CommonResponseStatus> Register(SignupDetail signupDetail)
        {
            try
            {
                CommonResponseStatus obj = new CommonResponseStatus();
                var result = await _datacontext.SignupDetails.Where(x => x.Useremail == signupDetail.Useremail && x.Username == signupDetail.Username).FirstOrDefaultAsync();
                if(result != null)
                {
                    obj.Message = "Invalid Username,Useremail";
                    obj.Status = false;
                    return obj;
                }
                else
                {

                    var addresult = await _datacontext.SignupDetails.AddAsync(signupDetail);
                    if (addresult != null)
                    {
                        var a = await _datacontext.SaveChangesAsync();
                        if (a > 0)
                        {
                            obj.Message = "Registered Successfully !";
                            obj.Status = true;
                            return obj;
                        }
                        else
                        {
                            obj.Message = "Registration Failed!";
                            obj.Status = false;
                            return obj;
                        }
                    }
                    else
                    {
                        return obj;
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
