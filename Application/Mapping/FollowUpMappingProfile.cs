using AutoMapper;
using CrudLeads.Application.DTOs;
using CrudLeads.Domain.Entities;

namespace CrudLeads.Application.Mapping
{
    public class FollowUpMappingProfile : Profile
    {
        public FollowUpMappingProfile()
        {
            CreateMap<FollowUp, FollowUpResponseDto>()
                .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status != null ? src.Status.Name : null));

            CreateMap<FollowUpCreateDto, FollowUp>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Broker, opt => opt.Ignore())
                .ForMember(dest => dest.Lead, opt => opt.Ignore());

            CreateMap<FollowUpUpdateDto, FollowUp>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.BrokerId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Broker, opt => opt.Ignore())
                .ForMember(dest => dest.Lead, opt => opt.Ignore());
        }
    }
}

