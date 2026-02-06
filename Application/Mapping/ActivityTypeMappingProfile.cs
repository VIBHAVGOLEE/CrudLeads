using AutoMapper;
using CrudLeads.Application.DTOs;
using CrudLeads.Domain.Entities;

namespace CrudLeads.Application.Mapping
{
    public class ActivityTypeMappingProfile : Profile
    {
        public ActivityTypeMappingProfile()
        {
            CreateMap<ActivityType, ActivityTypeResponseDto>();
        }
    }
}
