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
        private IFollowUpRepository _followUps;
        private IStatusRepository _statuses;
        private ILeadSourceRepository _leadSources;
        private ICustomerRepository _customers;
        private IUserRepository _users;
        private IRoleRepository _roles;

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

        public IFollowUpRepository FollowUps
        {
            get { return _followUps ?? (_followUps = new FollowUpRepository(_context)); }
        }

        public IStatusRepository Statuses
        {
            get { return _statuses ?? (_statuses = new StatusRepository(_context)); }
        }

        public ILeadSourceRepository LeadSources
        {
            get { return _leadSources ?? (_leadSources = new LeadSourceRepository(_context)); }
        }

        public ICustomerRepository Customers
        {
            get { return _customers ?? (_customers = new CustomerRepository(_context)); }
        }

        public IUserRepository Users
        {
            get { return _users ?? (_users = new UserRepository(_context)); }
        }

        public IRoleRepository Roles
        {
            get { return _roles ?? (_roles = new RoleRepository(_context)); }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
