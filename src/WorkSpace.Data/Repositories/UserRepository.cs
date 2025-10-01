using Microsoft.EntityFrameworkCore;
using WorkSpace.Core.Domain;
using WorkSpace.Core.Repositories;
using WorkSpace.Data.SeedWorks;

namespace WorkSpace.Data.Repositories;

public class UserRepository : RepositoryBase<AppUser, int>, IUserRepository
{
    public UserRepository(WorkSpaceContext context) : base(context)
    {
    }

    public async Task RemoveUserFromRoles(int userId, string[] roleNames)
    {
        if (roleNames == null || roleNames.Length == 0)
        {
            return;
        }

        foreach (var roleName in roleNames)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(x => x.Name == roleName);
            if (role == null)
            {
                return;
            }

            var userRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.RoleId == role.Id && x.UserId == userId);
            if (userRole == null)
            {
                return;
            }
            _context.UserRoles.Remove(userRole);
        }
    }
    
}