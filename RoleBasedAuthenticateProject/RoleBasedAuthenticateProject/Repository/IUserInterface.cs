using RoleBasedAuthenticateProject.RequestModels;

namespace RoleBasedAuthenticateProject.Repository
{
    public interface IUserInterface
    {
        public ResponseModel AddUserDetails(AddUserViewModel add);

        public ResponseModel GetUser();
    }
}
