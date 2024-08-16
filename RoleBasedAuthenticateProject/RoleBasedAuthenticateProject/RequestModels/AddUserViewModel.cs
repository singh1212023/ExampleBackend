namespace RoleBasedAuthenticateProject.RequestModels
{
    public class AddUserViewModel
    {

        public string UserName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string? UserPhone { get; set; }
    }

    public class GetUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string? UserPhone { get; set; }


    }
}
