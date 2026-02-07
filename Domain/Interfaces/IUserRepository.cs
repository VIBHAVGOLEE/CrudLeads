using CrudLeads.Domain.Entities;

namespace CrudLeads.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByUserName(string userName);
        User GetByIdWithRole(long id);
        System.Collections.Generic.IEnumerable<User> GetAllWithRole();
    }
}
