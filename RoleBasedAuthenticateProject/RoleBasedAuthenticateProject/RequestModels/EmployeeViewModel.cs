namespace RoleBasedAuthenticateProject.RequestModels
{
    public class EmployeeViewModel
    {
        public class GetEmployeeDto
        {
            public int EmpId { get; set; }
            public string EmpName { get; set; } = null!;
            public string EmpEmail { get; set; } = null!;
            public DateTime? Dob { get; set; }
            public int? EmpPhone { get; set; }
            public string? City { get; set; }
            public bool? IsActive { get; set; }
            public string? CreatedBy { get; set; }
            public DateTime? CreatedOn { get; set; }
        }
    }
}
