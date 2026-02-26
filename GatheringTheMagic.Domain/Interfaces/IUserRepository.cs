using GatheringTheMagic.Domain.Entities;

namespace GatheringTheMagic.Domain.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByEmail(string email, CancellationToken cancellationToken);
}
