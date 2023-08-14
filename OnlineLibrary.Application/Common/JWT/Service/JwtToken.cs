using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using OnlineLibrary.Application.Common.JWT.Interfaces;
using OnlineLibrary.Application.Common.JWT.Models;
using OnlineLibrary.Domain.Entites.Identity;

namespace OnlineLibrary.Application.Common.JWT.Service
{
    public class JwtToken : IJwtToken
    {
        public ValueTask<TokenResponse> CreateTokenAsync(
            string userName, string UserId, ICollection<Role> roles, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetRefreshTokenAsync(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
