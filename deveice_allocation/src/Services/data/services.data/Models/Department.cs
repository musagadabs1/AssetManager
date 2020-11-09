using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace services.data.Models
{
    public class Department
    {
        public virtual int Id { get; set; }
        [Required]
        [StringLength(50)]
        public virtual string Name { get; set; }


        public virtual ICollection<Asset> Assets { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
