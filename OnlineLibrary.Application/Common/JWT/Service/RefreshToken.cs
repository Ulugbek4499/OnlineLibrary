using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Application.Common.JWT.Interfaces;
using OnlineLibrary.Domain.Entites.Identity;

namespace OnlineLibrary.Application.Common.JWT.Service
{
    public class RefreshToken : IUserRefreshToken
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RefreshToken(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async ValueTask<UserRefreshToken> AddOrUpdateRefreshToken(UserRefreshToken refreshToken, CancellationToken cancellationToken = default)
        {
            var foundRefreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(
                x=>x.UserName==refreshToken.UserName, cancellationToken);

            if (foundRefreshToken is null)
            {
                await _context.RefreshTokens.AddAsync(refreshToken, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return refreshToken;
            }
            else
            {
                foundRefreshToken.RefreshToken = refreshToken.RefreshToken;
                foundRefreshToken.ExpiresTime = refreshToken.ExpiresTime;
                _context.RefreshTokens.Update(foundRefreshToken);
                await _context.SaveChangesAsync(cancellationToken);

                return refreshToken;
            }
        }

        public ValueTask<User> AuthenAsync(LoginUserCommand user)
        {
            string hashPassword = user.Password.GetHashedString();
            User? foundUser = await _context.Users.SingleOrDefaultAsync(x => x.Username == user.Username && x.Password == hashPassword);
            if (foundUser is null)
            {
                return null;
            }
            return foundUser;
        }

        public async ValueTask<bool> DeleteUserRefreshTokens(
                              string username, string refreshToken, CancellationToken cancellationToken = default)
        {
            var foundRefreshToken=await _context.RefreshTokens.FirstOrDefaultAsync(
                                 x=>x.UserName==username && x.RefreshToken==refreshToken, cancellationToken);
            _context.RefreshTokens.Remove(foundRefreshToken);

            return (await _context.SaveChangesAsync(cancellationToken))>0;
        }

        public async ValueTask<UserRefreshToken> GetSavedRefreshTokens(string userName, string refreshToken)
        {
            var foundRefreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(
                x => x.UserName == userName && x.RefreshToken == refreshToken);

            return foundRefreshToken;
        }
    }
}
