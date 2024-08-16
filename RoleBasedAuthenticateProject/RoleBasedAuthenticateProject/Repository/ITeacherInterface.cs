using RoleBasedAuthenticateProject.RequestModels;

namespace RoleBasedAuthenticateProject.Repository
{
    public interface ITeacherInterface
    {

        public ResponseModel GetTeacher();

        public ResponseModel AddTeacherData(Addteacher teacher);

        public ResponseModel UpdateTeacher(UpdateTeacher update);

        public ResponseModel GetTeacherById(int id);

        public ResponseModel DeleteTeacher(int id);

    }
}
