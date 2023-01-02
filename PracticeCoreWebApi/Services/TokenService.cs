using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PracticeCoreWebApi.Data;
using PracticeCoreWebApi.Model;
using PracticeCoreWebApi.Repo;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace PracticeCoreWebApi.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly DataContext _datacontext;
        public TokenService(IConfiguration config,DataContext dataContext)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            _datacontext = dataContext;   
        }

        public async Task<string> CreateToken(LogInRequest ResLogin)
        {
            var result = await _datacontext.SignupDetails.Where(x => x.Username == ResLogin.Username && x.Password == ResLogin.Password).FirstOrDefaultAsync();
            if (result == null)
            {
                return null;
            }
            else
            {
                var claims = new List<Claim>
              {
                new Claim(JwtRegisteredClaimNames.Name, ResLogin.Username.ToString()),
                //new Claim(JwtRegisteredClaimNames.UniqueName,ResLogin.Password),
              };
                var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);
                var tokenDescripation = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddMinutes(15),
                    SigningCredentials = cred
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescripation);
                return tokenHandler.WriteToken(token);
            }            
        }   
    }
}
