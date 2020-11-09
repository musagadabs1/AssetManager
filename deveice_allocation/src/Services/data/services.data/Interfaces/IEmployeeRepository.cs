using services.data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace services.data.Interfaces
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        Task AddEmployeeAsync(Employee asset);
        void Save();
        Task SaveAsync();
        void Dispose();
        Employee GetEmployee(string id);
        Task<Employee> GetEmployeeAsync(string id);
        IEnumerable<Employee> GetEmployees();
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<IEnumerable<Employee>> GetEmployeesAsync(Expression<Func<Employee, bool>> expression);
    }
}
