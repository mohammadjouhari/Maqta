using Dapper;
using Entity;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repositories
{
    public class DapperRepository : IDapperRepository
    {
        public DapperRepository(IDbConnection dbConnection) 
        {
            DbConnection = dbConnection;
        }

        public IDbConnection DbConnection { get; }

        public List<Employee> GetAllEmployess()
        {
            var s = new List<Employee>();
            s = DbConnection.Query<Employee>("select * from Employee").ToList();
            var t = DbConnection.Query<Employee>("GetEmployees", commandType: CommandType.StoredProcedure).ToList();
            return s;
        }
    }
}
