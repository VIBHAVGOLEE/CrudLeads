using System.Collections.Generic;
using CrudLeads.Application.DTOs;

namespace CrudLeads.Application.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<RoleResponseDto> GetAll();
        RoleResponseDto GetById(long id);
    }
}
