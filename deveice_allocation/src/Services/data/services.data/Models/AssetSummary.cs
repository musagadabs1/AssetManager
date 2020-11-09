using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace services.data.Models
{
    public class AssetSummary
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string EmployeeName { get; set; }
        [Required]
        [StringLength(30)]
        public string Department { get; set; }
        [Required]
        [StringLength(50)]
        public string EmployeeId { get; set; }
        [StringLength(50)]
        public string Location { get; set; }

    }
}
