using WorkSpace.Core.Domain;
using WorkSpace.Core.SeedWorks;

namespace WorkSpace.Core.Repositories;

public interface IUserRepository : IRepository<AppUser, int>
{
    Task RemoveUserFromRoles(int userId, string[] roles);
}