using System;
using System.Linq;
using AutoMapper;
using CrudLeads.Application.DTOs;
using CrudLeads.Application.Interfaces;
using CrudLeads.Domain.Entities;
using CrudLeads.Domain.Interfaces;

namespace CrudLeads.Infrastructure.Services
{
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
            return leads.Select(l => MapToDto(l));
        }

        public System.Collections.Generic.IEnumerable<LeadResponseDto> GetByBrokerId(long brokerId)
        {
            var leads = _unitOfWork.Leads.Find(l => l.BrokerId == brokerId);
            return leads.Select(l => MapToDto(l));
        }

        public LeadResponseDto GetById(long id)
        {
            var lead = _unitOfWork.Leads.GetById(id);
            if (lead == null)
                return null;
            return MapToDto(lead);
        }

        public LeadResponseDto Create(LeadCreateDto dto)
        {
            var entity = _mapper.Map<Lead>(dto);
            entity.CreatedDate = DateTime.UtcNow;
            if (entity.Completed)
            {
                entity.CompletedOn = DateTime.UtcNow;
            }
            _unitOfWork.Leads.Add(entity);
            _unitOfWork.SaveChanges();
            return MapToDto(entity);
        }

        public LeadResponseDto Update(long id, LeadUpdateDto dto)
        {
            var entity = _unitOfWork.Leads.GetById(id);
            if (entity == null)
                return null;

            if (dto.Title != null) entity.Title = dto.Title;
            if (dto.Remark != null) entity.Remark = dto.Remark;
            if (dto.Mobile != null) entity.Mobile = dto.Mobile;
            if (dto.ActivityTypeId.HasValue) entity.ActivityTypeId = dto.ActivityTypeId.Value;
            if (dto.AssignedBy.HasValue) entity.AssignedBy = dto.AssignedBy;
            if (dto.ScheduleDate.HasValue) entity.ScheduleDate = dto.ScheduleDate.Value;
            if (dto.ReminderMinutes.HasValue) entity.ReminderMinutes = dto.ReminderMinutes;
            if (dto.RemindMe.HasValue) entity.RemindMe = dto.RemindMe.Value;
            if (dto.Completed.HasValue)
            {
                entity.Completed = dto.Completed.Value;
                if (dto.Completed.Value && !entity.CompletedOn.HasValue)
                {
                    entity.CompletedOn = DateTime.UtcNow;
                }
                else if (!dto.Completed.Value)
                {
                    entity.CompletedOn = null;
                }
            }
            if (dto.CompletedOn.HasValue) entity.CompletedOn = dto.CompletedOn;
            if (dto.CompletedBy.HasValue) entity.CompletedBy = dto.CompletedBy;
            if (dto.Stage != null) entity.Stage = dto.Stage;
            if (dto.Status != null) entity.Status = dto.Status;
            if (dto.Action != null) entity.Action = dto.Action;

            _unitOfWork.Leads.Update(entity);
            _unitOfWork.SaveChanges();
            return MapToDto(entity);
        }

        public void Delete(long id)
        {
            var entity = _unitOfWork.Leads.GetById(id);
            if (entity == null)
                return;
            _unitOfWork.Leads.Remove(entity);
            _unitOfWork.SaveChanges();
        }

        private LeadResponseDto MapToDto(Lead lead)
        {
            var dto = _mapper.Map<LeadResponseDto>(lead);
            if (lead.ActivityType != null)
            {
                dto.ActivityTypeName = lead.ActivityType.Name;
            }
            return dto;
        }
    }
}
