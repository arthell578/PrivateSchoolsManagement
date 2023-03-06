using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using PrivateSchoolsManagement.Helpers;
using PrivateSchoolsManagement.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PrivateSchoolsManagement.Services
{
    public interface IAuthenticationService
    {
        Task<string> AuthenticateAsync(string email, string password);
    }

    public class AuthenticationService :  IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthenticationService(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public async Task<string> AuthenticateAsync(string email, string password)
        {
            var user = await _userService.GetUserByEmailAsync(email);

            if (user == null)
                return null;

            if (!PasswordHelper.VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
