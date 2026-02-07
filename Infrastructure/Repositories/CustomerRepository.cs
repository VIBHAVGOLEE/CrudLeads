using System.Linq;
using CrudLeads.Domain.Entities;
using CrudLeads.Domain.Interfaces;
using CrudLeads.Infrastructure.Data;

namespace CrudLeads.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public Customer GetByLeadId(long leadId)
        {
            return DbSet.FirstOrDefault(c => c.LeadId == leadId);
        }
    }
}

