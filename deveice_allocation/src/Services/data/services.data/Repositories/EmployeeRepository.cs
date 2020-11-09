using Microsoft.EntityFrameworkCore;
using services.data.Interfaces;
using services.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace services.data.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private AssetDbContext _context;
        public EmployeeRepository()
        {
            _context = new AssetDbContext();
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                _context.employees.Add(employee);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            try
            {
                await _context.employees.AddAsync(employee);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            try
            {
                _context.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Employee GetEmployee(string id)
        {
            try
            {
                return _context.employees.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Employee> GetEmployeeAsync(string id)
        {
            try
            {
                return await _context.employees.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                return _context.employees.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            try
            {
                return await _context.employees.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(Expression<Func<Employee, bool>> expression)
        {
            try
            {
                return await _context.employees.Where(expression).ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
