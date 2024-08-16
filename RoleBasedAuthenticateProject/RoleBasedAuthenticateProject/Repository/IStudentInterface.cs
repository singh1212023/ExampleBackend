using RoleBasedAuthenticateProject.RequestModels;

namespace RoleBasedAuthenticateProject.Repository
{
    public interface IStudentInterface
    {

        public ResponseModel GetStudent();

     
        public ResponseModel AddUpdateStudent(AddUpdate student);

        public ResponseModel GetStudentDataById(int id);

        public ResponseModel DeletStudent(int id);


    }
}
































//public ResponseModel AddStudentData(AddStudent student);

//public ResponseModel UpdateStudent(UpdateStudent update);
