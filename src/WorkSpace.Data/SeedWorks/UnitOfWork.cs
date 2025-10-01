using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WorkSpace.Core.Domain;
using WorkSpace.Core.Repositories;
using WorkSpace.Core.SeedWorks;
using WorkSpace.Data.Repositories;

namespace WorkSpace.Data.SeedWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly WorkSpaceContext _context;

    public UnitOfWork(WorkSpaceContext context, IMapper mapper, UserManager<AppUser> userManager)
    {
        _context = context;
        Users = new UserRepository(context);
    }
    public IUserRepository Users { get; }
    public Task<int> CompleteAsync()
    {
        throw new NotImplementedException();
    }
}