using System.Collections.Generic;
using CrudLeads.Application.DTOs;

namespace CrudLeads.Application.Interfaces
{
    public interface IActivityTypeService
    {
        IEnumerable<ActivityTypeResponseDto> GetAll();
        ActivityTypeResponseDto GetById(long id);
    }
}
