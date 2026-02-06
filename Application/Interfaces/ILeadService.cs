using System.Collections.Generic;
using CrudLeads.Application.DTOs;

namespace CrudLeads.Application.Interfaces
{
    public interface ILeadService
    {
        IEnumerable<LeadResponseDto> GetAll();
        IEnumerable<LeadResponseDto> GetByBrokerId(long brokerId);
        LeadResponseDto GetById(long id);
        LeadResponseDto Create(LeadCreateDto dto);
        LeadResponseDto Update(long id, LeadUpdateDto dto);
        void Delete(long id);
    }
}
