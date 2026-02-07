using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CrudLeads.Application.DTOs;
using CrudLeads.Application.Interfaces;
using CrudLeads.Domain.Entities;
using CrudLeads.Domain.Interfaces;

namespace CrudLeads.Infrastructure.Services
{
    public class FollowUpService : IFollowUpService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FollowUpService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<FollowUpResponseDto> GetAll()
        {
            var followUps = _unitOfWork.FollowUps.GetAll();
            return followUps.Select(MapToDto);
        }

        public IEnumerable<FollowUpResponseDto> GetByBrokerId(long brokerId)
        {
            var followUps = _unitOfWork.FollowUps.Find(f => f.BrokerId == brokerId);
            return followUps.Select(MapToDto);
        }

        public IEnumerable<FollowUpResponseDto> GetByLeadId(long leadId)
        {
            var followUps = _unitOfWork.FollowUps.Find(f => f.LeadId == leadId);
            return followUps.Select(MapToDto);
        }

        public FollowUpResponseDto GetById(long id)
        {
            var followUp = _unitOfWork.FollowUps.GetById(id);
            if (followUp == null)
                return null;
            return MapToDto(followUp);
        }

        public FollowUpResponseDto Create(FollowUpCreateDto dto)
        {
            var entity = _mapper.Map<FollowUp>(dto);
            entity.CreatedOn = DateTime.UtcNow;
            _unitOfWork.FollowUps.Add(entity);
            _unitOfWork.SaveChanges();
            return MapToDto(entity);
        }

        public FollowUpResponseDto Update(long id, FollowUpUpdateDto dto)
        {
            var entity = _unitOfWork.FollowUps.GetById(id);
            if (entity == null)
                return null;

            if (dto.LeadId.HasValue) entity.LeadId = dto.LeadId;
            if (dto.FollowUpDate.HasValue) entity.FollowUpDate = dto.FollowUpDate.Value;
            if (dto.Remark != null) entity.Remark = dto.Remark;
            if (dto.StatusId.HasValue) entity.StatusId = dto.StatusId;
            if (dto.IsCompleted.HasValue) entity.IsCompleted = dto.IsCompleted.Value;

            _unitOfWork.FollowUps.Update(entity);
            _unitOfWork.SaveChanges();
            return MapToDto(entity);
        }

        public void Delete(long id)
        {
            var entity = _unitOfWork.FollowUps.GetById(id);
            if (entity == null)
                return;
            _unitOfWork.FollowUps.Remove(entity);
            _unitOfWork.SaveChanges();
        }

        private FollowUpResponseDto MapToDto(FollowUp followUp)
        {
            var dto = _mapper.Map<FollowUpResponseDto>(followUp);
            if (followUp.Status != null)
            {
                dto.StatusName = followUp.Status.Name;
            }
            return dto;
        }
    }
}

