using System;
using System.Collections.Generic;

namespace RoleBasedAuthenticateProject.Models
{
    public partial class SatyamStudent
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = null!;
        public string StudentEmail { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public int? StudentPhone { get; set; }
        public string? City { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
