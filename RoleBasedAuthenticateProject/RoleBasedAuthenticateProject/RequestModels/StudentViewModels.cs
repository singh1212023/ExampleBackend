using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RoleBasedAuthenticateProject.RequestModels
{
    public class StudentViewModels
    {
        public int StatusCode { get; set; } 
        public string Message { get; set; }    

    }

    public class GetStudent
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
 

    public class AddUpdate
    {
        public int StudentId { get; set; }
        [Required]
        [DefaultValue("")]
        public string StudentName { get; set; } = null!;
        [Required]
        [DefaultValue("")]
        public string StudentEmail { get; set; } = null!;
       
        public DateTime? Dob { get; set; }
        [Required]
        [DefaultValue("")]
        [MaxLength(10), MinLength(5)]
        public int? StudentPhone { get; set; }
        [Required]
        [DefaultValue("")]
        public string? City { get; set; }

    }


}

























//public class AddStudent
//{

//    public string StudentName { get; set; } = null!;
//    public string StudentEmail { get; set; } = null!;
//    public DateTime? Dob { get; set; }
//    public int? StudentPhone { get; set; }
//    public string? City { get; set; }

//}

//public class UpdateStudent
//{

//    public int StduentId { get; set; }  
//    public string StudentName { get; set; } = null!;
//    public string StudentEmail { get; set; } = null!;
//    public DateTime? Dob { get; set; }
//    public int? StudentPhone { get; set; }
//    public string? City { get; set; }

//}