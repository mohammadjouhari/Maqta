using DTO;

namespace Maqta.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll(int skip, string method);
        void Add(Employee employee);
        Employee Get(int id);
        void Update(Employee employee);
        void Delete(int id);
    }
}
