﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineLibrary.Application.Common.Extensions;
using OnlineLibrary.Application.Common.JWT.Interfaces;
using OnlineLibrary.Application.Common.JWT.Models;
using OnlineLibrary.Domain.Entites.Identity;

namespace OnlineLibrary.Application.Common.JWT.Service
{
    public class JwtToken : IJwtToken
    {
        private readonly IConfiguration _configuration;

        public JwtToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async ValueTask<TokenResponse> CreateTokenAsync(
            string userName, string userId, ICollection<Role> roles, CancellationToken cancellationToken = default)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, userId)
            };

            if (roles.Count > 0)
            {
                foreach (var role in roles)
                {
                    foreach (var permission in role.Permissions)
                    {
                        claims.Add(new Claim("permission", permission.Name));
                    }
                }
            }

            var jwt = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("JWT:Issuer"),
                audience: _configuration.GetValue<string>("JWT:Audience"),
                claims: claims,
                expires: DateTime.Now.AddDays(_configuration.GetValue<int>("JWT:TokenExpiredTimeAtDays", 10)),
                 signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key"))),
                                SecurityAlgorithms.HmacSha256));

            var responseModel = new TokenResponse()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwt),
                RefreshToken = await GenerateRefreshTokenAsync(userName)
            };

            return responseModel;
        }
        public ValueTask<string> GenerateRefreshTokenAsync(string userName)
        {
            var refreshToken = (userName + DateTime.Now).GetHashedString();
            return new ValueTask<string>(refreshToken);
        }

        public ValueTask<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = false,
                ValidAudience = _configuration.GetValue<string>("JWT:Audience"),
                ValidIssuer = _configuration.GetValue<string>("JWT:Issuer"),
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")))
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return ValueTask.FromResult(principal);
        }
    }
}
