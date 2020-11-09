using Microsoft.EntityFrameworkCore;
using services.data.Interfaces;
using services.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace services.data.Repositories
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private AssetDbContext _context;
        public DepartmentRepository()
        {
            _context = new AssetDbContext();
        }

        public void AddDepartment(Department department)
        {
            try
            {
                _context.departments.Add(department);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task AddDepartmentAsync(Department department)
        {
            try
            {
                await _context.departments.AddAsync(department);
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

        public Department GetDepartment(int id)
        {
            try
            {
                return _context.departments.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Department> GetDepartmentAsync(int id)
        {
            try
            {
                return await _context.departments.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Department> GetDepartments()
        {
            try
            {
                return _context.departments.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            try
            {
                return await _context.departments.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync(Expression<Func<Department, bool>> expression)
        {
            try
            {
                return await _context.departments.Where(expression).ToListAsync();
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
