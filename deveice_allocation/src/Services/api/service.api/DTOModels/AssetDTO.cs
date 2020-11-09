using services.data.Models;
using System;

namespace service.api.DTOModels
{
    public class AssetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Condition { get; set; }
        public string Status { get; set; }
        public string SerialNumber { get; set; }
        public string AssignedTo { get; set; }
        public DateTime AssignedOn { get; set; }
        public string Signature { get; set; }
        public DateTime ReturnedOn { get; set; }
        public int DepartmentId { get; set; }
        public AssetDTO GetAssetDTO(Asset asset)
        {
            return new AssetDTO
            {
                AssignedOn = asset.AssignedOn,
                AssignedTo = asset.EmployeeId,
                Condition = asset.Condition,
                DepartmentId = asset.DepartmentId,
                Description = asset.Description,
                SerialNumber = asset.SerialNumber,
                Signature = asset.Signature,
                Status = asset.Status,
                Location = asset.Location,
                Name = asset.Name,
                ReturnedOn = asset.ReturnedOn
            };
        }
    }
}
