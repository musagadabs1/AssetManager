using services.data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace services.data.Interfaces
{
    public interface IDepartmentRepository
    {
        void AddDepartment(Department department);
        Task AddDepartmentAsync(Department department);
        void Save();
        Task SaveAsync();
        void Dispose();
        Department GetDepartment(int id);
        Task<Department> GetDepartmentAsync(int id);
        IEnumerable<Department> GetDepartments();
        Task<IEnumerable<Department>> GetDepartmentsAsync();
        Task<IEnumerable<Department>> GetDepartmentsAsync(Expression<Func<Department, bool>> expression);
    }
}
