using CrudLeads.Domain.Entities;
using CrudLeads.Domain.Interfaces;
using CrudLeads.Infrastructure.Data;

namespace CrudLeads.Infrastructure.Repositories
{
    public class FollowUpRepository : GenericRepository<FollowUp>, IFollowUpRepository
    {
        public FollowUpRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}

