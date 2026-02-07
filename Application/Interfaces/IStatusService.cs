using System.Collections.Generic;
using CrudLeads.Application.DTOs;

namespace CrudLeads.Application.Interfaces
{
    public interface IStatusService
    {
        IEnumerable<StatusResponseDto> GetAll();
        IEnumerable<StatusResponseDto> GetByCategory(string category);
        StatusResponseDto GetById(long id);
    }
}

