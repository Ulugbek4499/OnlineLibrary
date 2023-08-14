using OnlineLibrary.Application.Common.JWT.Interfaces;
using OnlineLibrary.Domain.Entites.Identity;

namespace OnlineLibrary.Application.Common.JWT.Service
{
    public class RefreshToken : IUserRefreshToken
    {
        public ValueTask<UserRefreshToken> AddOrUpdateRefreshToken(UserRefreshToken refreshToken, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> AuthenAsync(LoginUserCommand user)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> DeleteUserRefreshTokens(string username, string refreshToken, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<UserRefreshToken> GetSavedRefreshTokens(string userName, string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
