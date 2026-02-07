using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CrudLeads.Domain.Entities;
using CrudLeads.Domain.Interfaces;
using CrudLeads.Infrastructure.Data;

namespace CrudLeads.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public User GetByUserName(string userName)
        {
            return Context.Set<User>()
                .Include(u => u.Role)
                .FirstOrDefault(u => u.UserName == userName);
        }

        public User GetByIdWithRole(long id)
        {
            return Context.Set<User>()
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAllWithRole()
        {
            return Context.Set<User>()
                .Include(u => u.Role)
                .ToList();
        }
    }
}
