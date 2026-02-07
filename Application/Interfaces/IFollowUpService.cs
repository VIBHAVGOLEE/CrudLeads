using System.Collections.Generic;
using CrudLeads.Application.DTOs;

namespace CrudLeads.Application.Interfaces
{
    public interface IFollowUpService
    {
        IEnumerable<FollowUpResponseDto> GetAll();
        IEnumerable<FollowUpResponseDto> GetByBrokerId(long brokerId);
        IEnumerable<FollowUpResponseDto> GetByLeadId(long leadId);
        FollowUpResponseDto GetById(long id);
        FollowUpResponseDto Create(FollowUpCreateDto dto);
        FollowUpResponseDto Update(long id, FollowUpUpdateDto dto);
        void Delete(long id);
    }
}

