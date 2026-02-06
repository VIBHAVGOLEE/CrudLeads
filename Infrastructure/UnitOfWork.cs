using CrudLeads.Domain.Interfaces;
using CrudLeads.Infrastructure.Data;
using CrudLeads.Infrastructure.Repositories;

namespace CrudLeads.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IBrokerRepository _brokers;
        private ILeadRepository _leads;
        private IActivityTypeRepository _activityTypes;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IBrokerRepository Brokers
        {
            get { return _brokers ?? (_brokers = new BrokerRepository(_context)); }
        }

        public ILeadRepository Leads
        {
            get { return _leads ?? (_leads = new LeadRepository(_context)); }
        }

        public IActivityTypeRepository ActivityTypes
        {
            get { return _activityTypes ?? (_activityTypes = new ActivityTypeRepository(_context)); }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
