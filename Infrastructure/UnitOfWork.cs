using CrudLeads.Domain.Interfaces;
using CrudLeads.Infrastructure.Data;
using CrudLeads.Infrastructure.Repositories;

namespace CrudLeads.Infrastructure
{
    /// <summary>
    /// Unit of Work implementation coordinating repositories and persistence.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private ILeadRepository _leads;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ILeadRepository Leads
        {
            get { return _leads ?? (_leads = new LeadRepository(_context)); }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
