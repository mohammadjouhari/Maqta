namespace Repositories
{
    public interface IUnitOfWork
    {
       IRepositoryEmployee Employee { get; }
       void Complete();
       void Dispose();
       void Clear();
    }
}
