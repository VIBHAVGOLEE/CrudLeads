using System;
using AutoMapper;
using CrudLeads.Application.DTOs;
using CrudLeads.Application.Interfaces;
using CrudLeads.Domain.Entities;
using CrudLeads.Domain.Interfaces;

namespace CrudLeads.Infrastructure.Services
{
    public class BrokerService : IBrokerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BrokerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public System.Collections.Generic.IEnumerable<BrokerResponseDto> GetAll()
        {
            var brokers = _unitOfWork.Brokers.GetAll();
            return _mapper.Map<System.Collections.Generic.IEnumerable<BrokerResponseDto>>(brokers);
        }

        public BrokerResponseDto GetById(long id)
        {
            var broker = _unitOfWork.Brokers.GetById(id);
            if (broker == null)
                return null;
            return _mapper.Map<BrokerResponseDto>(broker);
        }

        public BrokerResponseDto Create(BrokerCreateDto dto)
        {
            var entity = _mapper.Map<Broker>(dto);
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.Brokers.Add(entity);
            _unitOfWork.SaveChanges();
            return _mapper.Map<BrokerResponseDto>(entity);
        }

        public BrokerResponseDto Update(long id, BrokerUpdateDto dto)
        {
            var entity = _unitOfWork.Brokers.GetById(id);
            if (entity == null)
                return null;
            _mapper.Map(dto, entity);
            entity.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.Brokers.Update(entity);
            _unitOfWork.SaveChanges();
            return _mapper.Map<BrokerResponseDto>(entity);
        }

        public void Delete(long id)
        {
            var entity = _unitOfWork.Brokers.GetById(id);
            if (entity == null)
                return;
            _unitOfWork.Brokers.Remove(entity);
            _unitOfWork.SaveChanges();
        }
    }
}
