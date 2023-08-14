using System.Security.Claims;
using OnlineLibrary.Application.Common.JWT.Models;
using OnlineLibrary.Domain.Entites.Identity;

namespace OnlineLibrary.Application.Common.JWT.Interfaces
{
    public interface IJwtToken
    {
        ValueTask<TokenResponse> CreateTokenAsync(
            string userName, string UserId, ICollection<Role> roles, CancellationToken cancellationToken = default);

        ValueTask<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
        ValueTask<string> GenerateRefreshTokenAsync(string userName);
    }
}
