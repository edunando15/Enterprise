using Esame_Enterprise.Application.Abstractions.Services;
using Esame_Enterprise.Application.Models.Requests;
using Esame_Enterprise.Application.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Esame_Enterprise.Application.Services
{
    public class TokenService : ITokenService
    {

        private readonly IUserService _userService;

        private readonly JwtAuthenticationOption _jwtAuthenticationOption;

        public TokenService(IUserService userService, IOptions<JwtAuthenticationOption> option)
        {
            this._userService = userService;
            this._jwtAuthenticationOption = option.Value;
        }

        public string CreateToken(CreateTokenRequest request)
        {
            var user = _userService.LogIn(request.Email, request.Password);
            if(user != null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim("Name", user.Name));
                claims.Add(new Claim("Surname", user.Surname));
                claims.Add(new Claim("Email", user.Email));
                claims.Add(new Claim("Password", user.Password));
                var token = GetJwtSecurityToken(claims);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            else return string.Empty;
        }

        private JwtSecurityToken GetJwtSecurityToken(List<Claim> claims)
        {
            return new JwtSecurityToken(_jwtAuthenticationOption.Issuer, 
                null,
                claims,
                expires: DateTime.Now.AddMinutes(30), 
                signingCredentials: GetCredentials());
        }

        private SigningCredentials GetCredentials()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtAuthenticationOption.Key));
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        }
        
    }
}
