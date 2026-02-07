using CrudLeads.Application.DTOs;

namespace CrudLeads.Application.Interfaces
{
    public interface IAuthService
    {
        LoginResponseDto Login(LoginRequestDto request);
    }
}
