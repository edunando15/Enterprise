﻿using Esame_Enterprise.Application.Abstractions.Services;
using Esame_Enterprise.Application.Models.Requests;
using Esame_Enterprise.Application.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Esame_Enterprise.Application.Services
{
    public class TokenService : ITokenService
    {

        private readonly IUserService userService;

        private readonly JwtAuthenticationOption jwtAuthenticationOptions;

        public TokenService(IUserService userService)
        {
            this.userService = userService;
        }

        public string CreateToken(CreateTokenRequest request)
        {
            var user = userService.LogIn(request.Email, request.Password);
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
            return new JwtSecurityToken(jwtAuthenticationOptions.Issuer, 
                null,
                claims,
                expires: DateTime.Now.AddMinutes(30), 
                signingCredentials: GetCredentials());
        }

        private SigningCredentials GetCredentials()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAuthenticationOptions.Key));
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        }
        
    }
}