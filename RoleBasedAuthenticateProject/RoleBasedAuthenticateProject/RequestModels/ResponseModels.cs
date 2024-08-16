using static RoleBasedAuthenticateProject.RequestModels.EmployeeViewModel;

namespace RoleBasedAuthenticateProject.RequestModels
{
    public class ResponseModel
    {
        public string ResponseMessage { get; set; }
        public int StatusCode { get; set; }
        public string Token { get; set; }
        public List<GetStudent> Studentlist { get; set; }

        public GetStudent Student { get; set; }

        public List<GetTeacher> TeacherList { get; set; }
        public GetTeacher Teacher { get; set; }

        public List<GetUser> UserList { get; set; }

    }
    public class UserCredential
    {
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;

    }


    public class JwtClass
    {
        public string key { get; set; }
        public string Issuer { get; set; }
        public string Auidence { get; set; }
        public string Subject { get; set; }


    }
}

