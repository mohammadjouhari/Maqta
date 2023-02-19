using Ado.NetSqlHelper;
using DTO;
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

        public List<Employee> GetAllEmployess()
        {
            var entitiyAdoNet = SqlHelper1.ExecuteReader(Configuration.GetConnectionString("HrSoultion"),
                 CommandType.Text, "select * from employee", null);
            List<DTO.Employee> employees = new List<DTO.Employee>();
            employees = DataReaderMapToList<Employee>(entitiyAdoNet);
            entitiyAdoNet.Close();
            entitiyAdoNet.Dispose();
            return employees;
        }
    }
}
