using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace services.data.Models
{
    public class Asset
    {
        public virtual int Id { get; set; }
        [Required]
        [StringLength(50)]
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        [StringLength(50)]
        [Required]
        public virtual string Location { get; set; }
        [Required]
        [StringLength(15)]
        public virtual string Condition { get; set; }
        [Required]
        [StringLength(20)]
        public virtual string Status { get; set; }
        [Required]
        [StringLength(50)]
        public virtual string SerialNumber { get; set; }
        [Required]
        [StringLength(50)]
        public virtual string EmployeeId { get; set; }
        [DataType(DataType.DateTime)]
        public virtual DateTime AssignedOn { get; set; }
        public virtual string Signature { get; set; }
        public virtual DateTime ReturnedOn { get; set; }
        [Required]
        public virtual int DepartmentId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Department Department { get; set; }
    }
}
