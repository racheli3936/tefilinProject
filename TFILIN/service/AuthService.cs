using core.IRepositories;
using core.IServices;
using core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace service
{
    public class AuthService:IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;
        public AuthService(IAuthRepository authRepository,IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }
        public async Task<(string token, User user)> LoginAsync(string email,string password)
        {

            var user = await _authRepository.GetUserByEmailAndPasswordAsync(email, password);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }
            var tokenString = GenerateJwtToken(user);
            return (tokenString, user);
        }
        public async Task<string> RegisterUserAsync(User user)
        {
           await _authRepository.CreateUserAsync(user);

            await _authRepository.UpdateUpdated_CreatedBy(user.Id);
            return GenerateJwtToken(user);
        }
        public string GenerateJwtToken(User user)
        {
            Console.WriteLine(user.Id);
            Console.WriteLine("userId+++++++++++++++");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("aud", _configuration["Jwt:Audience"])
                }),
                Expires = DateTime.UtcNow.AddDays(Convert.ToDouble(_configuration["Jwt:ExpiryInDays"])),
                Issuer = _configuration["Jwt:Issuer"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
