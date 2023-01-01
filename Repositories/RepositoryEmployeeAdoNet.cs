using Ado.NetSqlHelper;
using Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryEmployeeAdoNet : IEmployeeRepositoryAdoNet
    {
        public RepositoryEmployeeAdoNet(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("HrSoultion");

        }

        public IConfiguration Configuration { get; }

        public String ConnectionString { get; set; }

        public List<Employee> GetAll()
        {
           var employees = new List<Employee>();
           var reader = SqlHelper1.ExecuteReader(ConnectionString, CommandType.Text, "Select * from Employee", null);
           employees  = reader.Select<Employee>(s =>
           new Employee {
               ID = int.Parse(s["ID"].ToString()),
               Email= s["Email"].ToString(),
               FirstName = s["FirstName"].ToString(),
               Mobile = s["Mobile"].ToString()
           }).ToList();
           return employees;
        }
    }
}
