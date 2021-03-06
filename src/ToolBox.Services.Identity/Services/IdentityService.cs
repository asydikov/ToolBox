using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RawRabbit;
using ToolBox.Common.Auth;
using ToolBox.Common.Exceptions;
using ToolBox.Services.Identity.Domain.Repositories;
using ToolBox.Services.Identity.Entities;
using ToolBox.Services.Identity.Helpers;
using ToolBox.Services.Identity.Messages.Events;
using ToolBox.Services.Identity.Repositories;

namespace ToolBox.Services.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtHandler _jwtHandler;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IClaimsProvider _claimsProvider;
        private readonly IBusClient _busClient;

        public IdentityService(IUserRepository userRepository,
            IJwtHandler jwtHandler,
              IPasswordHasher<User> passwordHasher,
            IRefreshTokenRepository refreshTokenRepository,
            IClaimsProvider claimsProvider,
            IBusClient busClient)
        {
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
            _passwordHasher = passwordHasher;
            _refreshTokenRepository = refreshTokenRepository;
            _claimsProvider = claimsProvider;
            _busClient = busClient;
        }

        public async Task<Guid> SignUpAsync(string email, string name, string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                throw new ToolBoxException(Codes.EmptyPassword,
                    $"Password cannot be empty.");
            }

            if (String.IsNullOrEmpty(email))
            {
                throw new ToolBoxException(Codes.EmptyEmail,
                    $"Email cannot be empty.");
            }

            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new ToolBoxException(Codes.EmailInUse,
                    $"Email: '{email}' is already in use.");
            }

            user = new User(Guid.NewGuid(), email, name);
            user.SetPassword(password, _passwordHasher);
            await _userRepository.AddAsync(user);
            return user.Id;
        }

        public async Task<JsonWebToken> SignInAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);

            if (user == null || !user.ValidatePassword(password, _passwordHasher))
            {
                throw new ToolBoxException(Codes.InvalidCredentials,
                    "Invalid credentials.");
            }
            var refreshToken = new RefreshToken();
            refreshToken.SetToken(user, _passwordHasher);
            var claims = await _claimsProvider.GetAsync(user);
            var jwt = _jwtHandler.CreateToken(user.Id.ToString(), null, claims);
            jwt.RefreshToken = refreshToken.Token;

            if (user.RefreshToken != null)
            {
                user.RefreshToken.Token = refreshToken.Token;
                user.RefreshToken.SetUpdatedDate();
            }
            else
            {
                await _refreshTokenRepository.AddAsync(refreshToken);
                user.RefreshToken = refreshToken;
                user.RefreshTokenId = refreshToken.Id;
            }
            await _userRepository.UpdateAsync(user);
            return jwt;
        }

        public async Task ChangePasswordAsync(Guid userId, string currentPassword, string newPassword)
        {
            User user = await _userRepository.GetAsync(userId);
            if (user == null)
            {
                throw new ToolBoxException(Codes.UserNotFound,
                    $"User with id: '{userId}' was not found.");
            }
            if (!user.ValidatePassword(currentPassword, _passwordHasher))
            {
                throw new ToolBoxException(Codes.InvalidCurrentPassword,
                    "Invalid current password.");
            }
            //  throw new Exception();
            user.SetPassword(newPassword, _passwordHasher);
            await _userRepository.UpdateAsync(user);
            await _busClient.PublishAsync(new PasswordChanged(Guid.NewGuid(), userId));
        }
    }
}