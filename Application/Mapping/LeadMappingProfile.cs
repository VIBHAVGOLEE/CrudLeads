using AutoMapper;
using CrudLeads.Application.DTOs;
using CrudLeads.Domain.Entities;

namespace CrudLeads.Application.Mapping
{
    public class LeadMappingProfile : Profile
    {
        public LeadMappingProfile()
        {
            CreateMap<Lead, LeadResponseDto>()
                .ForMember(dest => dest.ActivityTypeName, opt => opt.Ignore());
            CreateMap<LeadCreateDto, Lead>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.CompletedOn, opt => opt.Ignore())
                .ForMember(dest => dest.Broker, opt => opt.Ignore())
                .ForMember(dest => dest.ActivityType, opt => opt.Ignore());
            CreateMap<LeadUpdateDto, Lead>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.BrokerId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.Broker, opt => opt.Ignore())
                .ForMember(dest => dest.ActivityType, opt => opt.Ignore());
        }
    }
}

