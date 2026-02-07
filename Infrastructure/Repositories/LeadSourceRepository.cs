using CrudLeads.Domain.Entities;
using CrudLeads.Domain.Interfaces;
using CrudLeads.Infrastructure.Data;

namespace CrudLeads.Infrastructure.Repositories
{
    public class LeadSourceRepository : GenericRepository<LeadSource>, ILeadSourceRepository
    {
        public LeadSourceRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}

