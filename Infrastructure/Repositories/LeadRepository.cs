using CrudLeads.Domain.Entities;
using CrudLeads.Domain.Interfaces;
using CrudLeads.Infrastructure.Data;

namespace CrudLeads.Infrastructure.Repositories
{
    /// <summary>
    /// Repository implementation for Lead entity.
    /// </summary>
    public class LeadRepository : GenericRepository<Lead>, ILeadRepository
    {
        public LeadRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
