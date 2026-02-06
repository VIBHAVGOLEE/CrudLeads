using System.Collections.Generic;
using CrudLeads.Application.DTOs;

namespace CrudLeads.Application.Interfaces
{
    public interface IBrokerService
    {
        IEnumerable<BrokerResponseDto> GetAll();
        BrokerResponseDto GetById(long id);
        BrokerResponseDto Create(BrokerCreateDto dto);
        BrokerResponseDto Update(long id, BrokerUpdateDto dto);
        void Delete(long id);
    }
}
