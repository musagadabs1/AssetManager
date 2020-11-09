using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace service.api.DTOModels
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public virtual string Name { get; set; }
    }
}
