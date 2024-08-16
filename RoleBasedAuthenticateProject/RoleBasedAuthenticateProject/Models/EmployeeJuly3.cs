using System;
using System.Collections.Generic;

namespace RoleBasedAuthenticateProject.Models
{
    public partial class EmployeeJuly3
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; } = null!;
        public string EmpEmail { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public int? EmpPhone { get; set; }
        public string? City { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
