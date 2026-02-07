using System.Collections.Generic;
using CrudLeads.Application.DTOs;

namespace CrudLeads.Application.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerResponseDto> GetAll();
        IEnumerable<CustomerResponseDto> GetByBrokerId(long brokerId);
        CustomerResponseDto GetByLeadId(long leadId);
        CustomerResponseDto GetById(long id);
    }
}

