using System;
using System.Collections.Generic;

namespace RoleBasedAuthenticateProject.Models
{
    public partial class SatyamTeacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; } = null!;
        public string TeacherEmail { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public int? TeacherPhone { get; set; }
        public string? City { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
