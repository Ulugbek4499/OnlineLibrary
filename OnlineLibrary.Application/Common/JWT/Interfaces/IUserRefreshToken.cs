﻿using OnlineLibrary.Domain.Entites.Identity;

namespace OnlineLibrary.Application.Common.JWT.Interfaces
{
    public interface IUserRefreshToken
    {
        ValueTask<UserRefreshToken> AddOrUpdateRefreshToken(
            UserRefreshToken refreshToken, CancellationToken cancellationToken = default);

        ValueTask<User> AuthenAsync(LoginUserCommand user);
        ValueTask<bool> DeleteUserRefreshTokens(
            string username, string refreshToken, CancellationToken cancellationToken = default);

        ValueTask<UserRefreshToken> GetSavedRefreshTokens(string userName, string refreshToken);
    }
}
