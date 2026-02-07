using System.Collections.Generic;
using CrudLeads.Application.DTOs;

namespace CrudLeads.Application.Interfaces
{
    public interface ILeadSourceService
    {
        IEnumerable<LeadSourceResponseDto> GetAll();
        LeadSourceResponseDto GetById(long id);
    }
}

