using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CrudLeads.Application.DTOs;
using CrudLeads.Application.Interfaces;
using CrudLeads.Domain.Entities;
using CrudLeads.Domain.Interfaces;
using CrudLeads.Infrastructure.Security;

namespace CrudLeads.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<UserResponseDto> GetAll()
        {
            var users = _unitOfWork.Users.GetAllWithRole();
            return _mapper.Map<IEnumerable<UserResponseDto>>(users);
        }

        public UserResponseDto GetById(long id)
        {
            var user = _unitOfWork.Users.GetByIdWithRole(id);
            if (user == null)
                return null;
            return _mapper.Map<UserResponseDto>(user);
        }

        public UserResponseDto Create(UserCreateDto dto)
        {
            var existing = _unitOfWork.Users.GetByUserName(dto.UserName.Trim());
            if (existing != null)
                return null;

            var role = _unitOfWork.Roles.GetById(dto.RoleId);
            if (role == null)
                return null;

            string hash, salt;
            PasswordHelper.HashPassword(dto.Password, out hash, out salt);

            var user = new User
            {
                UserName = dto.UserName.Trim(),
                Email = dto.Email?.Trim(),
                PasswordHash = hash,
                PasswordSalt = salt,
                RoleId = dto.RoleId,
                IsActive = dto.IsActive,
                CreatedOn = DateTime.UtcNow
            };

            _unitOfWork.Users.Add(user);
            _unitOfWork.SaveChanges();

            user.Role = role;
            return _mapper.Map<UserResponseDto>(user);
        }

        public UserResponseDto Update(long id, UserUpdateDto dto)
        {
            var user = _unitOfWork.Users.GetByIdWithRole(id);
            if (user == null)
                return null;

            if (dto.Email != null)
                user.Email = dto.Email.Trim();
            if (dto.RoleId.HasValue)
            {
                var role = _unitOfWork.Roles.GetById(dto.RoleId.Value);
                if (role != null)
                {
                    user.RoleId = dto.RoleId.Value;
                    user.Role = role;
                }
            }
            if (dto.IsActive.HasValue)
                user.IsActive = dto.IsActive.Value;
            if (!string.IsNullOrWhiteSpace(dto.NewPassword))
            {
                string hash, salt;
                PasswordHelper.HashPassword(dto.NewPassword, out hash, out salt);
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
            }

            _unitOfWork.Users.Update(user);
            _unitOfWork.SaveChanges();

            return _mapper.Map<UserResponseDto>(user);
        }

        public void Delete(long id)
        {
            var user = _unitOfWork.Users.GetById(id);
            if (user == null)
                return;
            _unitOfWork.Users.Remove(user);
            _unitOfWork.SaveChanges();
        }
    }
}
