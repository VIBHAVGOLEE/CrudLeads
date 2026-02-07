using CrudLeads.Domain.Entities;

namespace CrudLeads.Domain.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Customer GetByLeadId(long leadId);
    }
}

