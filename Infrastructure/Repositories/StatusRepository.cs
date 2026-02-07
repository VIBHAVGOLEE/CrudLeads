using CrudLeads.Domain.Entities;
using CrudLeads.Domain.Interfaces;
using CrudLeads.Infrastructure.Data;

namespace CrudLeads.Infrastructure.Repositories
{
    public class StatusRepository : GenericRepository<Status>, IStatusRepository
    {
        public StatusRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}

