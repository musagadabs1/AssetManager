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
    public class AssetsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public AssetsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<AssestController>
        [HttpGet]
        public async Task<IEnumerable<AssetDTO>> GetAssets()
        {
            var assetFromDb = await _unitOfWork.Asset.GetAssetsAsync();
            var assetDTo = assetFromDb.Select(x => new AssetDTO
            {
                AssignedOn = x.AssignedOn,
                AssignedTo = x.EmployeeId,
                Condition = x.Condition,
                DepartmentId = x.DepartmentId,
                SerialNumber = x.SerialNumber,
                Signature = x.Signature,
                Status = x.Status,
                Description = x.Description,
                Location = x.Location,
                Name = x.Name,
                ReturnedOn = x.ReturnedOn
            }).ToList();

            return assetDTo; //new string[] { "value1", "value2" };
        }

        [HttpGet("{employeeId}")]
        public async Task<IEnumerable<AssetDTO>> GetAssetsByEmployeeId(string employeeId)
        {
            var assetFromDb = await _unitOfWork.Asset.GetAssetsAsync(x => x.EmployeeId.Equals(employeeId));
            var assetDTo = assetFromDb.Select(x => new AssetDTO
            {
                AssignedOn = x.AssignedOn,
                AssignedTo = x.EmployeeId,
                Condition = x.Condition,
                DepartmentId = x.DepartmentId,
                SerialNumber = x.SerialNumber,
                //Signature = x.Signature,
                Status = x.Status,
                Description = x.Description,
                Location = x.Location,
                Name = x.Name,
                ReturnedOn = x.ReturnedOn
            }).ToList();

            return assetDTo; //new string[] { "value1", "value2" };
        }

        // GET: api/<AssestController>
        [HttpGet]
        public async Task<IEnumerable<AssetSummaryDTO>> GetAssetSummaries()
        {
            var assetSummaryFromDb = await _unitOfWork.AssetSummary.GetAssetSummariesAsync();
            var assetSummaryDTo = assetSummaryFromDb.Select(x => new AssetSummaryDTO
            {
                EmployeeName = x.EmployeeName,
                EmployeeId = x.EmployeeId,
                Department = x.Department
            }).ToList();

            return assetSummaryDTo; //new string[] { "value1", "value2" };
        }

        // GET api/<AssestController>/5
        [HttpGet("{id}")]
        public async Task<AssetDTO> GetAsset(int id)
        {

            var assetFromDb = await _unitOfWork.Asset.GetAssetAsync(id);
            var assetDTO = new AssetDTO
            {
                Name = assetFromDb.Name,
                AssignedOn = assetFromDb.AssignedOn,
                AssignedTo = assetFromDb.EmployeeId,
                Condition = assetFromDb.Condition,
                DepartmentId = assetFromDb.DepartmentId,
                SerialNumber = assetFromDb.SerialNumber,
                Signature = assetFromDb.Signature,
                Status = assetFromDb.Status,
                Description = assetFromDb.Description,
                Location = assetFromDb.Location,
                ReturnedOn = assetFromDb.ReturnedOn
            };
            return assetDTO; //"value";
        }

        // POST api/<AssestController>
        [HttpPost]
        public async Task PostAsset([FromBody] AssetDTO assetDTO)
        {
            try
            {
                var asset = new Asset
                {
                    AssignedOn = assetDTO.AssignedOn,
                    Condition = assetDTO.Condition,
                    DepartmentId = assetDTO.DepartmentId,
                    Description = assetDTO.Description,
                    Name = assetDTO.Name,
                    EmployeeId = assetDTO.AssignedTo,
                    SerialNumber = assetDTO.SerialNumber,
                    Signature = string.Format($"I {assetDTO.AssignedTo}, received {assetDTO.Name}  on {DateTime.Now}"),
                    Status = assetDTO.Status,
                    Location = assetDTO.Location,
                    ReturnedOn = assetDTO.ReturnedOn
                };
                await _unitOfWork.Asset.AddAssetAsync(asset);

                //Get previous staff record
                var getAssetSummary = await _unitOfWork.AssetSummary.GetAssetSummariesAsync(x => x.EmployeeId == asset.EmployeeId);

                //Determin whether the employee is assigned to a device already
                if (getAssetSummary.Count()<=0)
                {
                    var emp = _unitOfWork.Employee.GetEmployee(asset.EmployeeId);
                    var dept = _unitOfWork.Department.GetDepartment(asset.DepartmentId);
                    var assetSummary = new AssetSummary
                    {
                        Department = dept.Name,
                        EmployeeId = asset.EmployeeId,
                        EmployeeName = emp.FirstName + " " + emp.MiddleName + " " + emp.LastName
                        //Location = asset.Location
                    };
                    _unitOfWork.AssetSummary.AddAssetSummary(assetSummary);
                    await _unitOfWork.AssetSummary.SaveAsync();
                }
               await _unitOfWork.Asset.SaveAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // PUT api/<AssestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AssestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
