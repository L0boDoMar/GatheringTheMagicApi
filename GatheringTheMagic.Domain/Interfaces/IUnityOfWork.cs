namespace GatheringTheMagic.Domain.Interfaces;

public interface IUnityOfWork
{
    Task Commit(CancellationToken cancellationToken);
}
