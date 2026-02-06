using CrudLeads.Domain.Entities;
using CrudLeads.Domain.Interfaces;
using CrudLeads.Infrastructure.Data;

namespace CrudLeads.Infrastructure.Repositories
{
    public class BrokerRepository : GenericRepository<Broker>, IBrokerRepository
    {
        public BrokerRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
