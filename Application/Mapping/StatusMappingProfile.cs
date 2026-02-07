using AutoMapper;
using CrudLeads.Application.DTOs;
using CrudLeads.Domain.Entities;

namespace CrudLeads.Application.Mapping
{
    public class StatusMappingProfile : Profile
    {
        public StatusMappingProfile()
        {
            CreateMap<Status, StatusResponseDto>();
        }
    }
}

