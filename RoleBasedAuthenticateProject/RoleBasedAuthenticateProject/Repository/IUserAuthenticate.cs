using RoleBasedAuthenticateProject.RequestModels;

namespace RoleBasedAuthenticateProject.Repository
{
    public interface IUserAuthenticate
    {
        public ResponseModel Authenticate(UserCredential user);
    }
}
