using System;
using AutoMapper;
using CrudLeads.Application.DTOs;
using CrudLeads.Application.Interfaces;
using CrudLeads.Domain.Entities;
using CrudLeads.Domain.Interfaces;

namespace CrudLeads.Infrastructure.Services
{
    /// <summary>
    /// Application service implementation for Lead CRUD (no MediatR).
    /// </summary>
    public class LeadService : ILeadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeadService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public System.Collections.Generic.IEnumerable<LeadResponseDto> GetAll()
        {
            var leads = _unitOfWork.Leads.GetAll();
            return _mapper.Map<System.Collections.Generic.IEnumerable<LeadResponseDto>>(leads);
        }

        public LeadResponseDto GetById(int id)
        {
            var lead = _unitOfWork.Leads.GetById(id);
            if (lead == null)
                return null;
            return _mapper.Map<LeadResponseDto>(lead);
        }

        public LeadResponseDto Create(LeadCreateDto dto)
        {
            var entity = _mapper.Map<Lead>(dto);
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.Leads.Add(entity);
            _unitOfWork.SaveChanges();
            return _mapper.Map<LeadResponseDto>(entity);
        }

        public LeadResponseDto Update(int id, LeadUpdateDto dto)
        {
            var entity = _unitOfWork.Leads.GetById(id);
            if (entity == null)
                return null;
            _mapper.Map(dto, entity);
            entity.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.Leads.Update(entity);
            _unitOfWork.SaveChanges();
            return _mapper.Map<LeadResponseDto>(entity);
        }

        public void Delete(int id)
        {
            var entity = _unitOfWork.Leads.GetById(id);
            if (entity == null)
                return;
            _unitOfWork.Leads.Remove(entity);
            _unitOfWork.SaveChanges();
        }
    }
}
