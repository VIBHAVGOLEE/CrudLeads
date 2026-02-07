using AutoMapper;
using CrudLeads.Application.DTOs;
using CrudLeads.Domain.Entities;

namespace CrudLeads.Application.Mapping
{
    public class LeadSourceMappingProfile : Profile
    {
        public LeadSourceMappingProfile()
        {
            CreateMap<LeadSource, LeadSourceResponseDto>();
        }
    }
}

