using DTO;
using Newtonsoft.Json;
using System.Net;
namespace Maqta.Services
{
    public class EmployeeService : IEmployeeService
    {
        public IEnumerable<Employee> GetAll(int skip, string method)
        {
            var apiUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["BaseUrl"] +
                "/api/Emp/List?shouldLog=false&pageNumber={0}&pageSize=10&method={1}";
            var finalUrl = string.Format(apiUrl, skip, method);
            WebClient client = new WebClient();
            var response = client.DownloadString(finalUrl);
            List<DTO.Employee> employees = JsonConvert.DeserializeObject<List<DTO.Employee>>(response);
            return employees;
        }
        public void Add(Employee employee)
        {
            var apiUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["BaseUrl"] +
                "/api/Emp/Add";
            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                string Json = Newtonsoft.Json.JsonConvert.SerializeObject(employee);
                client.UploadString(apiUrl, Json);
            }
        }

        public void GetEmployee(Employee employee)
        {
            var apiUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["BaseUrl"] +
                "/api/Emp/Add";
            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                string Json = Newtonsoft.Json.JsonConvert.SerializeObject(employee);
                client.UploadString(apiUrl, Json);
            }
        }

        public Employee Get(int Id)
        {
            var apiUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["BaseUrl"] +
                  "/api/Emp/GetEmployee?id=" + Id;
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var response = client.DownloadString(apiUrl);
            DTO.Employee employeeResult = JsonConvert.DeserializeObject<DTO.Employee>(response);
            return employeeResult;
        }

        public void Update(Employee employee)
        {
            var apiUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["BaseUrl"] +
                "/api/Emp/Edit";
            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                string Json = Newtonsoft.Json.JsonConvert.SerializeObject(employee);
                var response = client.UploadString(apiUrl,"POST",Json);
            }
        }

        public void Delete(int id)
        {
            var apiUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["BaseUrl"] +
                  "/api/Emp/Delete?id=" + id;
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var response = client.DownloadString(apiUrl);
        }
    }
}
