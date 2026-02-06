using System.Linq;
using AutoMapper;
using CrudLeads.Application.DTOs;
using CrudLeads.Application.Interfaces;
using CrudLeads.Domain.Interfaces;

namespace CrudLeads.Infrastructure.Services
{
    public class ActivityTypeService : IActivityTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActivityTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public System.Collections.Generic.IEnumerable<ActivityTypeResponseDto> GetAll()
        {
            var activityTypes = _unitOfWork.ActivityTypes.GetAll();
            return _mapper.Map<System.Collections.Generic.IEnumerable<ActivityTypeResponseDto>>(activityTypes);
        }

        public ActivityTypeResponseDto GetById(long id)
        {
            var activityType = _unitOfWork.ActivityTypes.GetById(id);
            if (activityType == null)
                return null;
            return _mapper.Map<ActivityTypeResponseDto>(activityType);
        }
    }
}
