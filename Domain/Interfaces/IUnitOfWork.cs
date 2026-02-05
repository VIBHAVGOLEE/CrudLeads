namespace CrudLeads.Domain.Interfaces
{
    /// <summary>
    /// Unit of Work interface for transactional operations.
    /// </summary>
    public interface IUnitOfWork
    {
        ILeadRepository Leads { get; }
        void SaveChanges();
    }
}
