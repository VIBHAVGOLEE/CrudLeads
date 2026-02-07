using System.Collections.Generic;
using CrudLeads.Application.DTOs;

namespace CrudLeads.Application.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserResponseDto> GetAll();
        UserResponseDto GetById(long id);
        UserResponseDto Create(UserCreateDto dto);
        UserResponseDto Update(long id, UserUpdateDto dto);
        void Delete(long id);
    }
}
