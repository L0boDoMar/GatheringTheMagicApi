using GatheringTheMagic.Domain.Interfaces;
using GatheringTheMagic.Persistence.Context;

namespace GatheringTheMagic.Persistence.Repositories;

public class UnityOfWork : IUnityOfWork
{
    private readonly AppDbContext _context;
    public UnityOfWork(AppDbContext context)
    {
        _context = context;
    }
    public async Task Commit(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
