using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate_Access.NHibernateEntity
{
    public interface IMapperSession
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();
        Task Save(NHibernateEmployee entity);
        Task Delete(NHibernateEmployee entity);
        IQueryable<NHibernateEmployee> Employees { get; }
    }
}
