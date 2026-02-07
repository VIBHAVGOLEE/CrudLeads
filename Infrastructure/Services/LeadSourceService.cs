using System.Collections.Generic;
using AutoMapper;
using CrudLeads.Application.DTOs;
using CrudLeads.Application.Interfaces;
using CrudLeads.Domain.Interfaces;

namespace CrudLeads.Infrastructure.Services
{
    public class LeadSourceService : ILeadSourceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeadSourceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<LeadSourceResponseDto> GetAll()
        {
            var sources = _unitOfWork.LeadSources.GetAll();
            return _mapper.Map<IEnumerable<LeadSourceResponseDto>>(sources);
        }

        public LeadSourceResponseDto GetById(long id)
        {
            var source = _unitOfWork.LeadSources.GetById(id);
            if (source == null)
                return null;
            return _mapper.Map<LeadSourceResponseDto>(source);
        }
    }
}

