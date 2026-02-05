using System.Collections.Generic;
using CrudLeads.Application.DTOs;

namespace CrudLeads.Application.Interfaces
{
    public interface ILeadService
    {
        IEnumerable<LeadResponseDto> GetAll();
        LeadResponseDto GetById(int id);
        LeadResponseDto Create(LeadCreateDto dto);
        LeadResponseDto Update(int id, LeadUpdateDto dto);
        void Delete(int id);
    }
}
