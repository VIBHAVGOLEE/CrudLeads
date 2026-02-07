using AutoMapper;
using CrudLeads.Application.DTOs;
using CrudLeads.Domain.Entities;

namespace CrudLeads.Application.Mapping
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerResponseDto>()
                .ForMember(dest => dest.LeadSourceName, opt => opt.Ignore());
        }
    }
}

