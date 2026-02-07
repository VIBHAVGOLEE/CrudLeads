namespace CrudLeads.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IBrokerRepository Brokers { get; }
        ILeadRepository Leads { get; }
        IActivityTypeRepository ActivityTypes { get; }
        IFollowUpRepository FollowUps { get; }
        IStatusRepository Statuses { get; }
        ILeadSourceRepository LeadSources { get; }
        ICustomerRepository Customers { get; }
        void SaveChanges();
    }
}
