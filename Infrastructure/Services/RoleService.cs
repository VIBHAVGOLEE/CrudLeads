using System.Collections.Generic;
using AutoMapper;
using CrudLeads.Application.DTOs;
using CrudLeads.Application.Interfaces;
using CrudLeads.Domain.Interfaces;

namespace CrudLeads.Infrastructure.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<RoleResponseDto> GetAll()
        {
            var roles = _unitOfWork.Roles.GetAll();
            return _mapper.Map<IEnumerable<RoleResponseDto>>(roles);
        }

        public RoleResponseDto GetById(long id)
        {
            var role = _unitOfWork.Roles.GetById(id);
            if (role == null)
                return null;
            return _mapper.Map<RoleResponseDto>(role);
        }
    }
}
