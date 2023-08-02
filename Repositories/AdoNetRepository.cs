using Ado.NetSqlHelper;
using Microsoft.Extensions.Configuration;
using System.Data;
using static Ado.NetSqlHelper.SqlDataReaderExtensions;
namespace Repositories
{
    public class AdoNetRepository : IAdoNetRepository
    {
        public AdoNetRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public List<Entity.Employee> GetAllEmployess()
        {
            var connectionString = Configuration.GetConnectionString("HrSoultion");
            var reader = SqlHelper.ExecuteReader(connectionString,CommandType.Text, "select * from employee", null);
            List<Entity.Employee> employees = new List<Entity.Employee>(); 
            employees = DataReaderMapToList<Entity.Employee>(reader);
            reader.Close();
            reader.Dispose();
            return employees;
        }
    }
}
