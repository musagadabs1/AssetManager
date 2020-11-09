using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asset.Web.Models
{
    public class AssetViewModel
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
    }
}
