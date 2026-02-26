using GatheringTheMagic.Domain.Entities;
using GatheringTheMagic.Domain.Interfaces;
using GatheringTheMagic.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GatheringTheMagic.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context) { }

    public async Task<User> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return await Context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

}
