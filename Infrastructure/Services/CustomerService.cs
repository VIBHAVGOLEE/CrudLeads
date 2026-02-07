using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CrudLeads.Application.DTOs;
using CrudLeads.Application.Interfaces;
using CrudLeads.Domain.Interfaces;

namespace CrudLeads.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<CustomerResponseDto> GetAll()
        {
            var customers = _unitOfWork.Customers.GetAll();
            return MapWithLeadSource(customers);
        }

        public IEnumerable<CustomerResponseDto> GetByBrokerId(long brokerId)
        {
            var customers = _unitOfWork.Customers.Find(c => c.BrokerId == brokerId);
            return MapWithLeadSource(customers);
        }

        public CustomerResponseDto GetByLeadId(long leadId)
        {
            var customer = _unitOfWork.Customers.GetByLeadId(leadId);
            if (customer == null)
                return null;
            return MapWithLeadSource(new[] { customer }).FirstOrDefault();
        }

        public CustomerResponseDto GetById(long id)
        {
            var customer = _unitOfWork.Customers.GetById(id);
            if (customer == null)
                return null;
            return MapWithLeadSource(new[] { customer }).FirstOrDefault();
        }

        private IEnumerable<CustomerResponseDto> MapWithLeadSource(IEnumerable<Domain.Entities.Customer> customers)
        {
            var list = customers.ToList();
            var dtos = _mapper.Map<List<CustomerResponseDto>>(list);

            var leadSourceDict = _unitOfWork.LeadSources
                .GetAll()
                .ToDictionary(ls => ls.Id, ls => ls.Name);

            foreach (var dto in dtos)
            {
                if (dto.LeadSourceId.HasValue && leadSourceDict.TryGetValue(dto.LeadSourceId.Value, out var name))
                {
                    dto.LeadSourceName = name;
                }
            }

            return dtos;
        }
    }
}

