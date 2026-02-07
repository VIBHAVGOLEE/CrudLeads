using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CrudLeads.Application.DTOs;
using CrudLeads.Application.Interfaces;
using CrudLeads.Domain.Interfaces;
using CrudLeads.Infrastructure.Security;
using Microsoft.IdentityModel.Tokens;

namespace CrudLeads.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public LoginResponseDto Login(LoginRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request?.UserName) || string.IsNullOrWhiteSpace(request?.Password))
                return null;

            var user = _unitOfWork.Users.GetByUserName(request.UserName.Trim());
            if (user == null || !user.IsActive)
                return null;

            if (!PasswordHelper.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
                return null;

            var roleName = user.Role != null ? user.Role.Name : "User";
            var token = GenerateJwt(user.Id, user.UserName, roleName);
            var expiryMinutes = GetJwtExpiryMinutes();

            return new LoginResponseDto
            {
                AccessToken = token,
                ExpiresIn = expiryMinutes * 60,
                UserName = user.UserName,
                RoleName = roleName
            };
        }

        private string GenerateJwt(long userId, string userName, string roleName)
        {
            var secret = ConfigurationManager.AppSettings["JwtSecret"] ?? "CrudLeadsJwtSecretKeyMustBeAtLeast32CharactersLong!";
            var issuer = ConfigurationManager.AppSettings["JwtIssuer"] ?? "CrudLeads";
            var audience = ConfigurationManager.AppSettings["JwtAudience"] ?? "CrudLeadsApi";
            var expiryMinutes = GetJwtExpiryMinutes();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userName),
                new Claim(ClaimTypes.Role, roleName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static int GetJwtExpiryMinutes()
        {
            var setting = ConfigurationManager.AppSettings["JwtExpiryMinutes"];
            return int.TryParse(setting, out var minutes) && minutes > 0 ? minutes : 60;
        }
    }
}
