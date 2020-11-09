using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using service.api.DTOModels;
using services.data.Interfaces;
using services.data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace service.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public DepartmentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<DepartmentsController>
        [HttpGet]
        public async Task<IEnumerable<DepartmentDTO>> GetDepartments()
        {
            try
            {
                var deptFromDb = await _unitOfWork.Department.GetDepartmentsAsync();
                var depts = deptFromDb.Select(dept => new DepartmentDTO
                {
                    Name = dept.Name,
                    Id = dept.Id
                }).ToList();

                return depts;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public async Task<DepartmentDTO> GetDepartment(int id)
        {
            try
            {
                var deptFromDb = await _unitOfWork.Department.GetDepartmentAsync(id);
                var dept = new DepartmentDTO
                {
                    Name = deptFromDb.Name,
                    Id = deptFromDb.Id
                };
                return dept;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public async Task PostDepartment([FromBody] DepartmentDTO departmentDTO)
        {
            try
            {
                var dept = new Department
                {
                    Name = departmentDTO.Name
                };
                await _unitOfWork.Department.AddDepartmentAsync(dept);
                _unitOfWork.Department.Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
