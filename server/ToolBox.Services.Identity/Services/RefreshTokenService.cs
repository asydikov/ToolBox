using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RawRabbit;
using ToolBox.Common.Auth;
using ToolBox.Common.Exceptions;
using ToolBox.Services.Identity.Domain;
using ToolBox.Services.Identity.Domain.Repositories;
using ToolBox.Services.Identity.Entities;
using ToolBox.Services.Identity.Helpers;
using ToolBox.Services.Identity.Messages.Events;
using ToolBox.Services.Identity.Repositories;

namespace ToolBox.Services.Identity.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly IJwtHandler _jwtHandler;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IClaimsProvider _claimsProvider;
        private readonly IBusClient _busClient;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository,
            IUserRepository userRepository,
            IJwtHandler jwtHandler,
            IPasswordHasher<User> passwordHasher,
            IClaimsProvider claimsProvider,
            IBusClient busPublisher)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
            _passwordHasher = passwordHasher;
            _claimsProvider = claimsProvider;
            _busClient = busPublisher;
        }

        public async Task AddAsync(Guid userId)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user == null)
            {
                throw new ToolBoxException(Codes.UserNotFound,
                    $"User: '{userId}' was not found.");
            }
            var refreshToken = new RefreshToken();
            refreshToken.SetToken(user, _passwordHasher);

            await _refreshTokenRepository.AddAsync(refreshToken);
        }

        public async Task<JsonWebToken> CreateAccessTokenAsync(string token)
        {
            var refreshToken = await _refreshTokenRepository.GetAsync(token);
            if (refreshToken == null)
            {
                throw new ToolBoxException(Codes.RefreshTokenNotFound,
                    "Refresh token was not found.");
            }

            if (refreshToken.User == null || refreshToken.UserId == null || refreshToken.UserId == Guid.Empty)
            {
                throw new ToolBoxException(Codes.UserNotFound,
                    $"User: '{refreshToken.UserId}' was not found.");
            }
            var claims = await _claimsProvider.GetAsync(refreshToken.UserId);
            var jwt = _jwtHandler.CreateToken(refreshToken.UserId.ToString("N"), null, claims);
            jwt.RefreshToken = refreshToken.Token;
            await _busClient.PublishAsync(new AccessTokenRefreshed(Guid.NewGuid(),refreshToken.UserId));
            // await _busClient.PublishAsync(new AccessTokenRefreshed(user.Id), CorrelationContext.Empty);

            return jwt;
        }
    }
}