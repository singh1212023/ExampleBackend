using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RoleBasedAuthenticateProject.RequestModels
{
    public class TeacherViewModel
    {

        public int StatusCode { get; set; }
        public string Message { get; set; }

    }
    public class GetTeacher
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
    public class Addteacher
    {
        [Required]
        [DefaultValue("")]
        public string TeacherName { get; set; } = null!;
        [Required]
        [DefaultValue("")]
        public string TeacherEmail { get; set; } = null!;

        public DateTime? Dob { get; set; }
        [Required]
        [DefaultValue("")]
        [MaxLength(10),MinLength(5)]
        public int? TeacherPhone { get; set; }
        [Required]
        [DefaultValue("")]
        public string? City { get; set; }

    }

    public class UpdateTeacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; } = null!;
        public string TeacherEmail { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public int? TeacherPhone { get; set; }
        public string? City { get; set; }

    }


}
