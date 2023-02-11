using Entity;

namespace Repositories
{
    public class RepositoryEmployee :  Repository<Entity.Employee>, IRepositoryEmployee
    {
        public RepositoryEmployee(DBContext dbContext)
            : base(dbContext)
        {
        }
    }
}