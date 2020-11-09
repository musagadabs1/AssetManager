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
    public class EmployeesController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            try
            {
                var employeesFromDb = await _unitOfWork.Employee.GetEmployeesAsync();
                var employees = employeesFromDb.Select(emp => new EmployeeDTO
                {
                    EmployeeId = emp.EmployeeId,
                    FirstName = emp.FirstName,
                    MiddleName = emp.MiddleName,
                    LastName = emp.LastName,
                    DeptId = emp.DeptId,
                    Rank = emp.Rank,
                    DateEmployeed = emp.DateEmployeed
                }).ToList();
                return employees;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<EmployeeDTO> GetEmployee(string id)
        {
            try
            {
                var empFromDb = await _unitOfWork.Employee.GetEmployeeAsync(id);
                var emp = new EmployeeDTO
                {
                    EmployeeId = empFromDb.EmployeeId,
                    DateEmployeed = empFromDb.DateEmployeed,
                    MiddleName = empFromDb.MiddleName,
                    LastName = empFromDb.LastName,
                    FirstName = empFromDb.FirstName,
                    Rank = empFromDb.Rank,
                    DeptId = empFromDb.DeptId

                };
                return emp;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task PostEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            try
            {
                var emp = new Employee
                {
                    FirstName = employeeDTO.FirstName,
                    MiddleName = employeeDTO.MiddleName,
                    LastName = employeeDTO.LastName,
                    DeptId = employeeDTO.DeptId,
                    DateEmployeed = employeeDTO.DateEmployeed,
                    EmployeeId = employeeDTO.EmployeeId,
                    Rank = employeeDTO.Rank
                };
                _unitOfWork.Employee.AddEmployee(emp);
                await _unitOfWork.Employee.SaveAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
