using WorkSpace.Core.Repositories;

namespace WorkSpace.Core.SeedWorks;

public interface IUnitOfWork
{
    IUserRepository Users { get; }

    Task<int> CompleteAsync();
}