using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace services.data.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        [Key]
        [StringLength(50)]
        public virtual string EmployeeId { get; set; }
        [Required]
        [StringLength(30)]
        public virtual string FirstName { get; set; }
        [StringLength(30)]
        public virtual string MiddleName { get; set; }
        [Required]
        [StringLength(30)]
        public virtual string LastName { get; set; }
        public virtual int DeptId { get; set; }
        //[Required]
        [StringLength(30)]
        public virtual string Rank { get; set; }
        [DataType(DataType.DateTime)]
        public virtual DateTime DateEmployeed { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }
    }
}