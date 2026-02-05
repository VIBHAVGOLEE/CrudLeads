using AutoMapper;
using CrudLeads.Application.DTOs;
using CrudLeads.Domain.Entities;

namespace CrudLeads.Application.Mapping
{
    /// <summary>
    /// AutoMapper profile for Lead entity and DTOs.
    /// </summary>
    public class LeadMappingProfile : Profile
    {
        public LeadMappingProfile()
        {
            CreateMap<Lead, LeadResponseDto>();
            CreateMap<LeadCreateDto, Lead>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
            CreateMap<LeadUpdateDto, Lead>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        }
    }
}
