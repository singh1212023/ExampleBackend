using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuthenticateProject.Repository;
using RoleBasedAuthenticateProject.RequestModels;
using System.Data;

namespace RoleBasedAuthenticateProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {

        private readonly ITeacherInterface _interface;

        public TeacherController(ITeacherInterface teacherinterface)
        {
            _interface = teacherinterface;
        }

        [HttpGet]
        [Route("GetAllteachers")]
        [Authorize(Roles = "Admin, Teacher")]

        public IActionResult GetAll()

        {
            var data = _interface.GetTeacher();
            return Ok(data);

        }
        [HttpPost]
        [Route("SaveTeacherDetails")]
        [Authorize(Roles = "Admin")]
        public IActionResult SaveTeacherDetails(Addteacher add)
        {
            var data = _interface.AddTeacherData(add);
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateTeacher")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateTeacher(UpdateTeacher update)
        {
            var data = _interface.UpdateTeacher(update);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetTeacher/id")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetTeacher(int id)
        {
            var data = _interface.GetTeacherById(id);
            return Ok(data);
        }
        [HttpDelete]
        [Route("DeleteTeacher/id")]
        [Authorize(Roles = "Admin")]

        public IActionResult DeleteTeacher(int id)
        {
            var data = _interface.DeleteTeacher(id);
            return Ok(data);
        }
    }
    }
