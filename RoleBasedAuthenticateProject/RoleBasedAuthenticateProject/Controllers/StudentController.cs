using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuthenticateProject.Repository;
using RoleBasedAuthenticateProject.RequestModels;

namespace RoleBasedAuthenticateProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentInterface _interface;

        public StudentController(IStudentInterface studentinteface)
        {
            _interface=studentinteface;
        }

        [HttpGet]
        [Route("GetAllStudentDetails")]
      

        public IActionResult GetAll()

        {
            var data = _interface.GetStudent();
            return Ok(data);

        }
       
        [HttpPost]
        [Route("AddEditStudentDetails")]
  
        public IActionResult AddEditStudentDetails(AddUpdate add)
        {
            var data = _interface.AddUpdateStudent(add);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetStudentBy/id")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetEmployee(int id)
        {
            var data = _interface.GetStudentDataById(id);
            return Ok(data);
        }
        [HttpDelete]
        [Route("DeleteStudent/id")]
        [Authorize(Roles = "Admin")]

        public IActionResult DeleteStudent(int id)
        {
            var data = _interface.DeletStudent(id);
            return Ok(data);
        }
    }
}


//[HttpPost]
//[Route("SaveStudentDetails")]
//[Authorize(Roles = "Admin")]
//public IActionResult SaveEmployee(AddStudent add)
//{
//    var data = _interface.AddStudentData(add);
//    return Ok(data);
//}

//[HttpPut]
//[Route("UpdateStudent")]
//[Authorize(Roles = "Admin, Teacher")]

//public IActionResult UpdateEmployee(UpdateStudent update)
//{
//    var data = _interface.UpdateStudent(update);
//    return Ok(data);
//}
