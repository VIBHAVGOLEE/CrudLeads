namespace CrudLeads.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IBrokerRepository Brokers { get; }
        ILeadRepository Leads { get; }
        IActivityTypeRepository ActivityTypes { get; }
        void SaveChanges();
    }
}
