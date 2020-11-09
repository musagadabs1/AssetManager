using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asset.Web.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public virtual string EmployeeId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int DeptId { get; set; }
        public virtual string Rank { get; set; }
        public virtual DateTime DateEmployeed { get; set; }
    }
}
