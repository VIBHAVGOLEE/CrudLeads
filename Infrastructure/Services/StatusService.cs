using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CrudLeads.Application.DTOs;
using CrudLeads.Application.Interfaces;
using CrudLeads.Domain.Interfaces;

namespace CrudLeads.Infrastructure.Services
{
    public class StatusService : IStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StatusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<StatusResponseDto> GetAll()
        {
            var statuses = _unitOfWork.Statuses.GetAll();
            return _mapper.Map<IEnumerable<StatusResponseDto>>(statuses);
        }

        public IEnumerable<StatusResponseDto> GetByCategory(string category)
        {
            var statuses = _unitOfWork.Statuses.Find(s => s.Category == category);
            return _mapper.Map<IEnumerable<StatusResponseDto>>(statuses);
        }

        public StatusResponseDto GetById(long id)
        {
            var status = _unitOfWork.Statuses.GetById(id);
            if (status == null)
                return null;
            return _mapper.Map<StatusResponseDto>(status);
        }
    }
}

