using NHibernate;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
>>>>>>> 7f5fe51 (Added my project)

namespace NHibernate_Access.NHibernateEntity
{
    public class NHibernateMapperSession : IMapperSession
    {
        private readonly ISession _session;
        private ITransaction _transaction;
        public NHibernateMapperSession(ISession session)
        {
            _session = session;
        }
        public IQueryable<NHibernateEmployee> Employees => _session.Query<NHibernateEmployee>();
        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }
        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }
        public void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }
        public async Task Save(NHibernateEmployee entity)
        {
            await _session.SaveOrUpdateAsync(entity);
        }
        public async Task Delete(NHibernateEmployee entity)
        {
            await _session.DeleteAsync(entity);
        }
    }
}
