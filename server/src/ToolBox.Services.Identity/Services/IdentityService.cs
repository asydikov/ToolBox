using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RawRabbit;
using ToolBox.Common.Auth;
using ToolBox.Common.Events.IdentityService;
using ToolBox.Common.Exceptions;
using ToolBox.Services.Identity.Domain;
using ToolBox.Services.Identity.Domain.Repositories;
using ToolBox.Services.Identity.Entities;
using ToolBox.Services.Identity.Helpers;


namespace ToolBox.Services.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtHandler _jwtHandler;
        // private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IClaimsProvider _claimsProvider;
        private readonly IBusClient _busClient;

        public IdentityService(IUserRepository userRepository,
            IEncrypter encrypter,
            IJwtHandler jwtHandler,
              IPasswordHasher<User> passwordHasher,
            // IRefreshTokenRepository refreshTokenRepository,
            IClaimsProvider claimsProvider,
            IBusClient busClient)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _jwtHandler = jwtHandler;
            _passwordHasher = passwordHasher;
            // _refreshTokenRepository = refreshTokenRepository;
            _claimsProvider = claimsProvider;
            _busClient = busClient;
        }

        public async Task SignUpAsync(Guid id, string email, string name, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new ToolBoxException(Codes.EmailInUse,
                    $"Email: '{email}' is already in use.");
            }

            user = new User(id, email, name);
            user.Password = password;
            user.EncryptPassword(_encrypter);
            await _userRepository.AddAsync(user);
            await _busClient.PublishAsync(new SignedUp(id, email));
        }

        public async Task<JsonWebToken> SignInAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);

            if (user == null || !user.ValidatePassword(password, _encrypter))
            {
                throw new ToolBoxException(Codes.InvalidCredentials,
                    "Invalid credentials.");
            }

            var refreshToken = new RefreshToken(user, _passwordHasher);
            var claims = await _claimsProvider.GetAsync(user.Id);
            var jwt = _jwtHandler.CreateToken(user.Id.ToString("N"), null, claims);
            jwt.RefreshToken = refreshToken.Token;
            // await _refreshTokenRepository.AddAsync(refreshToken);


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
            if (!user.ValidatePassword(currentPassword, _encrypter))
            {
                throw new ToolBoxException(Codes.InvalidCurrentPassword,
                    "Invalid current password.");
            }
            user.Password = newPassword;
            user.EncryptPassword(_encrypter);
            await _userRepository.UpdateAsync(user);
            await _busClient.PublishAsync(new PasswordChanged(userId));
        }
    }
}